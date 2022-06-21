using Controller;
using Controller.Windows.Shop;
using Services;
using Services.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace View.UIViews.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button play;
        [SerializeField] private Button shopButton;

        private WindowsManager _windowsManager;
        private void Awake()
        {
            _windowsManager = ServiceLocator.Instance.GetService<WindowsManager>();
            
            play.onClick.AddListener(PlayGame);
            shopButton.onClick.AddListener(OpenShop);
            
        }
        
        private void PlayGame() => 
            GlobalEventManager.OnMainMenuPlayClick();

        private void OpenShop() =>
            _windowsManager.OpenWindow<ShopWindow>();
    }
}
