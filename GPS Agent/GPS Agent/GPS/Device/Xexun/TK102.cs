using System;
using System.Collections.Generic;
using System.Linq;
using GPSAgent.Extensions;
using GPSAgent.GPS.NMEA;



namespace GPSAgent.GPS.Device.Xexun
{
	class TK102 : IGPSData
	{
		#region Enumeration
		/// <summary>
		/// GPS signal indicator
		/// </summary>
		public enum GPSSignal
		{
			/// <summary>
			/// Low GPS Signal
			/// </summary>
			L,
			/// <summary>
			/// Full GPS Signal 
			/// </summary>
			F
		}
		#endregion

		#region Property
		private DateTime m_SerialNumber;
		private string m_AuthorizedNumber;
		private GPRMC m_GPRMC;
		private GPSSignal m_Signal = GPSSignal.L;
		private string m_SOSMessage;
		private string m_IMEI;
		private int m_GPSFix;
		private double m_Altitude;
		private BatteryPower m_Battery;
		private string m_MobileCountryCode;
		private string m_MobileNetworkCode;
		private string m_LocationAreaCode;
		private string m_CellID;
		#endregion



		#region Constructor
		/// <summary>
		/// Private constructor
		/// </summary>
		private TK102()
		{
		}
		#endregion

		#region Method
		/// <summary>
		/// Class factory. Extracts data from Xenun TK102B GPS device
		/// </summary>
		/// <param name="szRawMessage">
		/// Message originates from GPS Tracker
		/// </param>
		public static List<IGPSData> Parse(string szRawMessage)
		{
			List<IGPSData> vObjects = new List<IGPSData>();
			string[] vMessageChunks = szRawMessage.Split(',');
			
			#region Validation
			/*
			 * TODO : Need actual data from GPS device
			 * 
			// Validates the length of the string
			int iGprsStrLen = int.Parse(vMessageChunks[vMessageChunks.Length - 6]);
			int iGprsStr = vMessageChunks.Take(vMessageChunks.Length - 6).Sum(o => o.Length) + (vMessageChunks.Length - 6);
			if (iGprsStrLen != iGprsStr + 1)
				throw new ArgumentException("Malformed GPRS string length!");

			 * Standard CRC16 validation failed, ignore???
			 * TODO http://old.forum.gps-trace.com/viewtopic.php?id=5628
			 * 
			// Validates the message with Crc16
			int iCheckSum = int.Parse(vMessageChunks[vMessageChunks.Length - 5]);
			if (Security.Hash.Crc16.Get(szMessage.Left(iGprsStrLen)) != iCheckSum)	
				throw new ArgumentException("CRC mismatched!");
			 * */
			#endregion


			TK102 o = new TK102();
			int x;	// Next message chunk index

			// Serial Number
			x = 0;
			UInt64 iDateTime = UInt64.Parse(vMessageChunks[x]);
			int iYear = (iYear = (int)(iDateTime / 10000000000 % 100)) >= 69 ? iYear += 1900 : iYear += 2000;
			int iMonth = (int)(iDateTime / 100000000 % 100);
			int iDay = (int)(iDateTime / 1000000 % 100);
			int iHour = (int)(iDateTime / 10000 % 100);
			int iMinute = (int)(iDateTime / 100 % 100);
			int iSecond = (int)(iDateTime % 100);
			o.m_SerialNumber = new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond, DateTimeKind.Utc);

			// Authorized Number
			x++;
			o.m_AuthorizedNumber = vMessageChunks[x];

			// GRPMC data
			x++;
			int iGprmcChunksLength = vMessageChunks[x + 11].IndexOf('*') != -1 ? 12 : 13;
			o.m_GPRMC = new GPRMC(string.Join(",", vMessageChunks.Skip(x).Take(iGprmcChunksLength)));

			// Signal Indicator
			x += iGprmcChunksLength;
			o.m_Signal = vMessageChunks[x].Equals("F") ? GPSSignal.F : GPSSignal.L;

			// SOS Message
			o.m_SOSMessage = vMessageChunks[++x];

