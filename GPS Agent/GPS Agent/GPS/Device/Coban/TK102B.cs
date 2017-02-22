using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Net.Sockets;
using GPSAgent.Extensions;



namespace GPSAgent.GPS.Device.Coban
{
	class TK102B : IGPSData
	{
		#region Constant
		private static string[] DATA_TYPE = new string[] { "tracker", "help me", "low battery", "stockade", "move", "speed" };
		#endregion

		#region Enumeration
		/// <summary>
		/// Message Data Type
		/// </summary>
		public enum DataType
		{
			Tracker = 0,
			SOS,
			LowBattery,
			GeoFence,
			Move,
			OverSpeed
		}
		/// <summary>
		/// GPS signal indicator
		/// </summary>
		public enum GPSSignal
		{
			/// <summary>
			/// Lost/low GPS Signal
			/// </summary>
			L,
			/// <summary>
			/// Fixed/full GPS Signal 
			/// </summary>
			F
		}
		#endregion

		#region Property
		private string m_IMEI;
		private DateTime m_DateTimeOfFix;
		private GPSSignal m_Signal = GPSSignal.L;
		private DataType m_DataType;
		private GeoCoordinate m_GeoCoordinate;
		#endregion



		#region Constructor
		/// <summary>
		/// Private constructor
		/// </summary>
		private TK102B()
		{
		}
		#endregion

		#region Method
		/// <summary>
		/// Log On
		/// </summary>
		/// <param name="oClientSocket">
		/// Connected Client socket
		/// </param>
		public static void LogOn(Socket oClientSocket)
		{
			byte[] LOAD = new byte[] { (byte)'L', (byte)'O', (byte)'A', (byte)'D' };
			byte[] vBuffer = new byte[1024];
			string szRawMessage;
			int iReceived;

			// Socket: RECV
			iReceived = oClientSocket.Receive(vBuffer);

			// Log on request
			// ##,imei:xxxxxxxxxxxxxxx,A;

          //  szRawMessage = "#356823031187318#TK333#1#0000#AUT#10#V#10144.9832,E,0312.5808,N,000.17,790000#230713#013831#V#10144.9803,E,0312.5799,N,000.28,260#230713#013907#V#10144.9805,E,0312.5816,N,000.47,260#230713#013936#V#10144.9889,E,0312.5880,N,000.78,730000#230713#014006#V#10144.9887,E,0312.5908,N,000.32,590000#230713#014036#V#10144.9884,E,0312.5897,N,000.22,590000#230713#014106#V#10144.9874,E,0312.5900,N,000.16,590000#230713#014131##";


            szRawMessage = System.Text.Encoding.ASCII.GetString(vBuffer, 0, iReceived);
            //comment if angkasa Project
            //if (!szRawMessage.StartsWith("##,imei:") || !szRawMessage.EndsWith("A;"))
            //    throw new FormatException("Invalid GPS message format!" + szRawMessage.ToString());

            // Socket: SEND
            if (oClientSocket.Send(LOAD) < LOAD.Length)
                throw new ApplicationException("Not all data was sent to the Client");
		}

