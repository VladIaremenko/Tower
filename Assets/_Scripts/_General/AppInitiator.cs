using Tower.Assets._Scripts._Wave;
using UnityEngine;

namespace Tower.Assets._Scripts._General
{
    public class AppInitiator : MonoBehaviour
    {
        [SerializeField] private WaveManagerSO _waveManager;

        private void Start()
        {
            _waveManager.Init(this);   
        }
    }
}


