using System;

namespace Services
{
    public class HealthService: IService
    {
        public event Action OnHealthEnded;
        public int HealthCount { get; private set; }
        public HealthService(int healthCount)
        {
            HealthCount = healthCount;
        }
        
        public void Damage(int damage)
        {
            HealthCount -= damage;
            if (HealthCount <= 0)
            {
                HealthCount = 0;
                OnHealthEnded?.Invoke();
            }
        }
    }
}