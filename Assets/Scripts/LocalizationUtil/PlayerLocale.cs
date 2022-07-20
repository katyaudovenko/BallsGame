using UnityEngine;

namespace LocalizationUtil
{
    public class PlayerLocale
    {
        private const string PlayerLocaleKey = "playerLocale";
        
        private string _locale;

        public PlayerLocale() => 
            _locale = PlayerPrefs.GetString(PlayerLocaleKey, "en");

        public string GetLocale() => _locale;

        public void SetLocale(string locale)
        {
            _locale = locale;
            PlayerPrefs.SetString(PlayerLocaleKey, _locale);
            PlayerPrefs.Save();
        }
    }
}