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
        public bool IsEffectActive { get; private set; }

        private void Update()
        {
            if (!IsEffectActive) 
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
            IsEffectActive = true;
            OnStartFreeze?.Invoke();
        }

        private void EndFreeze()
        {
            IsEffectActive = false;
            OnEndFreeze?.Invoke();
        }
       
    }
}