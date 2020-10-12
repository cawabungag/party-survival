using System;
using System.Text;

namespace Core.Utils.Dao
{
	public static class StringExtensions
	{
		public static string Base64Encode(this string s)
		{
			var bytes = Encoding.UTF8.GetBytes(s);
			return Convert.ToBase64String(bytes);
		}

		public static string Base64Decode(this string s)
		{
			var bytes = Convert.FromBase64String(s);
			return Encoding.UTF8.GetString(bytes);
		}
	}
}