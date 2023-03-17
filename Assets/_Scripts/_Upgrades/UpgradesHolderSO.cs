using System.Collections.Generic;
using UnityEngine;

namespace Tower.Assets._Scripts._Upgrades
{
    [CreateAssetMenu(fileName = "UpgradesHolderSO", menuName = "SO/Upgrades/UpgradesHolderSO", order = 1)]
    public class UpgradesHolderSO : ScriptableObject
    {
        public List<float> DamageUpgrades;
        public List<float> SpeedUpgrades;
        public List<float> RangeUpgrades;
    }
}


