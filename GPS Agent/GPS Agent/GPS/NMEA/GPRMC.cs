using System;
using System.Device.Location;
using GPSAgent.Extensions;



namespace GPSAgent.GPS.NMEA
{
	/// <summary>
	/// Extracts data from GPRMC message
	/// </summary>
	class GPRMC
	{
		#region Enumeration
		/// <summary>
		/// Valid property fields
		/// </summary>
		[Flags]
		public enum Fields
		{
			/// <summary>
			/// If this bit is set, no properties are valid
			/// </summary>
			None = 0,
			/// <summary>
			/// If this bit is set, Time property is valid
			/// </summary>
			Time = 0x1,
			/// <summary>
			/// If this bit is set, Status property is valid
			/// </summary>
			Status = 0x2,
			/// <summary>
			/// If this bit is set, Latitude property is valid
			/// </summary>
			Latitude = 0x4,
			/// <summary>
			/// If this bit is set, Longitude property is valid
			/// </summary>
			Longitude = 0x8,
			/// <summary>
			/// If this bit is set, Speed property is valid
			/// </summary>
			Speed = 0x10,
			/// <summary>
			/// If this bit is set, Course property is valid
			/// </summary>
			Course = 0x20,
			/// <summary>
			/// If this bit is set, Date property is valid
			/// </summary>
			Date = 0x40,
			/// <summary>
			/// If this bit is set, MagneticVariation property is valid
			/// </summary>
			MagneticVariation = 0x80,
			/// <summary>
			/// If this bit is set, SignalIntegrity property is valid
			/// </summary>
			/// <remarks>
			/// NMEA v2.3++ only
			/// </remarks>
			SignalIntegrity = 0x100
		}
		/// <summary>
		/// Data status
		/// </summary>
		public enum GPSState
		{
			/// <summary>
			/// Active
			/// </summary>
			A,
			/// <summary>
			/// Void
			/// </summary>
			V
		}
		/// <summary>
		/// NMEA v2.3++
		/// </summary>
		public enum Signal
		{
			NULL,
			Autonomous,
			Differential,
			Estimated,
			NotValid,
			Simulator
		}
		#endregion

		#region Constant
		private const int NMEA_PRIOR_2_3 = 12;
		private const int NMEA_2_3_PLUS = 13;

		private const int IDX_TIME = 1;
		private const int IDX_STATUS = 2;
		private const int IDX_LAT = 3;
		private const int IDX_LAT2 = 4;
		private const int IDX_LON = 5;
		private const int IDX_LON2 = 6;
		private const int IDX_SPEED = 7;
		private const int IDX_COURSE = 8;
		private const int IDX_DATE = 9;
		private const int IDX_MAGNETIC = 10;
		private const int IDX_MAGNETIC2 = 11;
		private const int IDX_SIGNAL = 12;
		#endregion

		#region Property
		private Fields m_ValidProperties = Fields.None;
		private string m_Message = string.Empty;
		private DateTime m_DateTimeOfFix = DateTime.MinValue;
		private GPSState m_Status = GPSState.V;
		private GeoCoordinate m_GeoCoordinate;
		private double m_MagneticVariation;
		private Signal m_SignalIntegrity = Signal.NULL;
		#endregion



		#region Constructor
		/// <summary>
		/// Constructs new GRPMC object from the specified NMEA(National Marine Electronics Association) 0183 message
		/// </summary>
		/// <param name="szGPRMC">
		/// GPRMC (Recommended minimum specific GPS/Transit data) message data
		/// </param>
		/// <remarks>
		/// <param name="bStrict">
		/// If True, Dollar Sign must be present at the beginning of the message
		/// </param>
		/// Only GPRMC message will be recognized, other than that FormatException will be thrown.
		/// </remarks>
		public GPRMC(string szGPRMC, bool bStrict = false)
		{
			// Accepts only GPRMC (Recommended minimum specific GPS/Transit data) message data
			if (bStrict)
			{
				if (!szGPRMC.StartsWith("$GPRMC"))
					throw new FormatException("Unrecognized GPRMC message");
			}
			else
			{
				if (!szGPRMC.StartsWith("GPRMC"))
					throw new FormatException("Unrecognized GPRMC message");
			}

			// Validate Check Sum
			if (!IsCheckSumValid(szGPRMC))
				throw new ArgumentException("CRC mismatched!");

			// Save instance
			this.m_Message = szGPRMC;

			// Retrieve data
			this.Parse();
		}
		#endregion

