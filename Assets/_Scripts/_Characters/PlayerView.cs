using System.Collections;
using Tower.Assets._Scripts._Enemy;
using UnityEngine;

namespace Tower.Assets._Scripts._Characters
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private CharactersViewModel _charactersViewModel;

        private void Awake()
        {
            _charactersViewModel.Player = transform;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
