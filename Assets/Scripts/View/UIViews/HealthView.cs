using System.Collections.Generic;
using Services;
using Services.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace View.UIViews
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private List<Image> lives;
        private HealthService _healthService;
        
        private void Awake()
        {
            _healthService = ServiceLocator.Instance.GetService<HealthService>();
            _healthService.OnChanged += UpdateLivesCount;
        }

        private void OnDestroy() => 
            _healthService.OnChanged -= UpdateLivesCount;

        private void UpdateLivesCount()
        {
            var countLives = _healthService.Health;
            for (var i = 0; i < lives.Count; i++)
            {
                var isActive = i < countLives;
                lives[i].gameObject.SetActive(isActive);
            }
        }
    }
}