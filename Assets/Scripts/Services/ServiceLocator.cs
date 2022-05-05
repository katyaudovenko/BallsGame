using System;
using System.Collections.Generic;

namespace Services
{
    public class ServiceLocator : IServiceLocator<IService>
    {
        private static ServiceLocator _instance;
        public static ServiceLocator Instance => _instance ??= new ServiceLocator();
        
        private readonly Dictionary<Type, IService> _services;

        private ServiceLocator()
        {
            _services = new Dictionary<Type, IService>();
        }
        public T Register<T>(T newService) where T : IService
        {
            var type = typeof(T);
            if (_services.ContainsKey(type))
            {
                //Debug.LogWarning($"Service map contains {type}");
                return (T)_services[type];
            }
            _services.Add(type, newService);
            return newService;
        }

        public void Unregister<T>(T removeService) where T : IService
        {
            var type = typeof(T);
            _services.Remove(type);
        }

        public T GetService<T>() where T : IService
        {
            var type = typeof(T);
            if (_services.ContainsKey(type))
            {
                return (T)_services[type];
            }

            throw new Exception();
        }
    }
}