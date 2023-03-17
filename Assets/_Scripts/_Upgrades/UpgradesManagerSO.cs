using System.Collections.Generic;
using Tower.Assets._Scripts._General;
using Tower.Assets._Scripts._Storage;
using UnityEngine;

namespace Tower.Assets._Scripts._Upgrades
{
    [CreateAssetMenu(fileName = "UpgradesManagerSO", menuName = "SO/Upgrades/UpgradesManagerSO", order = 1)]
    public class UpgradesManagerSO : ScriptableObject
    {
        [SerializeField] private StorageSO _storageSO;
        [SerializeField] private UpgradesHolderSO _upgradesHolderSO;
        [SerializeField] private UpgradesViewModel _upgradesViewModel;

        public void Init()
        {
            var data = new UpgradesViewData();

            data.Damage = _upgradesHolderSO.DamageUpgrades[_storageSO.UserDataContainer.Upgrades[0]];
            data.Range = _upgradesHolderSO.RangeUpgrades[_storageSO.UserDataContainer.Upgrades[1]];
            data.Speed = _upgradesHolderSO.DamageUpgrades[_storageSO.UserDataContainer.Upgrades[2]];

            _upgradesViewModel.CurrentTowerData.Value = data;
        }

    }
}


