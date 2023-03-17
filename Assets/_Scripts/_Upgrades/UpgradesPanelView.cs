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

        private void HandleData(UpgradesViewData data)
        {
            _damageButton.SetText($"Damage {data.Damage}");
            _speedButton.SetText($"Speed {data.Speed}");
            _rangeButton.SetText($"Range {data.Range}");
        }
    }
}


