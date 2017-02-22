using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using GPSAgent.Data;



namespace GPSAgent.Net
{
	public class Server : IDisposable
	{
		#region Constant
		/// <summary>
		/// Receive buffer size
		/// </summary>
		private const int RECV_SIZE = 1024;
		#endregion

		#region Event
		public delegate void ErrorEventHandler(Exception ex);
		public delegate void ClientConnectedEventHandler(int iTotalClient, EndPoint oEndPoint);
		public delegate void ClientDisconnectedEventHandler(int iTotalClient, EndPoint oEndPoint);
		public delegate void MessageReceivedEventHandler(string szMessage, GPSTracker oGPSTracker, EndPoint oEndPoint);

		[System.ComponentModel.Description("Raised when the Socket encountered an error.")]
		public event ErrorEventHandler OnError;
		[System.ComponentModel.Description("Raised when a Client has established the connection to the Server.")]
		public event ClientConnectedEventHandler OnClientConnected;
		[System.ComponentModel.Description("Raised when a Client has terminate the connection from the Server.")]
		public event ClientDisconnectedEventHandler OnClientDisconnected;
		[System.ComponentModel.Description("Raised when a Client has sent message to the Server.")]
		public event MessageReceivedEventHandler OnMessageReceived;
		#endregion

		#region Private
		/// <summary>
		/// Server Socket
		/// </summary>
		private Socket m_Socket;
		/// <summary>
		/// User configurations
		/// </summary>
		private GPSTracker m_GPSTracker;
		/// <summary>
		/// Total Clients connected
		/// </summary>
		private int m_ClientsConnected = 0;
		#endregion



		#region Constructor / Disposal
		/// <summary>
		/// Constructs new Server object
		/// </summary>
		/// <param name="oGPSTracker">
		/// User configurations
		/// </param>
		public Server(GPSTracker oGPSTracker)
		{
			this.m_GPSTracker = oGPSTracker;
		}

