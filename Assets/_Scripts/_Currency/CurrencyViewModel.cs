using System;
using Tower.Assets._Scripts._Misc;
using UnityEngine;

namespace Tower.Assets._Scripts._Currency
{
    [CreateAssetMenu(fileName = "CurrencyViewModel", menuName = "SO/Currency/CurrencyViewModel ", order = 1)]
    public class CurrencyViewModel : ScriptableObject
    {
        public ObservableVariable<float> CurrentBalance = new ObservableVariable<float>();
        public event Action OnEnemyDestroyedEvent = () => { };

        public void HandleEnemyIsDestroyed()
        {
            OnEnemyDestroyedEvent.Invoke();
        }
    }
}


