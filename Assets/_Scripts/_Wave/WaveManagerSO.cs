using System.Collections;
using Tower.Assets._Scripts._General;
using UnityEngine;

namespace Tower.Assets._Scripts._Wave
{
    [CreateAssetMenu(fileName = "WaveManagerSO", menuName = "SO/Wave/WaveManagerSO", order = 1)]
    public class WaveManagerSO : ScriptableObject
    {
        [SerializeField] private WaveViewModel _waveViewModel;
        [SerializeField] private float _waveDelayTime;

        private MonoBehaviour _mono;
        private int _waveNumber;


        public void Init(MonoBehaviour mono)
        {
            _waveNumber = 0;

            _mono = mono;
            _mono.StartCoroutine(WaveCoroutine());

        }

        private IEnumerator WaveCoroutine()
        {
            float time = 0f;

            WaveViewData _waveViewData = new WaveViewData();

            while (true)
            {
                time += Time.deltaTime;

                if (time > _waveDelayTime)
                {
                    time = 0f;
                    _waveNumber++;
                    _waveViewModel.SpawnWave();
                }

                //To avoid creating new object every frame.
                _waveViewData.Progress = time;
                _waveViewData.WaveNumber = _waveNumber;
                _waveViewData.MaxValue = _waveDelayTime;

                _waveViewModel.WaveProgress.Value = _waveViewData;

                yield return new WaitForEndOfFrame();
            }
        }
    }
}


