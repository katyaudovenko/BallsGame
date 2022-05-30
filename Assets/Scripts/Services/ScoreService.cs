using System;
using Services.ServiceLocator;

namespace Services
{
    public class ScoreService : IService
    {
        public event Action OnAddScore; 
        public int Score { get; private set; }
        
        public void AddScore(int score)
        {
            Score += score;
            OnAddScore?.Invoke();
        }
    }
}