		/// <summary>
		/// Class factory. Extracts data from Coban TK102B GPS device
		/// </summary>
		/// <param name="szRawMessage">
		/// Message originates from GPS Tracker
		/// </param>
		public static List<IGPSData> Parse(string szRawMessage)
		{
			List<IGPSData> vObjects = new List<IGPSData>();
          //  List<string> vObjects = new List<string>();
			if (!szRawMessage.StartsWith("imei:") || !szRawMessage.EndsWith(";"))
                throw new FormatException("Invalid GPS message format!" + szRawMessage.ToString());

			string[] vMessageChunks = szRawMessage.Split(',');















            TK102B o = new TK102B();
            o.m_GeoCoordinate = new GeoCoordinate();
            //int x;	// Next message chunk index



            //// IMEI
            //x = 0;
            //o.m_IMEI = vMessageChunks[x].Replace("imei:", string.Empty).Trim();

            //// Message Data Type
            ////x++;
            ////if (vMessageChunks[x].Equals(DATA_TYPE[(int)DataType.Tracker]))
            ////    o.m_DataType = DataType.Tracker;
            ////else if (vMessageChunks[x].Equals(DATA_TYPE[(int)DataType.SOS]))
            ////    o.m_DataType = DataType.SOS;
            ////else if (vMessageChunks[x].Equals(DATA_TYPE[(int)DataType.LowBattery]))
            ////    o.m_DataType = DataType.LowBattery;
            ////else if (vMessageChunks[x].Equals(DATA_TYPE[(int)DataType.GeoFence]))
            ////    o.m_DataType = DataType.GeoFence;
            ////else if (vMessageChunks[x].Equals(DATA_TYPE[(int)DataType.Move]))
            ////    o.m_DataType = DataType.Move;
            ////else if (vMessageChunks[x].Equals(DATA_TYPE[(int)DataType.OverSpeed]))
            ////    o.m_DataType = DataType.OverSpeed;
            ////else
            ////    throw new NotImplementedException("Unknown Data Type: " + vMessageChunks[x]);

            //// Date Time
            ////UInt64 iDateTime = UInt64.Parse(vMessageChunks[++x]);
            ////int iYear = (iYear = (int)(iDateTime / 100000000 % 100)) >= 69 ? iYear += 1900 : iYear += 2000;
            ////int iMonth = (int)(iDateTime / 1000000 % 100);
            ////int iDay = (int)(iDateTime / 10000 % 100);
            ////int iHour = (int)(iDateTime / 100 % 100);
            ////int iMinute = (int)(iDateTime % 100);
            ////o.m_DateTimeOfFix = new DateTime(iYear, iMonth, iDay, iHour, iMinute, 0, DateTimeKind.Utc);

            //// Undocumented data
            //x++;	// Skips

            //// GPS Signal
            //o.m_Signal = vMessageChunks[++x].Equals("F") ? GPSSignal.F : GPSSignal.L;

            //if (o.m_Signal == GPSSignal.F)
            //{
            //    // Time
            ////	x++;	// Local Time if configured, otherwise UTC, skips

            //    // Undocumented data
            //    //x++;	// Skips

            //    // GeoCoords
            //    o.m_GeoCoordinate = new GeoCoordinate();
            //    // Latitude
            //    x++;
            //    o.m_GeoCoordinate.Latitude = TK102B.DecMinsToDegrees(vMessageChunks[x + 1].Equals("N") ? +double.Parse(vMessageChunks[x]) : -double.Parse(vMessageChunks[x]));
            //    // Longitude
            //    x += 2;
            //    o.m_GeoCoordinate.Longitude = TK102B.DecMinsToDegrees(vMessageChunks[x + 1].Equals("E") ? +double.Parse(vMessageChunks[x]) : -double.Parse(vMessageChunks[x]));

            //    // Speed
            //    x += 2;
            //    o.m_GeoCoordinate.Speed = TK102B.KnotsToMetersPerSecond(double.Parse(vMessageChunks[x]));

            //    // Alitude
            //    x++;	// Skips
            //}


            vObjects.Add(o);
			return vObjects;
		}
		/// <summary>
		/// Converts Decimal Minutes (ddd°mm.mmm') format to Degrees Lat Long (dd.ddddd°)
		/// </summary>
		/// <param name="dValue">
		/// Dec Mins (dd°mm.mmm') to be converted
		/// </param>
		/// <returns>
		/// Converted degress value
		/// </returns>
		private static double DecMinsToDegrees(double dValue)
		{
			return Convert.ToInt32(dValue / 100) + (dValue - (Convert.ToInt32(dValue / 100) * 100)) / 60;
		}
		/// <summary>
		/// Converts Knots to m/s
		/// </summary>
		/// <param name="dValue">
		/// Knots to be converted
		/// </param>
		/// <returns>
		/// m/s
		/// </returns>
		private static double KnotsToMetersPerSecond(double dValue)
		{
			return dValue * 0.514444d;
		}
		#endregion

		#region Property
		public string IMEI
		{
			get { return this.m_IMEI; }
		}
		public DataType Type
		{
			get { return this.m_DataType; }
		}
		public DateTime DateTime
		{
			get { return this.m_DateTimeOfFix; }
		}
		public GPSSignal Signal
		{
			get { return this.m_Signal; }
		}
		public double Latitude
		{
			get { return this.m_GeoCoordinate.Latitude; }
		}
		public double Longitude
		{
			get { return this.m_GeoCoordinate.Longitude; }
		}
		public double Speed
		{
			get { return this.m_GeoCoordinate.Speed; }
		}
		public double Course
		{
			get { return this.m_GeoCoordinate.Course; }
		}
		#endregion
	}
}
