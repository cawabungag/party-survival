using System.Collections.Generic;
using Ecs.View;

namespace Services.Weapone.Impls
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly List<IInstantiateWeaponStrategy> _instantiateWeaponStrategies;
        
        public WeaponFactory(List<IInstantiateWeaponStrategy> instantiateWeaponStrategies)
        {
            _instantiateWeaponStrategies = instantiateWeaponStrategies;
        }
        
        
        public ILinkable Create(GameEntity entity)
        {
            foreach (var instantiateWeaponStrategy in _instantiateWeaponStrategies)
            {
                if (instantiateWeaponStrategy.CanInstantiate(entity))
                    return instantiateWeaponStrategy.Create(entity);
            }

            throw new System.Exception($"[{nameof(WeaponFactory)}] Cannot instantiate weapon {entity}");
        }
    }
}