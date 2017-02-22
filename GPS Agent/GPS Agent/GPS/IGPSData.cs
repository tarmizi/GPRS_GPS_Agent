using System;



namespace GPSAgent.GPS
{
	public interface IGPSData
	{
		string IMEI { get; }

		double Latitude { get; }
		double Longitude { get; }
		double Speed { get; }
		double Course { get; }

		DateTime DateTime { get; }
	}
}
