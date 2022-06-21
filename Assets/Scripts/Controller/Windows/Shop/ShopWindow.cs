using System.Collections.Generic;
using System.Linq;
using Controller.Windows.Shop.Products;
using Model.Infos.ShopInfo;
using Services;
using Services.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace Controller.Windows.Shop
{
    public class ShopWindow : BaseWindow
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private List<GameObject> products;

        private List<IShopProduct> _products;
        private ShopInfo _shopInfo;
        private CoinsService _coinsService;
        private ProgressService _progressService;
        
        public override void OnInitialize()
        {
            base.OnInitialize();
            InitializeServices();
            InitializeProducts();
            AddButtonListeners();
        }

        public override void OnSetup()
        {
            base.OnSetup();
            foreach (var product in _products) 
                product.Setup();
        }

        private void InitializeServices()
        {
            _shopInfo = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<ShopInfo>();
            _coinsService = ServiceLocator.Instance.GetService<CoinsService>();
            _progressService = ServiceLocator.Instance.GetService<ProgressService>();
        }

        private void InitializeProducts()
        {
            _products = products.Select(p => p.GetComponent<IShopProduct>()).ToList();
            foreach (var product in _products) 
                product.Initialize(_shopInfo, _progressService, _coinsService);
        }

        private void AddButtonListeners() => 
            closeButton.onClick.AddListener(OnClickCloseButton);
        
        private void OnClickCloseButton() => 
            OnClose.Invoke(typeof(ShopWindow), this);
    }
}