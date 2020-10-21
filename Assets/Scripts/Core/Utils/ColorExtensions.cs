using UnityEngine;

namespace Core.Utils
{
	public static class ColorExtension
	{
		public static string ToRgbHex(this Color c)
			=> "#" + ToByte(c.r).ToString("X2")
			       + ToByte(c.g).ToString("X2")
			       + ToByte(c.b).ToString("X2");

		public static string ToRgbaHex(this Color c)
			=> "#" + ToByte(c.r).ToString("X2")
			       + ToByte(c.g).ToString("X2")
			       + ToByte(c.b).ToString("X2")
			       + ToByte(c.a).ToString("X2");

		private static byte ToByte(float f)
			=> (byte) (Mathf.Clamp01(f) * (double) byte.MaxValue);
	}
}