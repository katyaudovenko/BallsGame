using UnityEngine;

namespace LocalizationUtil
{
    public static class Consts
    {
        public static string GetLocale(SystemLanguage language)
        {
            switch (language)
            {
                case SystemLanguage.Belarusian:
                    return "be";
                
                default: 
                    return "en";
            }
        }
    }
}