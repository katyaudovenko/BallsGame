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
            Coins = _progress.Progress.coins;
        }

        public void AddCoin(int value)
        {
            Coins += value;
            _progress.Progress.coins = Coins;
            OnChanged?.Invoke();
        }

        public bool SpendCoins(int value)
        {
            if (!IsEnough(value)) return false;
            _progress.Progress.coins -= value;
            Coins = _progress.Progress.coins;
            OnChanged?.Invoke();
            return true;
        }

        private bool IsEnough(int value) => 
            _progress.Progress.coins >= value;
    }
}