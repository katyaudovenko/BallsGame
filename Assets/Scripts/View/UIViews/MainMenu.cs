using Controller;
using Controller.Windows.Shop;
using Services;
using Services.ServiceLocator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View.UIViews
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button play;
        [SerializeField] private TextMeshProUGUI bestScore;
        [SerializeField] private Button shopButton;

        private WindowsManager _windowsManager;
        private ProgressService _progressService;
        private void Awake()
        {
            _progressService = ServiceLocator.Instance.GetService<ProgressService>();
            _windowsManager = ServiceLocator.Instance.GetService<WindowsManager>();
            
            play.onClick.AddListener(PlayGame);
            shopButton.onClick.AddListener(OpenShop);
            
            UpdateBestScore();
        }

        private void UpdateBestScore() => 
            bestScore.text = _progressService.Progress.bestScore.ToString();

        private void PlayGame() => 
            GlobalEventManager.OnMainMenuPlayClick();

        private void OpenShop() =>
            _windowsManager.OpenWindow<ShopWindow>();
    }
}
