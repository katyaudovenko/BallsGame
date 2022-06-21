using Controller.SpawnLogic;
using Extensions;
using Model.Infos.SpawnInfo;
using Services;
using Services.ServiceLocator;
using UnityEngine;
using View.Balls.Abstract;
using View.Balls.Destroy;

namespace View.Balls.Components
{
    public class ProbabilityCoinSpawn : MonoBehaviour, IBallComponent
    {
        private const float FullProgress = 100f;

        [SerializeField] private BallType ballType;
        
        private CoinSpawnConfig _coinSpawn;
        private CoinsService _coinsService;
        private CommonBallDestroy _commonBallDestroy;

        public void OnInitialize()
        {
            _coinSpawn = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<CoinSpawnContainer>().GetConfig(ballType);
            _coinsService = ServiceLocator.Instance.GetService<CoinsService>();
            _commonBallDestroy = GetComponent<CommonBallDestroy>();
        }

        public void OnSetup()
        {
            _commonBallDestroy.OnDestroyByUser += SpawnCoin;
        }

        public void OnReset()
        {
            _commonBallDestroy.OnDestroyByUser -= SpawnCoin;
        }

        private void SpawnCoin()
        {
            if(RandomExtension.CheckProbability(_coinSpawn.Chance,FullProgress))
                _coinsService.AddCoin(_coinSpawn.costBall);
        }
    }
}