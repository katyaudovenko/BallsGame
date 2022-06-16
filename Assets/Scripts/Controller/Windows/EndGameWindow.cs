﻿using System;
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
        private Action _onRestart;

        public override void OnInitialize()
        {
            base.OnInitialize();
            restartButton.onClick.AddListener(OnClickRestartButton);
            goToMenuButton.onClick.AddListener(OnClickGoToMenuButton);

            _scoreService = ServiceLocator.Instance.GetService<ScoreService>();
        }

        public override void OnSetup()
        {
            base.OnSetup();
            scoreText.text = _scoreService.Score.ToString();
            recordText.text = _scoreService.BestScore.ToString();
        }

        public void Setup(Action onRestart) => 
            _onRestart = onRestart;

        private void OnClickRestartButton()
        {
            _onRestart?.Invoke();
            OnClose.Invoke(typeof(EndGameWindow), this);
        }

        private void OnClickGoToMenuButton()
        {
            OnClose.Invoke(typeof(EndGameWindow), this);
        }
    }
}