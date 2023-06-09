﻿using Tower.Assets._Scripts._Currency;
using Tower.Assets._Scripts._Enemy;
using UnityEngine;

namespace Tower.Assets._Scripts._Characters
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private CharactersViewModel _charactersViewModel;
        [SerializeField] private CurrencyViewModel _currencyViewModel;
        [SerializeField] private float _speed;
        [SerializeField] private float _startHP;

        private float _currentHP;

        private void OnEnable()
        {
            _currentHP = _startHP;
        }

        public void TakeDamage(float damage)
        {
            _currentHP -= damage;

            if (_currentHP <= 0)
            {
                _currencyViewModel.HandleEnemyIsDestroyed();
                ObjectPooler.Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            transform.position = Vector2.MoveTowards(transform.position, _charactersViewModel.Player.position, _speed * Time.fixedDeltaTime);
        }
    }
}