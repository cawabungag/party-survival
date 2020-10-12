using System;
using UnityEngine;

[Serializable]
public class WeaponCharacteristicsVo : MonoBehaviour
{
   private string _weaponId;
   private int _damage;                     //Урон
   private int _firingFrequency;            //Частота стрельбы
   private int _shells;                     //Патроны в обойме
   
   public string WeaponId => _weaponId;
   public int Damage => _damage;
   public int FiringFrequency => _firingFrequency;
   public int Shells => _shells;
}
