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
        private CoinsService _coinsService;
        private ProgressService _progressService;
        private void Awake()
        {
            Initialize();

            _coinsService.OnChanged += UpdateCoinsCount;
            UpdateCoinsCount();
            UpdateCoinsOnStart();
        }

        private void OnDestroy() => 
            _coinsService.OnChanged -= UpdateCoinsCount;

        private void Initialize()
        {
            _coinsService = ServiceLocator.Instance.GetService<CoinsService>();
            _progressService = ServiceLocator.Instance.GetService<ProgressService>();
            _coinsText = GetComponent<TextMeshProUGUI>();
        }

        private void UpdateCoinsCount() => 
            _coinsText.text = _coinsService.Coins.ToString();

        private void UpdateCoinsOnStart() =>
            _coinsText.text = _progressService.Progress.coins.ToString();
    }
}