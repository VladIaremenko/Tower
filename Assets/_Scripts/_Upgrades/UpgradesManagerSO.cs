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

            data.DamageUpgradePrice = _upgradesHolderSO.GetDamageUpgradePrice();
            data.RangeUpgradeSpeed = _upgradesHolderSO.GetRandgeUpgradePrice();
            data.SpeedUpgradeSpeed = _upgradesHolderSO.GetSpeedUpgradePrice();
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
                TryBuyUpgrade(_upgradesHolderSO.GetDamageUpgradePrice(), id, _upgradesHolderSO.DamageUpgrades.Count);
            }

            if (id == 1)
            {
                TryBuyUpgrade(_upgradesHolderSO.GetSpeedUpgradePrice(), id, _upgradesHolderSO.SpeedUpgrades.Count);
            }

            if (id == 2)
            {
                TryBuyUpgrade(_upgradesHolderSO.GetRandgeUpgradePrice(), id, _upgradesHolderSO.RangeUpgrades.Count);
            }
        }

        private void TryBuyUpgrade(float price, int id, int maxValue)
        {
            if(_storageSO.UserDataContainer.Upgrades[id] >= maxValue - 1)
            {
                Debug.Log("MaxUpgrades");
                return;
            }

            if (_currencyManagerSO.TryBuyItem(price))
            {
                _storageSO.UserDataContainer.Upgrades[id]++;
                _storageSO.UserDataContainer = _storageSO.UserDataContainer;
                RefreshViewData();
            }
        }
    }
}


