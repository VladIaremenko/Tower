using System.Collections.Generic;
using Tower.Assets._Scripts._Storage;
using UnityEngine;

namespace Tower.Assets._Scripts._Upgrades
{
    [CreateAssetMenu(fileName = "UpgradesHolderSO", menuName = "SO/Upgrades/UpgradesHolderSO", order = 1)]
    public class UpgradesHolderSO : ScriptableObject
    {
        [SerializeField] private StorageSO _storage;

        public List<float> DamageUpgrades;
        public List<float> SpeedUpgrades;
        public List<float> RangeUpgrades;

        public float GetDamageUpgradePrice()
        {
            return DamageUpgrades[_storage.UserDataContainer.Upgrades[0]] * 5;
        }

        public float GetSpeedUpgradePrice()
        {
            return SpeedUpgrades[_storage.UserDataContainer.Upgrades[1]] * 5;
        }

        public float GetRandgeUpgradePrice()
        {
            return RangeUpgrades[_storage.UserDataContainer.Upgrades[2]] * 5;
        }
    }
}


