using Extensions;
using Model;
using Model.Infos;
using Services;
using Services.ServiceLocator;
using UnityEngine;

namespace Controller.SpawnLogic
{
    public class ProbabilityCoinSpawn : MonoBehaviour
    {
        private const float FullProgress = 100f;

        private CoinSpawnConfig _coinSpawn;
        private CoinsService _coinsService;

        public void Initialize(BallType type)
        {
            _coinSpawn = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<CoinSpawnInfo>().GetConfig(type);
            _coinsService = ServiceLocator.Instance.GetService<CoinsService>();
        }

        public void SpawnCoin()
        {
            if(RandomExtension.CheckProbability(_coinSpawn.chance,FullProgress))
                _coinsService.AddCoin(_coinSpawn.costBall);
        }
        
    }
}