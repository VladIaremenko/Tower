using System;
using System.Collections;
using Tower.Assets._Scripts._Enemy;
using Tower.Assets._Scripts._General;
using Tower.Assets._Scripts._Upgrades;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tower.Assets._Scripts._Characters
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private CharactersViewModel _charactersViewModel;
        [SerializeField] private UpgradesViewModel _upgradesViewModel;
        [SerializeField] private ProjectileView _projectilePrefab;
        [SerializeField] private Transform _projectileParent;

        private float _damage;
        private float _reloadSpeed;
        private float _range;

        private void Awake()
        {
            _charactersViewModel.Player = transform;
        }

        private void OnEnable()
        {
            _upgradesViewModel.CurrentTowerStats.AddListener(HandleStatsUpdates);
        }

        private void OnDisable()
        {
            _upgradesViewModel.CurrentTowerStats.RemoveListener(HandleStatsUpdates);
        }

        private void HandleStatsUpdates(PlayerStatsData stats)
        {
            _damage = stats.Damage;
            _reloadSpeed = 1 / stats.Speed;
            _range = stats.Range;
        }

        private void Start()
        {
            StartCoroutine(ShootCoroutine());
        }

        private IEnumerator ShootCoroutine()
        {
            while (true)
            {
                if(_charactersViewModel.Enemies.Count == 0)
                {
                    yield return new WaitForFixedUpdate();
                    continue;
                }

                var item = Instantiate(_projectilePrefab, _projectileParent);
                item.Init(_damage);
                item.transform.position = transform.position;
                yield return new WaitForSeconds(_reloadSpeed);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
            //SceneManager.LoadScene(0);
        }
    }
}
