using System;
using Tower.Assets._Scripts._General;
using UnityEngine;

namespace Tower.Assets._Scripts._Upgrades
{
    public class UpgradesPanelView : MonoBehaviour
    {
        [SerializeField] private UpgradesViewModel _upgradesViewModel;

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
            
        }
    }
}


