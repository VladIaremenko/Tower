using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tower.Assets._Scripts._General
{
    public class WaveViewData
    {
        public float Progress;
        public float MaxValue;
        public int WaveNumber;
    }

    public class UpgradesData
    {
        public List<int> Upgrades;

        public UpgradesData(List<int> upgrades)
        {
            Upgrades = upgrades;
        }
    }

    [Serializable]
    public class UpgradesViewPanelData
    {
        public float DamageUpgradePrice;
        public float RangeUpgradeSpeed;
        public float SpeedUpgradeSpeed;

        public bool DamageIsMaxed;
        public bool RangeIsMaxed;
        public bool SpeedIsMaxed;
    }

    public class PlayerStatsData
    {
        public float Damage;
        public float Speed;
        public float Range;

        public PlayerStatsData(float damage, float speed, float range)
        {
            Damage = damage;
            Speed = speed;
            Range = range;
        }
    }
}


