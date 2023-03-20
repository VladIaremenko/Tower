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
            var data = new UpgradesViewPanelData();

            data.DamageUpgradePrice = _upgradesHolderSO.GetPrice(_upgradesHolderSO.DamageUpgrades[_storageSO.UserDataContainer.Upgrades[0]]);
            data.RangeUpgradeSpeed = _upgradesHolderSO.GetPrice(_upgradesHolderSO.RangeUpgrades[_storageSO.UserDataContainer.Upgrades[1]]);
            data.SpeedUpgradeSpeed = _upgradesHolderSO.GetPrice(_upgradesHolderSO.DamageUpgrades[_storageSO.UserDataContainer.Upgrades[2]]);

            _upgradesViewModel.CurrentTowerData.Value = data;
        }

        private void OnEnable()
        {
            _upgradesViewModel.UpgradeItemClickEvent += HandleUpgradeItem;
        }

        private void OnDisable()
        {
            _upgradesViewModel.UpgradeItemClickEvent -= HandleUpgradeItem;
        }

        private void HandleUpgradeItem(int id)
        {
            Debug.Log(id);
        }
    }
}


