using System;
using Controller.Pool;
using Controller.Windows;
using Services.ServiceLocator;
using UnityEngine;

namespace Services
{
    public class WindowsManager : MonoBehaviour, IService
    {
        [SerializeField] private PoolContainer pool;
        
        public void Initialize()
        {
            pool.CreatePools();
        }

        public T OpenWindow<T>() where T : BaseWindow
        {
            var window = pool.GetFreeElement<T>();
            SetWindowPosition(window);
            window.transform.SetParent(transform, false);
            window.OpenWindow();
            window.OnClose += CloseWindow;
            return window;
        }

        public void CloseWindow<T>(T window) where T : BaseWindow => 
            window.CloseWindow(() => pool.ReturnElement(window));

        private void CloseWindow(Type type, BaseWindow window) => 
            window.CloseWindow(() => pool.ReturnElement(type, window));

        private void SetWindowPosition<T>(T window) where T : BaseWindow => 
            window.transform.position = Vector3.zero;
    }
}