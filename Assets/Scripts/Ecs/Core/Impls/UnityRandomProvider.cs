using Ecs.Core.Interfaces;
using UnityEngine;

namespace Ecs.Core.Impls
{
	public class UnityRandomProvider : IRandomProvider
	{
		public float Value => Random.value;

		public int Range(int min, int max) => Random.Range(min, max);

		public float Range(float min, float max) => Random.Range(min, max);

		public Vector2 GetVector2() => Random.insideUnitCircle;
	}
}