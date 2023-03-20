using TMPro;
using UnityEngine;

namespace Tower.Assets._Scripts._Currency
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private CurrencyViewModel _currencyViewModel;

        private void OnEnable()
        {
            _currencyViewModel.CurrentBalance.AddListener(UpdateView);
        }

        private void OnDisable()
        {
            _currencyViewModel.CurrentBalance.RemoveListener(UpdateView);
        }

        private void UpdateView(float amount)
        {
            _text.text = $"{amount}$";
        }
    }
}


