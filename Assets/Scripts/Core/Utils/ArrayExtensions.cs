using System;
using System.Collections.Generic;

namespace Core.Utils
{
	public static class ArrayExtensions
	{
		public static bool HasIndex<T>(this T[] array, int index) => index >= 0 && array.Length > index;

		public static bool HasIndex<T>(this List<T> array, int index) => index >= 0 && array.Count > index;

		public static void ForEachFromRandomIndex<T>(this T[] array, int index, Func<T, bool> nextFunc)
		{
			for (var i = 0; i < array.Length; i++)
			{
				var selectIndex = index % array.Length;
				index++;
				if (nextFunc(array[selectIndex]))
					continue;
				return;
			}
		}

		public static T FindFromRandomIndex<T>(this T[] array, int index, Func<T, bool> filter)
		{
			for (var i = 0; i < array.Length; i++)
			{
				var selectIndex = index % array.Length;
				index++;
				var item = array[selectIndex];
				if (filter(item))
					return item;
			}

			return default;
		}

		public static T FindFromRandomIndex<T>(this List<T> array, int index, Func<T, bool> filter)
		{
			for (var i = 0; i < array.Count; i++)
			{
				var selectIndex = index % array.Count;
				index++;
				var item = array[selectIndex];
				if (filter(item))
					return item;
			}

			return default;
		}

		public static void ForEachFromRandomIndex<T>(this List<T> array, int index, Func<T, bool> nextFunc)
		{
			for (var i = 0; i < array.Count; i++)
			{
				var selectIndex = index % array.Count;
				index++;
				if (nextFunc(array[selectIndex]))
					continue;
				return;
			}
		}
	}
}