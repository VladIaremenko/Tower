using System.Collections;
using UnityEngine;

namespace Tower.Assets._Scripts._Wave
{
    [CreateAssetMenu(fileName = "WaveManagerSO", menuName = "SO/Wave/WaveManagerSO", order = 1)]
    public class WaveManagerSO : ScriptableObject
    {
        [SerializeField] private float WaveDelayTime;
        private MonoBehaviour _mono;

        public void Init(MonoBehaviour mono)
        {
            _mono = mono;
            _mono.StartCoroutine(WaveCoroutine());
        }

        private IEnumerator WaveCoroutine()
        {
            float time = 0f;

            while (true)
            {
                time += Time.deltaTime;

                if(time > WaveDelayTime)
                {
                    Debug.Log("StartNextWave");
                    time = 0f;
                }

                yield return new WaitForEndOfFrame();
            }
        }
    }
}


