using Model.Infos;
using Services;
using Services.ServiceLocator;
using UnityEngine;
using View.Balls.Abstract;

namespace View.DestroyZone
{
    public class DestroyZone : MonoBehaviour
    {
        private HealthService _healthService;
        private HealthInfo _healthInfo;
        

        private void Start()
        {
            _healthInfo = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<HealthInfo>();
            _healthService = ServiceLocator.Instance.GetService<HealthService>();
        }

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            DestroyBall(otherCollider);
            DecreaseHealth();
        }

        private static void DestroyBall(Collider2D ballCollider) => ballCollider.GetComponent<Ball>().DestroyBallByZone();

        private void DecreaseHealth()
        {
            _healthService.Receive(_healthInfo.Damage);
            Debug.Log(_healthService.Health);
        }
        
    }
}
