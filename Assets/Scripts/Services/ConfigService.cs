using UnityEngine;

namespace Services
{
    public class ConfigService : IService
    {
        private const string ConfigPath = "Config";
        
        private readonly ScriptableObject[] _configs;

        public ConfigService()
        {
            _configs = Resources.LoadAll<ScriptableObject>(ConfigPath);
        }
        
        public T GetConfig<T>() where T : ScriptableObject
        {
            foreach (var config in _configs)
            {
                if (config is T scriptableObject)
                {
                    return scriptableObject;
                }
            }

            return null;
        }
    }
}