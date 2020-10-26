using CleverCrow.Fluid.BTs.Trees;
using DB.Units;
using DB.Units.Prefabs;
using DB.Units.Prefabs.Impls;
using Ecs.View;
using Ecs.View.Impls.Game;
using Game.Ai;
using UnityEngine;
using Zenject;

namespace Services.Unit.Impls.Strategies
{
	public abstract class AInstantiateUnitStrategy : IInstantiateUnitStrategy
	{
		private readonly DiContainer _diContainer;
		private readonly IUnitPrefabDatabase _unitDatabase;
		private readonly IBehaviourTreeFactory _behaviourTreeFactory;

		protected AInstantiateUnitStrategy(
			DiContainer diContainer,
			IUnitPrefabDatabase unitDatabase, IBehaviourTreeFactory behaviourTreeFactory
		)
		{
			_diContainer = diContainer;
			_unitDatabase = unitDatabase;
			_behaviourTreeFactory = behaviourTreeFactory;
		}

		public abstract bool CanInstantiate(GameEntity entity);

		public virtual ILinkable Create(GameEntity entity)
		{
			if (entity.isEnemy)
			{
				IBehaviorTree behaviorTree = _behaviourTreeFactory.Create(entity);
				entity.AddEcsGameComponentsAiBehaviourTree(behaviorTree);
				entity.AddEcsGameMoveEndTime(0);
			}
			EObjectType unitType = entity.ecsGameObjectType.Value;
			UnitPrefabVo unit = _unitDatabase.GetUnitPrefab(unitType);
			UnitObjectView view = _diContainer.InstantiatePrefabForComponent<UnitObjectView>(unit.Prefab, entity.ecsGamePosition.value,
				Quaternion.identity, null);
			return view;
		}
	}
}