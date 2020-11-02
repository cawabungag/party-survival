using System;

namespace DB.Weapons.Characteristics.Impls
{
   [Serializable]
   public class WeaponCharacteristicsVo
   {  
      public EWeaponType _weaponId;
      private float _damage;
      private float _firingFrequency;
      private int _shells;
      
      public EWeaponType WeaponId => _weaponId;
      public float Damage => _damage;
      public float FiringFrequency => _firingFrequency;
      public int Shells => _shells;
   }
}
