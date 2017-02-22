using System;
using System.Collections.Generic;
using System.Linq;
using GPSAgent.Extensions;



namespace GPSAgent.GPS
{
	class TrackerData
	{
		#region Property
		private List<IGPSData> m_Objects;
		#endregion



		#region Constructor
		/// <summary>
		/// Constructs the specified GPS Tracker Message
		/// </summary>
		/// <param name="eDeviceModel">
		/// GPS device model
		/// </param>
		/// <param name="szRawMessage">
		/// Raw Message originates from GPS Tracker
		/// </param>
		private TrackerData()
		{
			
		}
		#endregion

		#region Method
		/// <summary>
		/// Class Factory
		/// </summary>
		/// <param name="eDeviceModel">
		/// GPS device model
		/// </param>
		/// <param name="szRawMessage">
		/// Raw Message originates from GPS Tracker
		/// </param>
		public static TrackerData Parse(DeviceModel eDeviceModel, string szRawMessage)
		{
			TrackerData o = null;

			switch (eDeviceModel)
			{
				case DeviceModel.XEXUN_TK102:
					o = new TrackerData();
					o.m_Objects = GPS.Device.Xexun.TK102.Parse(szRawMessage);
					break;
				case DeviceModel.COBAN_TK102B:
					o = new TrackerData();
					o.m_Objects = GPS.Device.Coban.TK102B.Parse(szRawMessage);
					break;
				case DeviceModel.UNKNOWNCOMPANY_TK333:
					o = new TrackerData();
					o.m_Objects = GPS.Device.UnknownCompany.TK333.Parse(szRawMessage);
					break;
				default:
					throw new NotImplementedException(eDeviceModel.ToString());
			}
			return o;
		}
		#endregion

		#region Property
		public List<IGPSData> Objects
		{
			get { return this.m_Objects; }
		}
		#endregion
	}
}
