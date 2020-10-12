using Ecs.View;
using UnityEngine;

namespace Ecs.Core.Extensions
{
	public static class LinkableViewExtensions
	{
		public static int GetLinkHash(this Transform transform)
		{
			var hashHolder = transform.GetComponent<IEntityHashHolder>();
			return hashHolder.Hash;
		}
	}
}