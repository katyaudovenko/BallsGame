using System;
using Controller.Pool;
using UnityEngine;

namespace Controller.Windows
{
    public abstract class BaseWindow : MonoBehaviour, IPoolBehaviour
    {
        public event Action<Type, BaseWindow> OnClose;
        
        private WindowAnimator _windowAnimator;

        public virtual void OnInitialize() => 
            _windowAnimator = GetComponent<WindowAnimator>();

        public virtual void OnSetup() { }

        public virtual void OnReset() { }

        public void OpenWindow() => 
            _windowAnimator.AppearAnimation();

        public void CloseWindow(Action onComplete) => 
            _windowAnimator.HideAnimation(onComplete);
    }
}