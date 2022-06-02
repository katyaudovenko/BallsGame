using System.Collections.Generic;
using System.Linq;
using Controller.SpawnLogic;
using UnityEngine;

namespace Model.Infos.SpawnInfo
{
    [CreateAssetMenu(fileName = "CoinSpawnInfo", menuName = "GamePlay/New CoinSpawnInfo")]
    public class CoinSpawnContainer : ScriptableObject
    {
        [SerializeField] private CoinSpawnConfig[] coinsInfo;
        
        private Dictionary<BallType, CoinSpawnConfig> _configsMap;
        
        public CoinSpawnConfig GetConfig(BallType ballType)
        {
            if (_configsMap == null)
            {
                _configsMap = coinsInfo.ToDictionary(c=> c.BallType, c => c);
            }

            if (_configsMap.TryGetValue(ballType, out var config))
                return config;
            
            Debug.LogError($"Key not found {ballType}");
            return null;
        }
    }
}