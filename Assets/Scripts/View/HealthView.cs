using System.Collections.Generic;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private List<Image> lives;
        private HealthService _healthService;
        private void Start()
        {
            _healthService = ServiceLocator.Instance.GetService<HealthService>();
            _healthService.OnChanged += UpdateLivesCount;
        }

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