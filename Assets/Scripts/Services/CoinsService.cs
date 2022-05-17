using System;

namespace Services
{
    public class CoinsService : IService
    {
        public event Action OnChanged;
        public int Coins { get; private set; }

        public void AddCoin(int value)
        {
            Coins += value;
            OnChanged?.Invoke();
        }
    }
}