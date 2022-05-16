using System;

namespace Services
{
    public class CoinsService : IService
    {
        public event Action OnCoinAdd;
        public int CoinsCount { get; private set; }

        public void AddCoin(int coinsCount)
        {
            CoinsCount += coinsCount;
            OnCoinAdd?.Invoke();
        }
    }
}