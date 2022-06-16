using System;
using Services.ServiceLocator;

namespace Services
{
    public class ScoreService : IService
    {
        public event Action OnChanged; 
        public int Score { get; private set; }
        public int BestScore { get; private set; }

        private readonly ProgressService _progressService;

        public ScoreService(ProgressService progressService)
        {
            _progressService = progressService;
            _progressService.OnDataLoad += UpdateScore;
        }

        private void UpdateScore() => 
            BestScore = _progressService.Progress.bestScore;

        public void AddScore(int score)
        {
            Score += score;
            if (Score > _progressService.Progress.bestScore) 
                _progressService.Progress.bestScore = Score;
            OnChanged?.Invoke();
        }
    }
}