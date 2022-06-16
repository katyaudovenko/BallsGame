using UnityEngine;
using UnityEngine.UI;

namespace Controller.Windows
{
    public class TutorialWindow : BaseWindow
    {
        [SerializeField] private Button okButton;
        
        public override void OnInitialize()
        {
            base.OnInitialize();
            okButton.onClick.AddListener(OnClickOkButton);
        }

        private void OnClickOkButton()
        {
            OnClose.Invoke(typeof(TutorialWindow), this);
        }
    }
}