using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tower.Assets._Scripts._Upgrades
{
    public class UpgradeButtonView : MonoBehaviour
    {
        [SerializeField] private UpgradesViewModel _upgradesViewModel;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _text;

        public Button Button => _button;

        private void Awake()
        {
            _button.onClick.AddListener(HancleClick);
        }

        private void HancleClick()
        {
            _upgradesViewModel.HandleUpgradeClick(transform.GetSiblingIndex());
        }

        public void SetText(string text)
        {
            _text.text = text;
        }     
    }
}


