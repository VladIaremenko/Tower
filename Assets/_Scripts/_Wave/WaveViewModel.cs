using System;
using Tower.Assets._Scripts._General;
using Tower.Assets._Scripts._Misc;
using UnityEngine;

namespace Tower.Assets._Scripts._Wave
{
    [CreateAssetMenu(fileName = "WaveViewModel", menuName = "SO/Wave/WaveViewModel", order = 1)]
    public class WaveViewModel : ScriptableObject
    {
        public ObservableVariable<WaveViewData> WaveProgress = new ObservableVariable<WaveViewData>();
        public event Action OnSpawnWaveEvent = () => { };

        internal void SpawnWave()
        {
            OnSpawnWaveEvent.Invoke();
        }
    }
}


