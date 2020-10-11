using Ecs.Access.States;
using Ecs.Access.States.Impls;
using Entitas;
using Zenject;

namespace Ecs.Access.EntityState.Impls
{
	public class UnitStateEntityAccess : AMultipleEntityAccess<GameContext, GameEntity, UnitState, IUnitState>
	{
		public UnitStateEntityAccess(
			GameContext context,
			IObjectAccess<GameEntity, IUnitState> objectAccess,
			IMemoryPool<UnitState> memoryPool
		) : base(context, objectAccess, memoryPool)
		{
		}

		protected override IMatcher<GameEntity> GetMatcher()
			=> GameMatcher.AllOf(GameMatcher.EcsGameFlagsUnit).NoneOf(GameMatcher.EcsCommonComponentsDestroyed);

		protected override void OnEntitySetState(GameEntity[] entities)
		{
			for (var i = 0; i < entities.Length; i++)
			{
				var entity = entities[i];
				entity.isEcsGameFlagsInstantiated = true;
				entity.isEcsGameFlagsLoaded = true;
			}
		}
	}
}