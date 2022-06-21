using Services;
using Services.ServiceLocator;
using TMPro;
using UnityEngine;

namespace View.UIViews
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreView : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;
        private ScoreService _scoreService;
        private void Awake()
        {
            _scoreService = ServiceLocator.Instance.GetService<ScoreService>();
            _scoreText = GetComponent<TextMeshProUGUI>();
            _scoreService.OnChanged += UpdateScoreText;
        }

        private void OnDestroy() => 
            _scoreService.OnChanged -= UpdateScoreText;

        private void UpdateScoreText()
        {
            _scoreText.text = _scoreService.Score.ToString();
        }
    }
}