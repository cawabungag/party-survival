using System;

namespace DB.Weapons.Characteristics.Impls
{
   [Serializable]
   public class WeaponCharacteristicsVo
   {
      private string _weaponId;
      private float _damage;                     //Урон
      private float _firingFrequency;            //Частота стрельбы
      private int _shells;                     //Патроны в обойме
   
      public string WeaponId => _weaponId;
      public float Damage => _damage;
      public float FiringFrequency => _firingFrequency;
      public int Shells => _shells;
   }
}