			// IMEI
			o.m_IMEI = vMessageChunks[++x].Replace("imei:", string.Empty).Trim();

			// GPS Fix
			o.m_GPSFix = int.Parse(vMessageChunks[++x]);

			// Altidute
			o.m_Altitude = double.Parse(vMessageChunks[++x]);

			// Battery
			x++;
			o.m_Battery = new BatteryPower(vMessageChunks.Skip(x).Take(2).ToArray());
			x = vMessageChunks.Length - 4;

			// XXX Codes
			o.m_MobileCountryCode = vMessageChunks[x];
			o.m_MobileNetworkCode = vMessageChunks[++x];
			o.m_LocationAreaCode = vMessageChunks[++x];

			// Cell ID
			o.m_CellID = vMessageChunks[++x];


			vObjects.Add(o);
			return vObjects;
		}
		#endregion

		#region Property
		public string SerialNumber
		{
			get { return this.m_SerialNumber.ToString("yyMMddhhmmss"); }
		}
		public string AuthorizedNumber
		{
			get { return this.m_AuthorizedNumber; }
		}
		public GPRMC GPRMC
		{
			get { return this.m_GPRMC; }
		}
		public double Latitude
		{
			get { return this.m_GPRMC.Latitude; }
		}
		public double Longitude
		{
			get { return this.m_GPRMC.Longitude; }
		}
		public double Speed
		{
			get { return this.m_GPRMC.Speed; }
		}
		public double Course
		{
			get { return this.m_GPRMC.Course; }
		}
		public DateTime DateTime
		{
			get { return this.m_GPRMC.DateTime; }
		}
		public GPSSignal Signal
		{
			get { return this.m_Signal; }
		}
		public string SOSMessage
		{
			get { return this.m_SOSMessage; }
		}
		public string IMEI
		{
			get { return this.m_IMEI; }
		}
		public int GPSFix
		{
			get { return this.m_GPSFix; }
		}
		public double Altitude
		{
			get { return this.m_Altitude; }
		}
		public BatteryPower Battery
		{
			get { return this.m_Battery; }
		}
		public string MobileCountryCode
		{
			get { return this.m_MobileCountryCode; }
		}
		public string MobileNetworkCode
		{
			get { return this.m_MobileNetworkCode; }
		}
		public string LocationAreaCode
		{
			get { return this.m_LocationAreaCode; }
		}
		public string CellID
		{
			get { return this.m_CellID; }
		}
		#endregion



		public class BatteryPower
		{
			#region Enumeration
			/// <summary>
			/// Battery power state
			/// </summary>
			public enum Power
			{
				/// <summary>
				/// Full battery power
				/// </summary>
				Full,
				/// <summary>
				/// Low battery power
				/// </summary>
				Low
			}
			/// <summary>
			/// Battery charging state
			/// </summary>
			public enum State
			{
				/// <summary>
				/// Battery is not charging
				/// </summary>
				Discharged,
				/// <summary>
				/// Battery in charging state
				/// </summary>
				Charging
			}
			#endregion

			#region Property
			private Power m_Power;
			private State m_State;
			private double m_Voltage;
			#endregion


			#region Constructor
			public BatteryPower(string[] vMessage)
			{
				if (vMessage.Length != 2)
					throw new ArgumentException();

				string[] vVoltage = vMessage[0].Split(':');
				if (vVoltage.Length != 2)
					throw new ArgumentException();

				this.m_Power = vVoltage[0].Equals("F") ? Power.Full : Power.Low;
				this.m_Voltage = double.Parse(vVoltage[1].Left(vVoltage[1].Length - 1));
				this.m_State = vMessage[1].Equals("0") ? State.Discharged : State.Charging;
			}
			#endregion

			#region Property
			public Power PowerState
			{
				get { return this.m_Power; }
			}
			public double Voltage
			{
				get { return this.m_Voltage; }
			}
			public State ChargingState
			{
				get { return this.m_State; }
			}
			#endregion
		}
	}
}
