using System.Collections;
using System.Linq;
using Tower.Assets._Scripts._Enemy;
using Tower.Assets._Scripts._General;
using Tower.Assets._Scripts._Upgrades;
using UnityEngine;

namespace Tower.Assets._Scripts._Characters
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private CharactersViewModel _charactersViewModel;
        [SerializeField] private UpgradesViewModel _upgradesViewModel;
        [SerializeField] private ProjectileView _projectilePrefab;
        [SerializeField] private Transform _projectileParent;
        [SerializeField] private Transform _rangeTranform;

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

            _rangeTranform.localScale = Vector2.one * _range * 2;
        }

        private void Start()
        {
            StartCoroutine(ShootCoroutine());
        }

        private IEnumerator ShootCoroutine()
        {
            while (true)
            {
                if (_charactersViewModel.Enemies.Count == 0)
                {
                    yield return new WaitForFixedUpdate();
                    continue;
                }

                if (_charactersViewModel.Enemies.Any((x) => (Vector3.Distance(x.position, transform.position) <= _range) && x.gameObject.activeInHierarchy))
                {
                    var item = Instantiate(_projectilePrefab, _projectileParent);
                    item.transform.position = transform.position;
                    item.Init(_damage);

                    yield return new WaitForSeconds(_reloadSpeed);

                    continue;
                }

                yield return new WaitForFixedUpdate();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
            //SceneManager.LoadScene(0);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, _range);
        }
    }
}
