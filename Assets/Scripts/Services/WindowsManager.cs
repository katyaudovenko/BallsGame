using System;
using Controller.Pool;
using Controller.Windows;
using Services.ServiceLocator;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services
{
    public class WindowsManager : IService
    {
        private const string PoolContainerPath = "Prefabs/WindowsPool";
        
        private PoolContainer _pool;
        
        public void Initialize()
        {
            var prefab = Resources.Load<PoolContainer>(PoolContainerPath);
            _pool = Object.Instantiate(prefab);
            _pool.CreatePools();
        }

        public void OpenWindow<T>() where T : BaseWindow
        {
            var window = _pool.GetFreeElement<T>();
            window.OpenWindow();
            window.OnClose += CloseWindow;
        }

        public void CloseWindow<T>(T window) where T : BaseWindow => 
            window.CloseWindow(() => _pool.ReturnElement(window));

        private void CloseWindow(Type type, BaseWindow window) => 
            window.CloseWindow(() => _pool.ReturnElement(type, window));
    }
}