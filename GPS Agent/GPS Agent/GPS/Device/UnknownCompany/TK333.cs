using System;
using System.Collections.Generic;
using System.Device.Location;
using GPSAgent.Extensions;



namespace GPSAgent.GPS.Device.UnknownCompany
{
	class TK333 : IGPSData
	{
		#region Constant
		private static string[] DATA_TYPE = new string[] { "AUT", "SOS", "LPD", "OUT" };
		#endregion

		#region Enumeration
		/// <summary>
		/// Message DataType
		/// </summary>
		public enum DataType
		{
			AutoReporting = 0,
			SOS,
			LowBattery,
			GeoFence
		}
		/// <summary>
		/// GPS Status
		/// </summary>
		public enum GPSState
		{
			/// <summary>
			/// Available
			/// </summary>
			A,
			/// <summary>
			/// Shielded GPS signal
			/// </summary>
			V
		}
		#endregion

		#region Property
		private string m_IMEI;
		private string m_UserID;
		private GPSState m_Status;
		private string m_Password;
		private DataType m_DataType;
		private GeoCoordinate m_GeoCoordinate;
		private DateTime m_DateTimeOfFix;
		private UInt64 m_GSMBaseStationCode;
		#endregion



		#region Constructor
		/// <summary>
		/// Private constructor
		/// </summary>
		private TK333()
		{
		}
		#endregion

		#region Method
		/// <summary>
		/// Class factory. Extracts data from TK333 & WT100 GPS device
		/// </summary>
		/// <param name="szRawMessage">
		/// Message originates from GPS Tracker
		/// </param>
		public static List<IGPSData> Parse(string szRawMessage)
		{
			List<IGPSData> vObjects = new List<IGPSData>();
			string szIMEI = string.Empty;
			string szUserID = string.Empty;
			GPSState oStatus = GPSState.V;
			string szPassword = string.Empty;
			DataType oDataType = DataType.AutoReporting;
			int iTotalPacket = 1;


			if (!szRawMessage.StartsWith("#") || !szRawMessage.EndsWith("##"))
				throw new FormatException("Invalid GPS message format!");

			string[] vMessageChunks = szRawMessage.Split('#');

			int x;	// Next message chunk index


			// IMEI
			x = 1;
			szIMEI = vMessageChunks[x];

			// User ID
			szUserID = vMessageChunks[++x];

			// Status
			oStatus = int.Parse(vMessageChunks[++x]) == 1 ? GPSState.A : GPSState.V;

			// Password
			szPassword = vMessageChunks[++x];

			// Data Type
			x++;
			if (vMessageChunks[x].Equals(DATA_TYPE[(int)DataType.AutoReporting]))
				oDataType = DataType.AutoReporting;
			else if (vMessageChunks[x].Equals(DATA_TYPE[(int)DataType.SOS]))
				oDataType = DataType.SOS;
			else if (vMessageChunks[x].Equals(DATA_TYPE[(int)DataType.LowBattery]))
				oDataType = DataType.LowBattery;
			else if (vMessageChunks[x].Equals(DATA_TYPE[(int)DataType.GeoFence]))
				oDataType = DataType.GeoFence;
			else
				throw new NotImplementedException("Unknown Data Type: " + vMessageChunks[x]);

			// Packet Number
			iTotalPacket = int.Parse(vMessageChunks[++x]);


			// GSM Base Station Code + GeoCoord + Date Time
			for (int i = 0; i < iTotalPacket; i++)
			{
				TK333 o = new TK333();
				o.m_IMEI = szIMEI;
				o.m_UserID = szUserID;
				o.m_Status = oStatus;
				o.m_Password = szPassword;
				o.m_DataType = oDataType;

				// GSM base station
				o.m_GSMBaseStationCode = Convert.ToUInt64(vMessageChunks[++x], 16);

				// GeoCoords
				o.m_GeoCoordinate = new GeoCoordinate();
				string[] vGeoCoord = vMessageChunks[++x].Split(',');
				if (vGeoCoord.Length != 6)
					continue;	// Silently discards
				o.m_GeoCoordinate.Longitude = TK333.DecMinsToDegrees(vGeoCoord[1].Equals("E") ? +double.Parse(vGeoCoord[0]) : -double.Parse(vGeoCoord[0]));
				o.m_GeoCoordinate.Latitude = TK333.DecMinsToDegrees(vGeoCoord[3].Equals("N") ? +double.Parse(vGeoCoord[2]) : -double.Parse(vGeoCoord[2]));
				o.m_GeoCoordinate.Speed = TK333.KiloMetersPerHourToMetersPerSecond(double.Parse(vGeoCoord[4]));
				o.m_GeoCoordinate.Course = double.Parse(vGeoCoord[5]);

				// Date Time
				int iDate = 010169;									// Initialize to minimum supported Date
				int iTime = 000000;									// Initialize to minimum supported Time
				iDate = int.Parse(vMessageChunks[++x]);
				iTime = (int)double.Parse(vMessageChunks[++x]);		// Omit Ticks, save up to Seconds only
				int iDay = iDate / 10000;
				int iMonth = iDate / 100 % 100;
				int iYear = (iYear = iDate % 100) >= 69 ? iYear += 1900 : iYear += 2000;
				int iHour = iTime / 10000;
				int iMinute = iTime / 100 % 100;
				int iSecond = iTime % 100;
				o.m_DateTimeOfFix = new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond, DateTimeKind.Utc);

				vObjects.Add(o);
			}

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
		/// Converts km/h to m/s
		/// </summary>
		/// <param name="dValue">
		/// km/h value to be converted
		/// </param>
		/// <returns>
		/// m/s
		/// </returns>
		private static double KiloMetersPerHourToMetersPerSecond(double dValue)
		{
			return dValue * 5 / 18;
		}
		#endregion

		#region Property
		public string IMEI
		{
			get { return this.m_IMEI; }
		}
		public string UserID
		{
			get { return this.m_UserID; }
		}
		public GPSState Status
		{
			get { return this.m_Status; }
		}
		public string Password
		{
			get { return this.m_Password; }
		}
		public DataType Type
		{
			get { return this.m_DataType; }
		}
		public UInt64 GSMBaseStationCode
		{
			get { return this.m_GSMBaseStationCode; }
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
		public DateTime DateTime
		{
			get { return this.m_DateTimeOfFix; }
		}
		#endregion
	}
}
