using System;
using System.Configuration;
using GPSAgent.GPS;



namespace GPSAgent.Data
{
	public class AppConfig : ConfigurationSection
	{
		#region Mehtod
		public static AppConfig Get()
		{
			return (AppConfig)ConfigurationManager.GetSection("AppConfig") ?? new AppConfig();
		}
		public static void Save(AppConfig oNew)
		{
			Configuration oConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			AppConfig oOld = (AppConfig)oConfig.Sections["AppConfig"];

			#region Copy
			foreach (GPSTracker o in oNew.GPSTrackers)
			{
				int i = oOld.GPSTrackers.IndexOf(o);
				if (i != -1)
				{
					oOld.GPSTrackers[i].ServerPort = o.ServerPort;
					oOld.GPSTrackers[i].ServerProtocol = o.ServerProtocol;
					oOld.GPSTrackers[i].ServerMaxConnections = o.ServerMaxConnections;
				}
				else
				{
					oOld.GPSTrackers.Add(o);
				}
			}
			#endregion

			oConfig.Save(ConfigurationSaveMode.Full);
			ConfigurationManager.RefreshSection("AppConfig");
		}
		public static AppConfig Default()
		{
			int iLastPort = 8080;
			AppConfig oDefault = new AppConfig();

			foreach (DeviceModel i in Enum.GetValues(typeof(DeviceModel)))
			{
				GPSTracker o = new GPSTracker() { Model = i, ServerPort = iLastPort++, ServerProtocol = System.Net.Sockets.ProtocolType.Tcp, ServerMaxConnections = 100 };
				oDefault.GPSTrackers.Add(o);
			}

			return oDefault;
		}

		public override bool IsReadOnly()
		{
			return false;
		}
		#endregion

		#region Property
		[System.Configuration.ConfigurationProperty("GPSTrackers")]
		[ConfigurationCollection(typeof(GPSTrackers), AddItemName = "GPSTracker")]
		public GPSTrackers GPSTrackers
		{
			get { return this["GPSTrackers"] as GPSTrackers; }
		}
		#endregion



	}
}