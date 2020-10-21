using Ecs.Common.Components;

namespace Ecs.Access.States.Impls.Access
{
	public class UnitStatePropertyAccess : StatePropertyAccess<GameEntity, IUnitState>
	{
		public override void Initialize()
		{
			AddOriginator<UidPropertyAccess>();
		}
	}
}