using System;
using Services;
using Services.ServiceLocator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controller.Windows
{
    public class EndGameWindow : BaseWindow
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button goToMenuButton;
        [SerializeField] private TextMeshProUGUI recordText;
        [SerializeField] private TextMeshProUGUI scoreText;

        private ScoreService _scoreService;
        private ProgressService _progressService;
        private Action _onRestart;
        private Action _onExit;

        public override void OnInitialize()
        {
            base.OnInitialize();
            restartButton.onClick.AddListener(OnClickRestartButton);
            goToMenuButton.onClick.AddListener(OnClickGoToMenuButton);

            _progressService = ServiceLocator.Instance.GetService<ProgressService>();
            _scoreService = ServiceLocator.Instance.GetService<ScoreService>();
        }

        public override void OnSetup()
        {
            base.OnSetup();
            scoreText.text = _scoreService.Score.ToString();
            recordText.text = _progressService.Progress.bestScore.ToString();
        }

        public void Setup(Action onRestart, Action onExit)
        {
            _onExit = onExit;
            _onRestart = onRestart;
        }

        private void OnClickRestartButton()
        {
            _onRestart?.Invoke();
            OnClose.Invoke(typeof(EndGameWindow), this);
        }

        private void OnClickGoToMenuButton()
        {
            _onExit?.Invoke();
            OnClose.Invoke(typeof(EndGameWindow), this);
        }
    }
}