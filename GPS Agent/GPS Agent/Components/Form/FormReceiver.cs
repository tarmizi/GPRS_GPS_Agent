using GPSAgent.Data;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace GPSAgent.Components.Form
{
    public partial class FormReceiver : System.Windows.Forms.Form
    {
        public FormReceiver()
        {
            InitializeComponent();
        }
        SocketPermission permission;
        Socket sListener;
        IPEndPoint ipEndPoint;
        Socket handler;
        private void startListenerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

      






        public void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = null;

            // A new Socket to handle remote host communication 
            Socket handler = null;
            try
            {
                // Receiving byte array 
                byte[] buffer = new byte[3072];
                // Get Listening Socket object 
                listener = (Socket)ar.AsyncState;
                // Create a new socket 
                handler = listener.EndAccept(ar);

                // Using the Nagle algorithm 
                handler.NoDelay = false;

                // Creates one object array for passing data 
                object[] obj = new object[2];
                obj[0] = buffer;
                obj[1] = handler;

                // Begins to asynchronously receive data 
                handler.BeginReceive(
                    buffer,        // An array of type Byt for received data 
                    0,             // The zero-based position in the buffer  
                    buffer.Length, // The number of bytes to receive 
                    SocketFlags.None,// Specifies send and receive behaviors 
                    new AsyncCallback(ReceiveCallback),//An AsyncCallback delegate 
                    obj            // Specifies infomation for receive operation 
                    );

                // Begins an asynchronous operation to accept an attempt 
                AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                listener.BeginAccept(aCallback, listener);
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }
        FormMain main = new FormMain();
        public void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Fetch a user-defined object that contains information 
                object[] obj = new object[2];
                obj = (object[])ar.AsyncState;

                // Received byte array 
                byte[] buffer = (byte[])obj[0];

                // A Socket to handle remote host communication. 
                handler = (Socket)obj[1];

                // Received message 
                string content = string.Empty;
                string contentAppnd = string.Empty;

                // The number of bytes received. 
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    content += Encoding.ASCII.GetString(buffer, 0,
                        bytesRead);

                    // If message contains "<Client Quit>", finish receiving
                    if (content.IndexOf("<Client Quit>") > -1)
                    {
                        // Convert byte array to string
                        string str = content.Substring(0, content.LastIndexOf("<Client Quit>"));


                        this.Invoke((MethodInvoker)delegate
                        {
                            ///////  listBoxGPSTraffic.Items.Add += "Read " + str.Length * 2 + " bytes from client.\n Data: " + str; // runs on UI thread
                        });
                        //this is used because the UI couldn't be accessed from an external Thread
                        //this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                        //{
                        //    tbAux.Text = "Read " + str.Length * 2 + " bytes from client.\n Data: " + str;
                        //}
                        //);
                    }
                    else
                    {
                        // Continues to asynchronously receive data
                        byte[] buffernew = new byte[3072];
                        obj[0] = buffernew;
                        obj[1] = handler;
                        handler.BeginReceive(buffernew, 0, buffernew.Length,
                            SocketFlags.None,
                            new AsyncCallback(ReceiveCallback), obj);
                    }


                    this.Invoke((MethodInvoker)delegate
                    {
                        contentAppnd += content;
                        if (content.Contains("imei:"))
                        {
                            GPSTrackerCobanFamily(contentAppnd);

                        } if (content.Contains("["))
                        {
                            MSIproject(contentAppnd);

                        }
                      //  listBoxGPSTraffic.Items.Add(contentAppnd);
                        //    textBoxMsgReceiveFromClient.Text += content; // runs on UI thread
                        //  sendACK();
                    });

                    //this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                    //{
                    //    tbAux.Text = content;
                    //}
                    //);
                }
            }
            catch (Exception exc)
            {
              //  main.MSIproject(exc.ToString());
             //  listBoxGPSTraffic.Items.Add(exc.ToString());
               ExceptionErrorMsg(exc.ToString());
                // textBoxMsgReceiveFromClient.Text += exc.ToString(); // runs on UI thread 
            }
        }

        private void ExceptionErrorMsg(string msg)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                listBoxGPSTraffic.Items.Add("ExceptionErrorMsg :" + msg);
               
            }));
        }
       
        private void buttonStartServer_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Creates one SocketPermission object for access restrictions
                permission = new SocketPermission(
                NetworkAccess.Accept,     // Allowed to accept connections 
                TransportType.Tcp,        // Defines transport types 
                "",                       // The IP addresses of local host 
                SocketPermission.AllPorts // Specifies all ports 
                );

                // Listening Socket object 
                sListener = null;

                // Ensures the code to have permission to access a Socket 
                permission.Demand();

                // Resolves a host name to an IPHostEntry instance 
                // IPHostEntry ipHost = Dns.GetHostEntry("");

                // Gets first IP address associated with a localhost 
                //   IPAddress ipAddr = ipHost.AddressList[0];
                //// IPAddress ipAddress = IPAddress.Parse(textBoxWorklistSServerIP.Text);
                 int Port=Convert.ToInt32( textBoxWorklistServerIPPort.Text);

                 IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, Port);
                // Creates a network endpoint 
                // ipEndPoint = new IPEndPoint(ipAddr, 4510);

                // Create one Socket object to listen the incoming connection 
                sListener = new Socket(
                   AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                    );

                // Associates a Socket with a local endpoint 
                sListener.Bind(serverEndPoint);

                toolStripStatusLabel.Text = "Server started.................";

                buttonStartServer.Enabled = false;
                buttonStartListerning.Enabled = true;
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }

        private void buttonStartListerning_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Places a Socket in a listening state and specifies the maximum 
                // Length of the pending connections queue 
                sListener.Listen(10);

                // Begins an asynchronous operation to accept an attempt 
                AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                sListener.BeginAccept(aCallback, sListener);

                toolStripStatusLabel.Text = "Server is now listening on....  port: " + textBoxWorklistServerIPPort.Text;

                buttonStartListerning.Enabled = false;
              
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }
        }
        string imei;
        string mode;
        string datetime;
        string GPStrackerSimnumber;
        string DataExistStatus;
        string GMTzonetime;
        string Uknown;
        string Latitude;
        string Longitude;
        string Speed;
        string Direction;
        string TracKiD;
        string SimNUM;
        DB oo = new DB();
        string holdimei;
        int countDevice = 0;
        int countPacketData = 0;
        string holdxory;
        List<string> listGPS = new List<string>();
        List<string> listofImeiNo = new List<string>();
        int i = 0;
        int APNi = 0;

