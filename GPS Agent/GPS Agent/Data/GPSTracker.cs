using System.Configuration;
using System.Net.Sockets;
using GPSAgent.GPS;



namespace GPSAgent.Data
{
	public class GPSTracker : ConfigurationElement
	{
		#region Method
		public bool Equals(GPSTracker oGPSTracker)
		{
			return this.Model.Equals(oGPSTracker.Model);
		}
		public override string ToString()
		{
			return this.Model.ToString();
		}
		public override bool IsReadOnly()
		{
			return false;
		}
		#endregion

		#region Property
		[ConfigurationProperty("Model", IsKey = true, IsRequired = true)]
		public DeviceModel Model
		{
			get { return (DeviceModel)this["Model"]; }
			set { this["Model"] = value; }
		}

		[ConfigurationProperty("ServerPort", IsKey = false, IsRequired = true)]
		[IntegerValidator(ExcludeRange = false, MinValue = 0, MaxValue = 0xFFFF)]
		public int ServerPort
		{
			get { return (int)this["ServerPort"]; }
			set { this["ServerPort"] = value; }
		}

		[ConfigurationProperty("ServerProtocol", IsKey = false, IsRequired = true, DefaultValue = ProtocolType.Tcp)]
		public ProtocolType ServerProtocol
		{
			get { return (ProtocolType)this["ServerProtocol"]; }
			set { this["ServerProtocol"] = value; }
		}

		[ConfigurationProperty("ServerMaxConnections", IsKey = false, IsRequired = true, DefaultValue = 100)]
		[IntegerValidator(ExcludeRange = false, MinValue = 1, MaxValue = 1000)]
		public int ServerMaxConnections
		{
			get { return (int)this["ServerMaxConnections"]; }
			set { this["ServerMaxConnections"] = value; }
		}
		#endregion
	}
}
