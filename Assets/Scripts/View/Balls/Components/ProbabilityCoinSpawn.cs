using Controller.SpawnLogic;
using Extensions;
using Model.Infos.SpawnInfo;
using Services;
using Services.ServiceLocator;
using UnityEngine;
using View.Balls.Abstract;

namespace View.Balls.Components
{
    public class ProbabilityCoinSpawn : MonoBehaviour, IBallComponent
    {
        private const float FullProgress = 100f;

        [SerializeField] private BallType ballType;
        
        private CoinSpawnConfig _coinSpawn;
        private CoinsService _coinsService;

        public void OnInitialize()
        {
            _coinSpawn = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<CoinSpawnContainer>().GetConfig(ballType);
            _coinsService = ServiceLocator.Instance.GetService<CoinsService>();
        }

        public void OnSetup() { }

        public void OnReset() { }

        public void SpawnCoin()
        {
            if(RandomExtension.CheckProbability(_coinSpawn.Chance,FullProgress))
                _coinsService.AddCoin(_coinSpawn.CostBall);
        }
    }
}