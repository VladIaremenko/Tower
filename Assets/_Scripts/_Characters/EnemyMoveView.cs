using Tower.Assets._Scripts._Enemy;
using UnityEngine;

namespace Tower.Assets._Scripts._Characters
{
    public class EnemyMoveView : MonoBehaviour
    {
        [SerializeField] private CharactersViewModel _charactersViewModel;
        [SerializeField] private float _speed;

        private void FixedUpdate()
        {
            transform.position = Vector2.MoveTowards(transform.position, _charactersViewModel.Player.position, _speed * Time.fixedDeltaTime);
        }
    }
}