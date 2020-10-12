﻿using System;

namespace Ecs.Core
{
	public struct Uid : IEquatable<Uid>
	{
		public static readonly Uid Empty = new Uid(-1);

		private readonly int _value;

		private Uid(int value)
		{
			_value = value;
		}

		public bool Equals(Uid other) => _value == other._value;

		public override bool Equals(object obj) => obj is Uid uid && Equals(uid);

		public override int GetHashCode() => _value;

		public static explicit operator Uid(int value) => new Uid(value);

		public static explicit operator int(Uid uid) => uid._value;

		public static bool operator ==(Uid a, Uid b) => a._value == b._value;

		public static bool operator !=(Uid a, Uid b) => a._value != b._value;

		public override string ToString() => $"Uid #{_value}";

		public static Uid Parse(string value)
		{
			var tmp = value.Remove(0, 5);
			return (Uid) int.Parse(tmp);
		}
	}
}