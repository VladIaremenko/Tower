using UnityEngine;

namespace Tower.Assets._Scripts._Currency
{
    [CreateAssetMenu(fileName = "CurrencyManagerSO", menuName = "SO/Currency/CurrencyManagerSO", order = 1)]
    public class CurrencyManagerSO : ScriptableObject
    {
        private int _currentCurrency = 0;
    }
}


