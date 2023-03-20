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
            _damageButton.SetText(data.DamageIsMaxed ? "Damage is\nMaxed" : $"Damage: {data.DamageUpgradePrice}$");
            _speedButton.SetText(data.SpeedIsMaxed ? "Speed is\nMaxed" : $"Speed: {data.SpeedUpgradeSpeed}$");
            _rangeButton.SetText(data.RangeIsMaxed ? "Range is\nMaxed" : $"Range: {data.RangeIsMaxed}$");
        }
    }
}