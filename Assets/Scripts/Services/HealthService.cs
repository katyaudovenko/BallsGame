using System;

namespace Services
{
    public class HealthService: IService
    {
        public event Action<int> OnDamage;
        public int HealthCount { get; private set; }
        public HealthService(int healthCount)
        {
            HealthCount = healthCount;
        }
        
        public void Damage(int damage)
        {
            HealthCount -= damage;
            OnDamage?.Invoke(HealthCount);
            if (HealthCount <= 0)
                HealthCount = 0;
        }
    }
}