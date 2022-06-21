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
        private ProgressService _progressService;

        public void OnInitialize()
        {
            _coinSpawn = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<CoinSpawnContainer>().GetConfig(ballType);
            _coinsService = ServiceLocator.Instance.GetService<CoinsService>();
            _progressService = ServiceLocator.Instance.GetService<ProgressService>();
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
            if (!RandomExtension.CheckProbability(_coinSpawn.Chance, FullProgress)) return;
            var finalCoinsCount = _coinSpawn.costBall + _progressService.Progress.playerStats.coinsModificator;
            _coinsService.AddCoin(finalCoinsCount);
        }
    }
}