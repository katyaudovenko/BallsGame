using System;
using UnityEngine;

namespace LocalizationUtil
{
    public class Localization : MonoBehaviour
    {
        private static bool _isInitialize;
        private static Localization _instance;

        public static Localization Instance
        {
            get
            {
                if (_instance != null)
                {
                    if (!_isInitialize) 
                        _instance.Initialize();
                    
                    return _instance;
                }

                var managers = FindObjectsOfType<Localization>();
                if (managers != null)
                {
                    if (managers.Length == 1)
                    {
                        _instance = managers[0];
                        DontDestroyOnLoad(_instance);
                        return _instance;
                    }

                    if (managers.Length > 1)
                    {
                        foreach (var manager in managers)
                            Destroy(manager.gameObject);
                    }
                }

                Debug.LogError("Singleton not found");
                return null;
            }
        }

        public event Action OnLocalChanged;

        [SerializeField] private LocalizationInfo localizationInfo;

        private LocalizationCache _cache;
        private PlayerLocale _playerLocale;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _cache = new LocalizationCache(localizationInfo);
            _playerLocale = new PlayerLocale();
            _isInitialize = true;
        }

        public void SetLanguage(SystemLanguage language)
        {
            var locale = Consts.GetLocale(language); 
            
            if(locale.Equals(_playerLocale.GetLocale())) 
                return;
            
            _playerLocale.SetLocale(locale);
            OnLocalChanged?.Invoke();
        }

        public string GetTranslation(string translationKey)
        {
            return _cache.GetTranslation(_playerLocale.GetLocale(), translationKey);
        }
    }
}