using System.Collections.Generic;

namespace Ecs.Core
{
	public static class UidGenerator
	{
		private static readonly HashSet<Uid> HashSet = new HashSet<Uid>();
		private static int _current;

		private static Uid NextUid
		{
			get
			{
				if (_current == int.MaxValue)
					_current = 0;
				return (Uid) _current++;
			}
		}

		public static Uid Next()
		{
			Uid uid;
			do
			{
				uid = NextUid;
			} while (HashSet.Contains(uid));

			HashSet.Add(uid);
			return uid;
		}

		public static void Reserve(Uid uid) => HashSet.Add(uid);

		public static void Remove(Uid uid) => HashSet.Remove(uid);

		public static void Clear()
		{
			HashSet.Clear();
			_current = 0;
		}
	}
}