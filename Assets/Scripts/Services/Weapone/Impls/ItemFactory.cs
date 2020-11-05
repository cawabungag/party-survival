using System.Collections.Generic;
using Ecs.View;

namespace Services.Weapone.Impls
{
	public class ItemFactory : IItemFactory
	{
		private readonly List<IInstantiateWeaponStrategy> _instantiateWeaponStrategies;

		public ItemFactory(List<IInstantiateWeaponStrategy> instantiateWeaponStrategies)
		{
			_instantiateWeaponStrategies = instantiateWeaponStrategies;
		}


		public ILinkable Create(ItemEntity entity)
		{
			foreach (var instantiateWeaponStrategy in _instantiateWeaponStrategies)
			{
				if (instantiateWeaponStrategy.CanInstantiate(entity))
					return instantiateWeaponStrategy.Create(entity);
			}

			throw new System.Exception($"[{nameof(ItemFactory)}] Cannot instantiate weapon {entity}");
		}
	}
}