		#region Method
		/// <summary>
		/// Returns raw GPRMC message data
		/// </summary>
		public override string ToString()
		{
			return this.m_Message;
		}



		/// <summary>
		/// Validates the CheckSum of the specified NMEA0183 message
		/// </summary>
		/// <param name="szNMEA0183">
		/// NMEA0183 message to be validated
		/// </param>
		/// <returns>
		/// True if valid, otherwise false
		/// </returns>
		private bool IsCheckSumValid(string szNMEA0183)
		{
			if (!szNMEA0183.Substring(szNMEA0183.Length - 3, 1).Equals("*"))
				throw new ArgumentException("Unable to find CRC marker (*)");

			int iCheckSum = 0;
			int iCheckSumSrc = Convert.ToInt32(szNMEA0183.Substring(szNMEA0183.Length - 2), 16);

			int iDollarSignMarker = szNMEA0183[0] == '$' ? 1 : 0;
			string szData = szNMEA0183.Substring(iDollarSignMarker).Left(szNMEA0183.Length - (3 + iDollarSignMarker));
			byte[] vData = szData.ToByteA();

			for (int i = 0; i < vData.Length; i++)
				iCheckSum ^= vData[i];

			return iCheckSumSrc == iCheckSum;
		}
		/// <summary>
		/// Retrieves data from validated GPRMC message
		/// </summary>
		private void Parse()
		{
			string[] vMessageChunks = this.m_Message.Split(',');

			if (vMessageChunks.Length != NMEA_PRIOR_2_3 && vMessageChunks.Length != NMEA_2_3_PLUS)
				throw new ArgumentException("Malformed GPRMC message data");


			// Date & Time
			int iDate = 010169;									// Initialize to minimum supported Date
			int iTime = 000000;									// Initialize to minimum supported Time
			if (!vMessageChunks[IDX_DATE].IsNull())
			{
				this.m_ValidProperties |= Fields.Date;
				iDate = int.Parse(vMessageChunks[IDX_DATE]);
			}
			if (!vMessageChunks[IDX_TIME].IsNull())
			{
				this.m_ValidProperties |= Fields.Time;
				iTime = (int)double.Parse(vMessageChunks[IDX_TIME]);	// Omit Ticks, save up to Seconds only
			}
			int iDay = iDate / 10000;
			int iMonth = iDate / 100 % 100;
			int iYear = (iYear = iDate % 100) >= 69 ? iYear += 1900 : iYear += 2000;
			int iHour = iTime / 10000;
			int iMinute = iTime / 100 % 100;
			int iSecond = iTime % 100;
			this.m_DateTimeOfFix = new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond, DateTimeKind.Utc);


			// Status
			if (!vMessageChunks[IDX_STATUS].IsNull())
			{
				this.m_ValidProperties |= Fields.Status;
				this.m_Status = vMessageChunks[IDX_STATUS].Equals("A") ? GPSState.A : GPSState.V;
			}


