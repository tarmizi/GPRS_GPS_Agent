using System;



namespace GPSAgent.Extensions
{
	/// <summary>
	/// Extension methods of commonly used for string manipulations
	/// </summary>
	public static class StringX
	{
		/// <summary>
		/// Returns a specified number of contiguous substring from the start of a sequence.
		/// </summary>
		/// <param name="this">
		/// String instance
		/// </param>
		/// <param name="count">
		/// The number of substring to return.
		/// </param>
		/// <returns>
		/// A string that is equivalent to the substring of length
		/// </returns>
		public static string Left(this string @this, int count)
		{
			if (@this.Length <= count)
			{
				return @this;
			}
			else
			{
				return @this.Substring(0, count);
			}
		}
		/// <summary>
		/// Indicates whether a specified string is null, empty, or consists only of white-space characters.
		/// </summary>
		/// <param name="this">String instance</param>
		/// <returns>
		///  true if the value parameter is null or System.String.Empty, or if value consists exclusively of white-space characters.
		/// </returns>
		public static bool IsNull(this string @this)
		{
			return string.IsNullOrWhiteSpace(@this);
		}
		/// <summary>
		/// Encodes all the characters in the specified string into a sequence of bytes
		/// </summary>
		/// <param name="this">
		/// String instance
		/// </param>
		/// <returns>
		/// A byte array containing the results of encoding the specified set of characters.
		/// </returns>
		public static byte[] ToByteA(this string @this)
		{
			return System.Text.Encoding.ASCII.GetBytes(@this);
		}
	}
}
