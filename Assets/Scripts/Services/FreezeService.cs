using System;
using UnityEngine;

namespace Services
{
    public class FreezeService : MonoBehaviour, IService
    {
        public event Action OnStartFreeze;
        public event Action OnEndFreeze;
        
        [SerializeField] private float freezeTime = 2;

        private float _currentTime;
        private bool _isEffectActive;

        private void Update()
        {
            if (!_isEffectActive) 
                return;
            
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                EndFreeze();
            }
        }

        public void StartFreeze()
        {
            _currentTime = freezeTime;
            _isEffectActive = true;
            OnStartFreeze?.Invoke();
        }

        private void EndFreeze()
        {
            _isEffectActive = false;
            OnEndFreeze?.Invoke();
        }
       
    }
}