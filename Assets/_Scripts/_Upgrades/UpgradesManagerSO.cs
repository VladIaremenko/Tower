using System;
using System.Collections.Generic;
using Tower.Assets._Scripts._Currency;
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
        [SerializeField] private CurrencyManagerSO _currencyManagerSO;

        public void Init()
        {
            RefreshViewData();
        }

        private void RefreshViewData()
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
            if(id == 0)
            {
                TryBuyUpgrade(_upgradesHolderSO.DamageUpgrades, id);
            }

            if (id == 1)
            {
                TryBuyUpgrade(_upgradesHolderSO.SpeedUpgrades, id);
            }

            if (id == 2)
            {
                TryBuyUpgrade(_upgradesHolderSO.RangeUpgrades, id);
            }
        }

        private void TryBuyUpgrade(List<float> prices, int id)
        {
            if (_currencyManagerSO.TryBuyItem(prices[_storageSO.UserDataContainer.Upgrades[id]]))
            {
                _storageSO.UserDataContainer.Upgrades[id]++;
            }

            RefreshViewData();
        }
    }
}


