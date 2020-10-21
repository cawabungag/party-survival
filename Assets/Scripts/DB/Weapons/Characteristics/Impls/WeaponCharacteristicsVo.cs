using System;
using DB.Units;

namespace DB.Weapons.Characteristics.Impls
{
   [Serializable]
   public class WeaponCharacteristicsVo
   {  
      public EObjectType _weaponId;
      
      public float _damage;                     //Урон
      public float _firingFrequency;            //Частота стрельбы
      public int _shells;                     //Патроны в обойме
   
      public EObjectType WeaponId => _weaponId;
      public float Damage => _damage;
      public float FiringFrequency => _firingFrequency;
      public int Shells => _shells;
   }
}
