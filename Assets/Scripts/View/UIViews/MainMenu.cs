using Controller;
using Services;
using Services.ServiceLocator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View.UIViews
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button play;
        [SerializeField] private TextMeshProUGUI bestScore;
        private ProgressService _progressService;
        private void Awake()
        {
            play.onClick.AddListener(PlayGame);
            _progressService = ServiceLocator.Instance.GetService<ProgressService>();
            
            UpdateBestScore();
        }

        private void UpdateBestScore() => 
            bestScore.text = _progressService.Progress.bestScore.ToString();

        private void PlayGame() => 
            GlobalEventManager.OnMainMenuPlayClick();
    }
}