		/// <summary>
		/// Free VLC library
		/// </summary>
		public void Dispose()
		{
			Dispose(true);

			// Use SupressFinalize in case a subclass
			// of this type implements a finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">
		/// true if managed resources should be disposed; otherwise, false.
		/// </param>
		/// <remarks>
		/// http://www.nuclex.org/articles/architecture/2-the-disposable-pattern
		/// </remarks>
		protected virtual void Dispose(bool disposing)
		{
			// Release managed code
			if (disposing)
			{
				this.Stop();
			}
		}
		#endregion

		#region Event
		public static void AcceptCallback(IAsyncResult oResult)
		{
			// Get the socket that handles the Client request
			ServerObject oServer = oResult.AsyncState as ServerObject;
			Socket oClientSocket = null;

			try
			{
				// End asynchronous opertion
				oClientSocket = oServer.Socket.EndAccept(oResult);

				// Accepts next incoming connection requests
				oServer.Socket.BeginAccept(Server.AcceptCallback, oServer);


				// Raise on Connected event
				oServer.This.m_ClientsConnected++;
				oServer.This.RaiseOnClientConnected(oServer.This.m_ClientsConnected, oClientSocket.RemoteEndPoint);

				// Log On if necessary
				switch (oServer.This.m_GPSTracker.Model)
				{
					case GPS.DeviceModel.COBAN_TK102B:
					{
						GPS.Device.Coban.TK102B.LogOn(oClientSocket);
						break;
					}
				}

				// Create the state object & begin receiving data from the Client
				ClientObject oClient = new ClientObject();
				oClient.This = oServer.This;
				oClient.Socket = oClientSocket;
				oClient.Socket.BeginReceive(oClient.Buffer, 0, RECV_SIZE, 0, ReadCallback, oClient);
			}
			catch (ObjectDisposedException)
			{
				// Server Shutdown
                //add by mizi
                //oClientSocket.Close();
			}
			catch (Exception ex)
			{
				oServer.This.RaiseOnError(ex);

				// Force disconnect from this Client since we're getting exceptions
				if (oClientSocket != null)
				{
					EndPoint oEndPoint = oClientSocket.RemoteEndPoint;
					oClientSocket.Shutdown(SocketShutdown.Both);
					oClientSocket.Close();
					oServer.This.m_ClientsConnected--;
					oServer.This.RaiseOnClientDisconnected(oServer.This.m_ClientsConnected, oEndPoint);
				}
			}
		}
		public static void ReadCallback(IAsyncResult oResult)
		{
			// Retrieves the state object
			ClientObject oClient = oResult.AsyncState as ClientObject;

			try
			{
				// Read data from the Client Socket
				int iBytesRead = oClient.Socket.EndReceive(oResult);

				if (iBytesRead > 0)
				{
					if (iBytesRead != RECV_SIZE)
					{
						// Received complete packet
						oClient.Data.Append(Encoding.ASCII.GetString(oClient.Buffer, 0, iBytesRead));

						// Raise OnMessageReceived event
						oClient.This.RaiseOnMessageReceived(oClient.Data.ToString(), oClient.This.m_GPSTracker, oClient.Socket.RemoteEndPoint);
						// Clear the buffer
						oClient.Data.Clear();
                        //add by mizi
                       // oClient.Socket.Close();
                        oClient.This.Stop();
					}
					else
					{
						oClient.Data.Append(Encoding.ASCII.GetString(oClient.Buffer, 0, iBytesRead));

						if (oClient.Socket.Available == 0)
						{
							// No more pending data's, raise OnMessageReceived event
							oClient.This.RaiseOnMessageReceived(oClient.Data.ToString(), oClient.This.m_GPSTracker, oClient.Socket.RemoteEndPoint);
							// Clear the buffer
							oClient.Data.Clear();
                            //add by mizi
                           // oClient.Socket.Close();
                            oClient.This.Stop();
						}
					}
                  
				}
                oClient.This.Start();
				// Accepts next incoming messages
				oClient.Socket.BeginReceive(oClient.Buffer, 0, RECV_SIZE, 0, ReadCallback, oClient);
			}
			catch (ObjectDisposedException)
			{
				// Server Shutdown
			}
			catch (SocketException ex)
			{
				switch (ex.SocketErrorCode)
				{
					case SocketError.ConnectionReset:
						oClient.This.m_ClientsConnected--;
						oClient.This.RaiseOnClientDisconnected(oClient.This.m_ClientsConnected, oClient.Socket.RemoteEndPoint);
						break;
					default:
						oClient.This.RaiseOnError(ex);
						break;
				}
			}
			catch (Exception ex)
			{
				oClient.This.RaiseOnError(ex);

				// Force disconnect from this Client since we're getting exceptions
				EndPoint oEndPoint = oClient.Socket.RemoteEndPoint;
				oClient.Socket.Shutdown(SocketShutdown.Both);
				oClient.Socket.Close();
				oClient.This.m_ClientsConnected--;
				oClient.This.RaiseOnClientDisconnected(oClient.This.m_ClientsConnected, oEndPoint);
			}
		}
		#endregion

		#region Method
		public void Start()
		{
			// Create a TCP/IP socket
			this.m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, this.m_GPSTracker.ServerProtocol);
			// Bind the socket to the local endpoint
			this.m_Socket.Bind(new IPEndPoint(IPAddress.Any, this.m_GPSTracker.ServerPort));
			// Sets the Maximum Connections for this Socket
			this.m_Socket.Listen(this.m_GPSTracker.ServerMaxConnections);

			ServerObject o = new ServerObject();
			o.This = this;
			o.Socket = this.m_Socket;
			this.m_Socket.BeginAccept(Server.AcceptCallback, o);
		}
		public void Stop()
		{
			if (this.m_Socket != null)
			{
				this.m_Socket.Close();
				this.m_Socket = null;
			}
		}

