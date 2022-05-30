using System.Collections.Generic;
using System.Linq;
using Controller.SpawnLogic;
using UnityEngine;

namespace Model.Infos
{
    [CreateAssetMenu(fileName = "CoinSpawnInfo", menuName = "GamePlay/New CoinSpawnInfo")]
    public class CoinSpawnInfo : ScriptableObject
    {
        [SerializeField] private CoinSpawnConfig[] coinsInfo;
        private Dictionary<BallType, CoinSpawnConfig> _configsMap;
        
        public CoinSpawnConfig GetConfig(BallType ballType)
        {
            if (_configsMap == null)
            {
                _configsMap = coinsInfo.ToDictionary(c=> c.ballType, c => c);
            }

            return _configsMap[ballType];
        }
    }
}