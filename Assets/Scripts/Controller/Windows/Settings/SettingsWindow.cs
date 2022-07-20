using UnityEngine;
using UnityEngine.UI;

namespace Controller.Windows.Settings
{
    public class SettingsWindow : BaseWindow
    {
        [SerializeField] private Button closeButton;

        public override void OnInitialize()
        {
            base.OnInitialize();
            AddButtonListeners();
        }

        private void AddButtonListeners() => 
            closeButton.onClick.AddListener(OnClickCloseButton);
        
        private void OnClickCloseButton() => 
            OnClose.Invoke(typeof(SettingsWindow), this);
    }
}