#region CobanGPS



             public void GPSTrackerCobanFamily(string data)
        {


            string AngkasaImeiIndicated;
            string AngkasaImeiNo;
            string AngkasaUid;
            string AngkasaStatus;
            string AngkasaPassword;
            //string AngkasaDataType;
            //string AngkasaPacketNumber;
            //string AngkasaGSMbaseStation;
            string AngkasaLongitude;
            string AngkasaDatetime;
            string AngkasaLocalTime;
            string AngkasaAvaiablity;
            //  string AngkasaLongitudeE;
            string AngkasaLatitude;
            //  string AngkasaLatitudeN;
            string AngkasaSpeed;
            string AngkasaDirection;
            string WatchGPSdata;
            List<string> GPSdatas = new List<string>();
            if (countPacketData > 4000)
            {
                countPacketData = 0;
                //listBoxGPSpacket.Items.Clear();
                oo.deleteAllsignal();
            }
            WatchGPSdata = data.Replace(":", ",");
            //  string[] GPSdata = new string[13];

            listGPS.Clear();
            GPSdatas.Clear();
            //   this.LogAddInfo("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);

            listGPS.Add(WatchGPSdata.Replace(";", ","));
            listBoxGPSTraffic.Items.Add("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);
            try
            {
                foreach (string packetGps in listGPS)
                {


                    string[] vMessageChunks = packetGps.Split(',');
                    foreach (string dtGPS in vMessageChunks)
                    {

                        GPSdatas.Add(dtGPS);
                        listBoxGPSTraffic.Items.Add(" Count: " + i.ToString() + "   Split Data :" + dtGPS);
                        i = i + 1;
                    }
                }
                i = 0;
                AngkasaImeiIndicated = GPSdatas[0].ToString();

                if (AngkasaImeiIndicated.Contains("imei"))
                {
                    AngkasaImeiNo = GPSdatas[1].ToString();
                    AngkasaUid = GPSdatas[2].ToString();
                    AngkasaDatetime = GPSdatas[3].ToString();
                    AngkasaPassword = GPSdatas[4].ToString();
                    AngkasaStatus = GPSdatas[5].ToString();
                    AngkasaLocalTime = GPSdatas[6].ToString();
                    AngkasaAvaiablity = GPSdatas[7].ToString();
                    AngkasaLongitude = GPSdatas[8].ToString();
                    AngkasaLatitude = GPSdatas[10].ToString();
                    AngkasaSpeed = GPSdatas[12].ToString();
                    AngkasaDirection = GPSdatas[13].ToString();

                    if (AngkasaImeiNo != holdimei)
                    {
                        holdimei = AngkasaImeiNo;
                        if (!listofImeiNo.Contains(imei))
                        {
                            countDevice = countDevice + 1;
                        }
                        listofImeiNo.Add(imei);
                        oo.GetSimNumTrackID(AngkasaImeiNo);
                        TracKiD = oo.TrackingID;
                        SimNUM = oo.SimNumber;


                    }

                    oo.insertGPSdataNonMSI(AngkasaImeiNo, AngkasaImeiNo, AngkasaDatetime, AngkasaPassword, AngkasaStatus, AngkasaLocalTime, AngkasaAvaiablity, AngkasaLongitude, AngkasaLatitude, AngkasaSpeed, AngkasaDirection, TracKiD, SimNUM, "NA");

                }



            }
            catch (Exception g)
            {

                listGPS.Clear();
                GPSdatas.Clear();
                listBoxGPSTraffic.Items.Add("parsed GPSTrackerCobanFamily error :" + g.ToString());
                //    countrow = listBoxGPSpacket.Items.Count;

            }







        }


#endregion




        #region MSIProject
             public void MSIproject(string data)
             {
                 string MSIIdDevice;
                 string SignalStatus;
                 string Longituted;
                 string Latituded;
                 string Speed;
                 string WatchGPSdata;
                 string Directions;
                 string Altitude;
                 string BateryReading;
                 string GSMSignalReading;
                 string TerminalState;
                 string APN;

                 List<string> GPSdatas = new List<string>();


                 if (data.Contains("LK"))
                 {
                     listBoxGPSTraffic.Items.Add("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);
                     return;
                 }



                 if (countPacketData > 4000)
                 {
                     countPacketData = 0;
                     //listBoxGPSpacket.Items.Clear();
                     oo.deleteAllsignal();
                 }
                 WatchGPSdata = data.Replace("*", ",");
                 //  string[] GPSdata = new string[13];

                 listGPS.Clear();
                 GPSdatas.Clear();
                 //   this.LogAddInfo("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);

                 listGPS.Add(WatchGPSdata);


                 listBoxGPSTraffic.Items.Add("Time IN:" + DateTime.Now.ToLongDateString() + "," + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + " | Message received Raw Data " + data);
                 try
                 {
                     foreach (string packetGps in listGPS)
                     {


                         string[] vMessageChunks = packetGps.Split(',');
                         foreach (string dtGPS in vMessageChunks)
                         {

                             GPSdatas.Add(dtGPS);
                             listBoxGPSTraffic.Items.Add(" Count: " + i.ToString() + "   Split Data :" + dtGPS);
                             i = i + 1;
                         }
                     }
                     i = 0;
                     MSIIdDevice = GPSdatas[1].ToString();
                     SignalStatus = GPSdatas[6].ToString();
                     Latituded = GPSdatas[7].ToString();
                     Longituted = GPSdatas[9].ToString();
                     Speed = GPSdatas[11].ToString();
                     Directions = GPSdatas[12].ToString();
                     Altitude = GPSdatas[13].ToString();
                     GSMSignalReading = GPSdatas[15].ToString();
                     BateryReading = GPSdatas[16].ToString();
                     TerminalState = GPSdatas[19].ToString();





                     Regex MyRegex = new Regex("[^a-z@,:_]", RegexOptions.IgnoreCase);
                     string APNData = MyRegex.Replace(data + "_{ (7 438 ?. !`", @"");
                     string WPSApn = "";



                     string[] APNChunks = APNData.Split(',');
                     foreach (string DetectedAPN in APNChunks)
                     {

                         //    GPSdatas.Add(dtGPS);
                         if (!DetectedAPN.Contains(":") && DetectedAPN.Length > 1 && !DetectedAPN.Contains("UD"))
                         {
                             // MessageBox.Show(" Count: " + APNi.ToString() + "   Split Data :" + DetectedAPN);
                             WPSApn += DetectedAPN + ',';
                         }

                         APNi = APNi + 1;
                     }

                     APNi = 0;
                     if (WPSApn.Length > 1)
                     { WPSApn = WPSApn.Remove(WPSApn.Length - 1); }
                    

                     if (MSIIdDevice != holdimei)
                     {
                         holdimei = MSIIdDevice;
                         if (!listofImeiNo.Contains(MSIIdDevice))
                         {
                             countDevice = countDevice + 1;
                            toolStripStatusLabelDeviceCount.Text = countDevice.ToString();
                            
                         }
                         listofImeiNo.Add(MSIIdDevice);
                         //oo.GetSimNumTrackID(MSIIdDevice);
                         //TracKiD = oo.TrackingID;
                         //SimNUM = oo.SimNumber;


                     }

                     oo.insertGPSdata(MSIIdDevice, MSIIdDevice, "NA", "NA", SignalStatus, "NA",
                         "NA", Longituted, Latituded, Speed, Directions, MSIIdDevice, SimNUM, BateryReading, Altitude, GSMSignalReading, TerminalState, WPSApn);
                 }
                 catch (Exception b)
                 {
                     listGPS.Clear();
                     GPSdatas.Clear();
                     listBoxGPSTraffic.Items.Add("parsed MSIproject error :" + b.ToString());
                 }


             }
        #endregion

    }
}
