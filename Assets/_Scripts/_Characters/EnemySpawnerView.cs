using Tower.Assets._Scripts._Enemy;
using Tower.Assets._Scripts._Wave;
using UnityEngine;

namespace Tower.Assets._Scripts._Characters
{
    public class EnemySpawnerView : MonoBehaviour
    {
        [SerializeField] private WaveViewModel _waveViewModel;
        [SerializeField] private CharactersViewModel _charactersViewModel;
        [SerializeField] private GameObject _enemyPrefab;

        [Range(1, 1000)]
        [SerializeField] private int _enemyCount;
        [Range(3, 10)]
        [SerializeField] private float _maxRadius;
        [Range(1, 2)]
        [SerializeField] private float _minRadius;

        private void OnEnable()
        {
            _waveViewModel.OnSpawnWaveEvent += HandleWaveSpawnEvent;
        }

        private void OnDisable()
        {
            _waveViewModel.OnSpawnWaveEvent -= HandleWaveSpawnEvent;
        }

        private void HandleWaveSpawnEvent()
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                var item = Instantiate(_enemyPrefab, transform);

                item.transform.position = GetRandomPosition();
            }
        }

        private Vector2 GetRandomPosition()
        {
            var playerPos = (Vector2)_charactersViewModel.Player.position;

            var newPos = Random.insideUnitCircle * _maxRadius + playerPos;

            while(Vector2.Distance(newPos, playerPos) < _minRadius)
            {
                newPos = Random.insideUnitCircle * _maxRadius + playerPos;
            }

            return newPos;
        }
    }
}