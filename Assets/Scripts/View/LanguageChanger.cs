using LocalizationUtil;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class LanguageChanger : MonoBehaviour
    {
        [SerializeField] private Button belarusianLanguage; 
        [SerializeField] private Button englishLanguage;

        private void Awake()
        {
            belarusianLanguage.onClick.AddListener(() => SetLanguage(SystemLanguage.Belarusian));
            englishLanguage.onClick.AddListener(() => SetLanguage(SystemLanguage.English));
        }

        private void OnDestroy()
        {
            belarusianLanguage.onClick.RemoveAllListeners();
            englishLanguage.onClick.RemoveAllListeners();
        }
        
        private void SetLanguage(SystemLanguage language)
        {
            Localization.Instance.SetLanguage(language);
        }
    }
}