			// Geographical Coordinates
			this.m_GeoCoordinate = new GeoCoordinate();
			if (!vMessageChunks[IDX_LAT2].IsNull() && !vMessageChunks[IDX_LAT].IsNull())
			{
				this.m_ValidProperties |= Fields.Latitude;
				this.m_GeoCoordinate.Latitude = this.DecMinsToDegrees(vMessageChunks[IDX_LAT2].Equals("N") ? +double.Parse(vMessageChunks[IDX_LAT]) : -double.Parse(vMessageChunks[IDX_LAT]));
			}
			if (!vMessageChunks[IDX_LON2].IsNull() && !vMessageChunks[IDX_LON].IsNull())
			{
				this.m_ValidProperties |= Fields.Longitude;
				this.m_GeoCoordinate.Longitude = this.DecMinsToDegrees(vMessageChunks[IDX_LON2].Equals("E") ? +double.Parse(vMessageChunks[IDX_LON]) : -double.Parse(vMessageChunks[IDX_LON]));
			}
			if (!vMessageChunks[IDX_SPEED].IsNull())
			{
				this.m_ValidProperties |= Fields.Speed;
				this.m_GeoCoordinate.Speed = this.KnotsToMetersPerSecond(double.Parse(vMessageChunks[IDX_SPEED]));
			}
			if (!vMessageChunks[IDX_COURSE].IsNull())
			{
				this.m_ValidProperties |= Fields.Course;
				this.m_GeoCoordinate.Course = double.Parse(vMessageChunks[IDX_COURSE]);
			}


			// Magnetic Variation
			if (!vMessageChunks[IDX_MAGNETIC].IsNull() && !vMessageChunks[IDX_MAGNETIC2].IsNull())
			{
				this.m_ValidProperties |= Fields.MagneticVariation;
				this.m_MagneticVariation = vMessageChunks[IDX_MAGNETIC2].StartsWith("E") ? +double.Parse(vMessageChunks[IDX_MAGNETIC]) : -double.Parse(vMessageChunks[IDX_MAGNETIC]);
			}


			// Signal Integrity
			if (vMessageChunks.Length == NMEA_2_3_PLUS)
			{
				if (!vMessageChunks[IDX_SIGNAL].IsNull())
				{
					this.m_ValidProperties |= Fields.SignalIntegrity;

					switch (vMessageChunks[IDX_SIGNAL][0])
					{
						case 'A':
							this.m_SignalIntegrity = Signal.Autonomous;
							break;
						case 'D':
							this.m_SignalIntegrity = Signal.Differential;
							break;
						case 'E':
							this.m_SignalIntegrity = Signal.Estimated;
							break;
						case 'N':
							this.m_SignalIntegrity = Signal.NotValid;
							break;
						case 'S':
							this.m_SignalIntegrity = Signal.Simulator;
							break;
						default:
							this.m_ValidProperties &= ~Fields.SignalIntegrity;
							break;
					}	
				}
			}
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
		private double DecMinsToDegrees(double dValue)
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
		private double KnotsToMetersPerSecond(double dValue)
		{
			return dValue * 0.514444d;
		}
		#endregion

		#region Property
		/// <summary>
		/// UTC of position fix
		/// </summary>
		public DateTime DateTime
		{
			get { return this.m_DateTimeOfFix; }
		}
		/// <summary>
		/// Data status / Navigation receiver warning
		/// </summary>
		public GPSState Status
		{
			get { return this.m_Status; }
		}
		/// <summary>
		/// Latitude
		/// </summary>
		public double Latitude
		{
			get { return this.m_GeoCoordinate.Latitude; }
		}
		/// <summary>
		/// Longitude
		/// </summary>
		public double Longitude
		{
			get { return this.m_GeoCoordinate.Longitude; }
		}
		/// <summary>
		/// Speed in meters per second
		/// </summary>
		public double Speed
		{
			get { return this.m_GeoCoordinate.Speed; }
		}
		/// <summary>
		/// Track angle in degrees True
		/// </summary>
		public double Course
		{
			get { return this.m_GeoCoordinate.Course; }
		}
		/// <summary>
		/// Magnetic variation degrees
		/// </summary>
		public double MagneticVariation
		{
			get { return this.m_MagneticVariation; }
		}
		/// <summary>
		/// Signal Integrity information needed by the FAA
		/// </summary>
		/// <remarks>
		/// NMEA v2.3++ only
		/// </remarks>
		public Signal SignalIntegrity
		{
			get { return this.m_SignalIntegrity; }
		}

		/// <summary>
		/// Checks if the property has been set
		/// </summary>
		public Fields ValidProperties
		{
			get { return this.m_ValidProperties; }
		}
		#endregion
	}
}
