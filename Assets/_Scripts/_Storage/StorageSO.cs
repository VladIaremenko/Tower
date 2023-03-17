using Newtonsoft.Json;
using System.Collections.Generic;
using Tower.Assets._Scripts._General;
using Tower.Assets._Scripts._Misc;
using UnityEngine;

namespace Tower.Assets._Scripts._Storage
{
    [CreateAssetMenu(fileName = "StorageSO", menuName = "SO/Storage/StorageSO", order = 1)]
    public class StorageSO : ScriptableObject
    {
        [SerializeField] private float _startBalance;

        private static readonly string UpgradesDataKey = "UpgradesDataKey";
        private static readonly string BalanceKey = "BalanceKey";

        public void Init()
        {
            var json = PlayerPrefs.GetString(UpgradesDataKey, string.Empty);

            if (string.IsNullOrEmpty(json))
            {
                _levelStateData = new UpgradesData(new List<int>() { 0, 0, 0 });
            }
            else
            {
                _levelStateData = JsonConvert.DeserializeObject<UpgradesData>(json);
            }

            _balance = PlayerPrefs.GetFloat(BalanceKey, _startBalance);
        }

        private UpgradesData _levelStateData;

        public UpgradesData UserDataContainer
        {
            get { return _levelStateData; }
            set
            {
                PlayerPrefs.SetString(UpgradesDataKey, JsonConvert.SerializeObject(value));
                _levelStateData = value;
            }
        }

        private float _balance;

        public float Balance
        {
            get { return _balance; }
            set
            {
                PlayerPrefs.SetFloat(BalanceKey, value);
                _balance = value;
            }
        }
    }
}


