using System;



namespace GPSAgent.Security.Hash
{
	public static class Crc16
	{
		const ushort POLYNOMIAL = 0xA001;
		static readonly ushort[] LOOKUP_TABLE = new ushort[256];

		static Crc16()
		{
			ushort iValue;
			ushort iTmp;
			for (ushort i = 0; i < LOOKUP_TABLE.Length; ++i)
			{
				iValue = 0;
				iTmp = i;
				for (byte j = 0; j < 8; ++j)
				{
					if (((iValue ^ iTmp) & 0x0001) != 0)
					{
						iValue = (ushort)((iValue >> 1) ^ POLYNOMIAL);
					}
					else
					{
						iValue >>= 1;
					}
					iTmp >>= 1;
				}
				LOOKUP_TABLE[i] = iValue;
			}
		}

		public static ushort Get(string szData)
		{
			return Get(System.Text.Encoding.ASCII.GetBytes(szData));
		}
		public static ushort Get(byte[] bytes)
		{
			ushort iCheckSum = 0;
			for (int i = 0; i < bytes.Length; ++i)
			{
				byte iIndex = (byte)(iCheckSum ^ bytes[i]);
				iCheckSum = (ushort)((iCheckSum >> 8) ^ LOOKUP_TABLE[iIndex]);
			}
			return iCheckSum;
		}
	}
}