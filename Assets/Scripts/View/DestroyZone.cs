using Services;
using UnityEngine;
using View.Balls;

namespace View
{
    public class DestroyZone : MonoBehaviour
    {
        [SerializeField] private HealthView healthView;
        
        private HealthService _healthService;
        private void Start()
        {
            _healthService = ServiceLocator.Instance.GetService<HealthService>();
        }

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            DestroyBall(otherCollider);
            DecreaseHealth();
            UpdateLivesCount();
        }

        private static void DestroyBall(Collider2D ballCollider) => ballCollider.GetComponent<Ball>().DestroyBall();

        private void DecreaseHealth()
        {
            _healthService.Damage(1);
            Debug.Log(_healthService.HealthCount);
        }

        private void UpdateLivesCount() => healthView.UpdateLivesCount(_healthService.HealthCount);
    }
}
