using System;
using System.Collections.Generic;
using System.Linq;
using Services.ServiceLocator;
using UnityEngine;

namespace Services
{
    public class ConfigService : IService
    {
        private const string ConfigPath = "Config";
        
        private readonly Dictionary<Type, ScriptableObject> _configs;
        
        public ConfigService()
        {
            _configs = Resources
                .LoadAll<ScriptableObject>(ConfigPath)
                .ToDictionary(so=> so.GetType(), so=>so);
        }
        
        public T GetConfig<T>() where T : ScriptableObject
        {
            if (_configs.TryGetValue(typeof(T), out var config))
                return config as T;

            return null;
        }
    }
}