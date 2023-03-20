using System;
using TMPro;
using Tower.Assets._Scripts._General;
using Tower.Assets._Scripts._Wave;
using UnityEngine;
using UnityEngine.UI;

namespace Tower.Assets._Scripts._UI
{
    public class WavePanelView : MonoBehaviour
    {
        [SerializeField] private WaveViewModel _waveViewModel;
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _text;

        private void OnEnable()
        {
            _waveViewModel.WaveProgress.AddListener(UpdateView);
        }

        private void OnDisable()
        {
            _waveViewModel.WaveProgress.RemoveListener(UpdateView);
        }

        private void UpdateView(WaveViewData data)
        {
            _slider.maxValue = data.MaxValue;
            _slider.value = data.Progress;
            _text.text = $"Wave {data.WaveNumber + 1}";
        }
    }
}


