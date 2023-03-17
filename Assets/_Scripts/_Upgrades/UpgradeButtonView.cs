using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tower.Assets._Scripts._Upgrades
{
    public class UpgradeButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _text;

        public Button Button => _button;

        public void SetText(string text)
        {
            _text.text = text;
        }     
    }
}