		private void RaiseOnError(Exception ex)
		{
			// Make a temporary copy of the event to avoid possibility of
			// a race condition if the last subscriber unsubscribes
			// immediately after the null check and before the event is raised
			ErrorEventHandler EventHandler = this.OnError;

			// If an event has no subscribers registered, it will
			// evaluate to null. The test checks that the value is not
			// null, ensuring that there are subsribers before
			// calling the event itself.
			if (EventHandler != null)
				EventHandler(ex);
		}
		private void RaiseOnMessageReceived(string szMessage, GPSTracker oGPSTracker, EndPoint oEndPoint)
		{
			// Make a temporary copy of the event to avoid possibility of
			// a race condition if the last subscriber unsubscribes
			// immediately after the null check and before the event is raised
			MessageReceivedEventHandler EventHandler = this.OnMessageReceived;

			// If an event has no subscribers registered, it will
			// evaluate to null. The test checks that the value is not
			// null, ensuring that there are subsribers before
			// calling the event itself.


            if (EventHandler != null)
                EventHandler(szMessage, oGPSTracker, oEndPoint);


            //if (EventHandler != null)
            //    EventHandler("#356823031187318#TK333#1#0000#AUT#10#V#10144.9832,E,0312.5808,N,000.17,790000#230713#013831#V#10144.9803,E,0312.5799,N,000.28,260#230713#013907#V#10144.9805,E,0312.5816,N,000.47,260#230713#013936#V#10144.9889,E,0312.5880,N,000.78,730000#230713#014006#V#10144.9887,E,0312.5908,N,000.32,590000#230713#014036#V#10144.9884,E,0312.5897,N,000.22,590000#230713#014106#V#10144.9874,E,0312.5900,N,000.16,590000#230713#014131##", oGPSTracker, oEndPoint);

            

		}
		private void RaiseOnClientConnected(int iTotalClient, EndPoint oEndPoint)
		{
			// Make a temporary copy of the event to avoid possibility of
			// a race condition if the last subscriber unsubscribes
			// immediately after the null check and before the event is raised
			ClientConnectedEventHandler EventHandler = this.OnClientConnected;

			// If an event has no subscribers registered, it will
			// evaluate to null. The test checks that the value is not
			// null, ensuring that there are subsribers before
			// calling the event itself.
			if (EventHandler != null)
				EventHandler(iTotalClient, oEndPoint);
		}
		private void RaiseOnClientDisconnected(int iTotalClient, EndPoint oEndPoint)
		{
			// Make a temporary copy of the event to avoid possibility of
			// a race condition if the last subscriber unsubscribes
			// immediately after the null check and before the event is raised
			ClientDisconnectedEventHandler EventHandler = this.OnClientDisconnected;

			// If an event has no subscribers registered, it will
			// evaluate to null. The test checks that the value is not
			// null, ensuring that there are subsribers before
			// calling the event itself.
			if (EventHandler != null)
				EventHandler(iTotalClient, oEndPoint);
		}
		#endregion



		#region Class
		/// <summary>
		/// State object
		/// </summary>
		public class ServerObject
		{
			/// <summary>
			/// Object instance
			/// </summary>
			public Server This = null;
			/// <summary>
			/// Client  socket
			/// </summary>
			public Socket Socket = null;
		}
		/// <summary>
		/// State object for reading client data asynchronously
		/// </summary>
		public class ClientObject
		{
			/// <summary>
			/// Object instance
			/// </summary>
			public Server This = null;
			/// <summary>
			/// Client  socket
			/// </summary>
			public Socket Socket = null;
			/// <summary>
			/// Receive buffer
			/// </summary>
			public byte[] Buffer = new byte[RECV_SIZE];
			/// <summary>
			/// Received data string
			/// </summary>
			public StringBuilder Data = new StringBuilder();
		}
		#endregion
	}
}
