using System;
using Controller;
using Model.Infos;
using Services.ServiceLocator;

namespace Services
{
    public class HealthService: IService
    {
        public event Action OnChanged;
        
        private readonly HealthInfo _healthInfo;
        
        public int Health { get; private set; }
        
        public HealthService(HealthInfo health)
        {
            _healthInfo = health;
            Health = _healthInfo.HealthCount;
            GlobalEventManager.StartGame += ResetHealth;
        }

        private void ResetHealth()
        {
            Health = _healthInfo.HealthCount;
            OnChanged?.Invoke();
        }

        public void Receive(int value)
        {
            Health -= value;
            OnChanged?.Invoke();
            
            if (Health < 0)
                Health = 0;
        }
    }
}