using System;
using Services;
using TMPro;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CoinsView : MonoBehaviour
    {
        private TextMeshProUGUI _coinsText;
        private CoinsService _coins;

        private void Start()
        {
            _coins = ServiceLocator.Instance.GetService<CoinsService>();
            _coinsText = GetComponent<TextMeshProUGUI>();
            _coins.OnCoinAdd += UpdateCoinsCount;
        }

        private void UpdateCoinsCount()
        {
            _coinsText.text = _coins.CoinsCount.ToString();
        }
    }
}