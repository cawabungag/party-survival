using System.Collections.Generic;
using Ecs.View;

namespace Services.Unit.Impls
{
	public class UnitFactory : IUnitFactory
	{
		private readonly List<IInstantiateUnitStrategy> _instantiateUnitStrategies;

		public UnitFactory(List<IInstantiateUnitStrategy> instantiateUnitStrategies)
		{
			_instantiateUnitStrategies = instantiateUnitStrategies;
		}

		public ILinkable Create(GameEntity entity)
		{
			foreach (var instantiateUnitStrategy in _instantiateUnitStrategies)
			{
				if (instantiateUnitStrategy.CanInstantiate(entity))
					return instantiateUnitStrategy.Create(entity);
			}

			throw new System.Exception($"[{nameof(UnitFactory)}] Cannot instantiate unit {entity}");
		}
	}
}