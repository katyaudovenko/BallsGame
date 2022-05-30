using Services;
using Services.ServiceLocator;
using TMPro;
using UnityEngine;

namespace View.UIViews
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
            _coins.OnChanged += UpdateCoinsCount;
            UpdateCoinsCount();
        }

        private void UpdateCoinsCount()
        {
            _coinsText.text = _coins.Coins.ToString();
        }
    }
}