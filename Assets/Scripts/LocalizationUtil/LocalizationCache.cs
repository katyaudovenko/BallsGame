using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LocalizationUtil
{
    public class LocalizationCache
    {
        private Dictionary<string, Dictionary<string, string>> _translations;
        
        public LocalizationCache(LocalizationInfo localizationInfo)
        {
            Load(localizationInfo.translations);
        }

        public string GetTranslation(string locale, string translationKey)
        {
            if (!_translations.ContainsKey(locale))
            {
                Debug.LogError($"Translation's map doesn't contains key locale {locale}");
                return translationKey;
            }
            
            if (!_translations[locale].ContainsKey(translationKey))
            {
                Debug.LogError($"Translation's map doesn't contains translation key {translationKey} by {locale}");
                return translationKey;
            }
            
            return _translations[locale][translationKey];
        }
        
        private void Load(List<TextAsset> translations)
        {
            _translations = new Dictionary<string, Dictionary<string, string>>();

            foreach (var textAsset in translations)
            {
                var locale = textAsset.name;
                var json = textAsset.text;
                var data = JsonUtility.FromJson<TranslationDataArray>(json);

                var localeTranslations = data.data.
                    ToDictionary(d => d.key, d => d.value);
                
                _translations.Add(locale, localeTranslations);
            }
        }
    }
}