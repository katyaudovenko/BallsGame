using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model.Infos.ShopInfo
{
    [CreateAssetMenu(menuName = "Create ShopInfo", fileName = "ShopInfo")]
    public class ShopInfo : ScriptableObject
    {
        [SerializeField] private List<ShopConfig> shopConfigs;
        public List<ShopConfig> ShopConfigs => shopConfigs;
        
        private Dictionary<ProductType, ShopConfig> _configsMap;
        
        public ShopConfig GetConfig(ProductType productType)
        {
            _configsMap ??= shopConfigs.ToDictionary(c => c.productType, c => c);

            if (_configsMap.TryGetValue(productType, out var config))
                return config;
            
            Debug.LogError($"Key not found {productType}");
            return null;
        }
    }
}