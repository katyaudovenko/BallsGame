using Services;
using Services.ServiceLocator;
using TMPro;
using UnityEngine;

namespace View.UIViews.MainMenu
{
    public class BestScoreView : MonoBehaviour
    {
        private TextMeshProUGUI _bestScore;
        private ProgressService _progressService;
        private void Awake()
        {
            _bestScore = GetComponentInChildren<TextMeshProUGUI>();
            _progressService = ServiceLocator.Instance.GetService<ProgressService>();
            UpdateBestScore();
        }
        
        private void UpdateBestScore() => 
            _bestScore.text = _progressService.Progress.bestScore.ToString();
    }
}