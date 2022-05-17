using Services;
using TMPro;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreView : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;
        private ScoreService _scoreService;
        private void Start()
        {
            _scoreService = ServiceLocator.Instance.GetService<ScoreService>();
            _scoreText = GetComponent<TextMeshProUGUI>();
            _scoreService.OnAddScore += UpdateScoreText;
        }

        private void UpdateScoreText()
        {
            _scoreText.text = _scoreService.Score.ToString();
        }
    }
}