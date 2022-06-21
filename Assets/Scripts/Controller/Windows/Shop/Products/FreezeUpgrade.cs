using Model.Infos.ShopInfo;
using Services;
using UnityEngine;
using View.UIViews;

namespace Controller.Windows.Shop.Products
{
    public class FreezeUpgrade : MonoBehaviour, IShopProduct
    {
        [SerializeField] private ProductType productType;
        
        private ProductView _productView;
        private ShopConfig _shopConfig;
        private ProgressService _progressService;
        private CoinsService _coinsService;
        
        public void Initialize(ShopInfo shopInfo, ProgressService progressService, CoinsService coinsService)
        {
            _productView = GetComponent<ProductView>();
            
            _shopConfig = shopInfo.GetConfig(productType);
            _progressService = progressService;
            _coinsService = coinsService;
        }

        public void Setup() => 
            UpdateView();

        private void UpdateView()
        {
            var playerStats = _progressService.Progress.playerStats;
            var cost = playerStats.freezeUpgradeCycle * _shopConfig.cost;
            _productView.SetupView(_shopConfig.productName, cost.ToString(), OnClickBuyButton);
        }

        private void OnClickBuyButton()
        {
            var playerStats = _progressService.Progress.playerStats;
            var cost = playerStats.freezeUpgradeCycle * _shopConfig.cost;
            if (!_coinsService.SpendCoins(cost)) return;
            
            playerStats.freezeTimeModificator += _shopConfig.increaseValue;
            playerStats.freezeUpgradeCycle++; 
            UpdateView();
        }
        
    }
}