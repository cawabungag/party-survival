using System;

namespace Core.Utils
{
	public static class StringExtensions
	{
		public static T ToEnum<T>(this string s) where T : Enum
			=> string.IsNullOrEmpty(s) || s.Length < 2 ? default : (T) Enum.Parse(typeof(T), s);
	}
}