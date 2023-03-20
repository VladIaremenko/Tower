using Tower.Assets._Scripts._General;
using Tower.Assets._Scripts._Misc;
using UnityEngine;

namespace Tower.Assets._Scripts._Upgrades
{
    [CreateAssetMenu(fileName = "UpgradesViewModel", menuName = "SO/Upgrades/UpgradesViewModel", order = 1)]
    public class UpgradesViewModel : ScriptableObject
    {
        public ObservableVariable<UpgradesViewPanelData> CurrentTowerData = new ObservableVariable<UpgradesViewPanelData>();



    }
}


