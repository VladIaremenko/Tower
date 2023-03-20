using System;
using Tower.Assets._Scripts._General;
using UnityEngine;

namespace Tower.Assets._Scripts._Upgrades
{
    public class UpgradesPanelView : MonoBehaviour
    {
        [SerializeField] private UpgradesViewModel _upgradesViewModel;

        [SerializeField] private UpgradeButtonView _damageButton;
        [SerializeField] private UpgradeButtonView _speedButton;
        [SerializeField] private UpgradeButtonView _rangeButton;

        private void OnEnable()
        {
            _upgradesViewModel.CurrentTowerData.AddListener(HandleData);
        }

        private void OnDisable()
        {
            _upgradesViewModel.CurrentTowerData.RemoveListener(HandleData);
        }

        private void HandleData(UpgradesViewPanelData data)
        {
            _damageButton.SetText($"Damage: {data.DamageUpgradePrice}$");
            _speedButton.SetText($"Speed: {data.SpeedUpgradeSpeed}$");
            _rangeButton.SetText($"Range: {data.RangeUpgradeSpeed}$");
        }
    }
}


