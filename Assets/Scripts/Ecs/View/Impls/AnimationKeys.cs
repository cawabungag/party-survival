using DB.Units.MovementType;
using UnityEngine;

namespace Ecs.View.Impls
{
	public class AnimationKeys
	{
		public static readonly int IdleAnimation = Animator.StringToHash("Idle");
		public static readonly int WalkAnimation = Animator.StringToHash("Walk");
		public static readonly int RunAnimation = Animator.StringToHash("Run");

		public static int GetAnimation(EMovementType movementType)
		{
			switch (movementType)
			{
				case EMovementType.Stay:
					return IdleAnimation;
				case EMovementType.Idle:
					return WalkAnimation;
				case EMovementType.Run:
					return RunAnimation;
				default:
					return IdleAnimation;
			}
		}
	}
}