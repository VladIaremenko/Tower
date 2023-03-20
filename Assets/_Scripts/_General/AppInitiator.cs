﻿using Tower.Assets._Scripts._Currency;
using Tower.Assets._Scripts._Storage;
using Tower.Assets._Scripts._Upgrades;
using Tower.Assets._Scripts._Wave;
using UnityEngine;

namespace Tower.Assets._Scripts._General
{
    public class AppInitiator : MonoBehaviour
    {
        [SerializeField] private StorageSO _storageSO;
        [SerializeField] private WaveManagerSO _waveManager;
        [SerializeField] private UpgradesManagerSO _upgradesManagerSO;
        [SerializeField] private CurrencyManagerSO _currencyManagerSO;

        private void Start()
        {
            _waveManager.Init(this);
            _storageSO.Init();
            _upgradesManagerSO.Init();
            _currencyManagerSO.Init();
        }
    }
}


