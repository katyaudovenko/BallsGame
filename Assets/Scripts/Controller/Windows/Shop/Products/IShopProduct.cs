using Model.Infos.ShopInfo;
using Services;

namespace Controller.Windows.Shop.Products
{
    public interface IShopProduct
    {
        void Initialize(ShopInfo shopInfo, ProgressService progressService, CoinsService coinsService);
        void Setup();
    }
}