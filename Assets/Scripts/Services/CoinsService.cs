using System;
using Services.ServiceLocator;

namespace Services
{
    public class CoinsService : IService
    {
        public event Action OnChanged;
        public int Coins { get; private set; }

        private readonly ProgressService _progress;
        public CoinsService(ProgressService progressService)
        {
            _progress = progressService;
            _progress.OnDataLoad += UpdateCoins;
        }

        private void UpdateCoins()
        {
            Coins = _progress.Progress.Coins;
        }

        public void AddCoin(int value)
        {
            Coins += value;
            _progress.Progress.Coins = Coins;
            OnChanged?.Invoke();
        }
    }
}