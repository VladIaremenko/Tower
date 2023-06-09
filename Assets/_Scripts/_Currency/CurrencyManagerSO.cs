﻿using System.Diagnostics;
using Tower.Assets._Scripts._Storage;
using UnityEngine;

namespace Tower.Assets._Scripts._Currency
{
    [CreateAssetMenu(fileName = "CurrencyManagerSO", menuName = "SO/Currency/CurrencyManagerSO", order = 1)]
    public class CurrencyManagerSO : ScriptableObject
    {
        [SerializeField] private StorageSO _storage;
        [SerializeField] private CurrencyViewModel _currencyViewModel;

        public bool TryBuyItem(float price)
        {
            if (_storage.Balance - price >= 0)
            {
                _storage.Balance -= price;
                RefreshView();
                return true;
            }

            return false;
        }

        private void OnEnable()
        {
            _currencyViewModel.OnEnemyDestroyedEvent += HandlePlayerDestroyed;
        }

        private void OnDisable()
        {
            _currencyViewModel.OnEnemyDestroyedEvent -= HandlePlayerDestroyed;
        }

        private void HandlePlayerDestroyed()
        {
            _storage.Balance += 10;
            RefreshView();
        }

        public void Init()
        {
            RefreshView();
        }

        private void RefreshView()
        {
            _currencyViewModel.CurrentBalance.Value = _storage.Balance;
        }
    }
}