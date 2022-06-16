using System;
using Controller.Pool;
using UnityEngine;

namespace Controller.Windows
{
    [RequireComponent(typeof(WindowAnimator))]
    public abstract class BaseWindow : MonoBehaviour, IPoolBehaviour
    {
        public Action<Type, BaseWindow> OnClose;
        
        private WindowAnimator _windowAnimator;
        private RectTransform _rectTransform;

        public RectTransform RectTransform
        {
            get
            {
                if (_rectTransform == null && !TryGetComponent(out _rectTransform))
                {
                    Debug.LogError("Object has not got link");
                }
                return _rectTransform;
            }
        }

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