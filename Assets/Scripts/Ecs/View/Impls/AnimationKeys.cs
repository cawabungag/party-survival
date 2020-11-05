using DB.Units.MovementType;
using UnityEngine;

namespace Ecs.View.Impls
{
	public class AnimationKeys
	{
		private static readonly int IdleAnimation = Animator.StringToHash("Idle");
		private static readonly int WalkAnimation = Animator.StringToHash("Walk");
		private static readonly int RunAnimation = Animator.StringToHash("Run");
		private static readonly int DieAnimation = Animator.StringToHash("Die");

		public static int GetAnimation(EMovementType movementType)
		{
			switch (movementType)
			{
				case EMovementType.Idle:
					return IdleAnimation;
				case EMovementType.Walk:
					return WalkAnimation;
				case EMovementType.Run:
					return RunAnimation;
				case EMovementType.Die:
					return DieAnimation;
				default:
					return IdleAnimation;
			}
		}
	}
}