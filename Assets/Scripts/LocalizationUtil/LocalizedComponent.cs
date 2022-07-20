using TMPro;
using UnityEngine;

namespace LocalizationUtil
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizedComponent : MonoBehaviour
    {
        [SerializeField] private string translationKey;

        private TextMeshProUGUI _text;

        private TextMeshProUGUI TextComponent
        {
            get
            {
                if (_text == null) 
                    _text = GetComponent<TextMeshProUGUI>();

                return _text;
            }
        }

        private void Awake() => 
            Localization.Instance.OnLocalChanged += UpdateText;

        private void OnEnable() => 
            UpdateText();

        private void OnDestroy() => 
            Localization.Instance.OnLocalChanged -= UpdateText;

        private void UpdateText() => 
            TextComponent.text = Localization.Instance.GetTranslation(translationKey);
    }
}