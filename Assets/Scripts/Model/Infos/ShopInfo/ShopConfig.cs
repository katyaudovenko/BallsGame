using System;

namespace Model.Infos.ShopInfo
{
    [Serializable]
    public class ShopConfig
    {
        public ProductType productType;
        public string productName;
        
        public int cost;
        public float increaseValue;
    }
}