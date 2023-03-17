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
    public class UpgradesViewData
    {
        public float Damage;
        public float Range;
        public float Speed;
    }
}


