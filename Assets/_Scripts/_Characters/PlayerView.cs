using System.Collections;
using Tower.Assets._Scripts._Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tower.Assets._Scripts._Characters
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private CharactersViewModel _charactersViewModel;
        [SerializeField] private GameObject _projectilePrefab;

        private void Awake()
        {
            _charactersViewModel.Player = transform;
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

                var item = Instantiate(_projectilePrefab, transform);
                item.transform.position = transform.position;
                yield return new WaitForSeconds(1);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
            //SceneManager.LoadScene(0);
        }
    }
}
