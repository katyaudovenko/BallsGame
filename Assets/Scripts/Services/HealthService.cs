using System;
using Model.Infos;
using Services.ServiceLocator;

namespace Services
{
    public class HealthService: IService
    {
        public event Action OnChanged;
        public int Health { get; private set; }
        public HealthService(HealthInfo health)
        {
            Health = health.HealthCount;
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