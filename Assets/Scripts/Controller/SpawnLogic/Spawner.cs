using System.Collections;
using Extensions;
using Model.Infos;
using Model.Infos.SpawnInfo;
using Services;
using Services.ServiceLocator;
using UnityEngine;
using View;
using Random = UnityEngine.Random;
// ReSharper disable IteratorNeverReturns

namespace Controller.SpawnLogic
{
    public class Spawner : MonoBehaviour
    {
        private SpawnInfo _spawnInfo;
        private BallInfo _ballInfo;
        private GameFactory _gameFactory;
        private FreezeService _freezeService;
        private BallsManager _ballsManager;
        private SpawnZoneSize _spawnZoneSize;
        private bool _canSpawn;
        
        private void Start()
        {
            _canSpawn = true;
            
            _spawnInfo = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<SpawnInfo>();
            _ballInfo = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<BallInfo>();
            _gameFactory = ServiceLocator.Instance.GetService<GameFactory>();
            _ballsManager = ServiceLocator.Instance.GetService<BallsManager>();
            _freezeService = ServiceLocator.Instance.GetService<FreezeService>();
            
            _spawnZoneSize = GetComponent<SpawnZoneSize>();
            
            StartCoroutine(SpawnBallsWithDelay());
            GlobalEventManager.EndGame += StopSpawn;
        }
        
        private IEnumerator SpawnBallsWithDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnInfo.TimeSpawnDelay);
                
                if(!_canSpawn) 
                    yield break;
                
                yield return new WaitUntil(() => !_freezeService.IsEffectActive);

                var type = _spawnInfo.SpawnObjects.GetRandomItem(config => config.Chance).BallType;
                var ball = _gameFactory.GetBall(type, GetBallPosition(), transform, _ballInfo.BallSize, _ballInfo.Color);
                _ballsManager.AddBall(ball);
            }
        }

        private Vector2 GetBallPosition()
        {
            var minInclusive = _spawnZoneSize.LeftBorder;
            var maxInclusive = _spawnZoneSize.RightBorder;
            var x = Random.Range(minInclusive,maxInclusive);
            var ballPosition = new Vector2(x, transform.position.y);
            return ballPosition;
        }

        private void StopSpawn()
        {
            StopCoroutine(SpawnBallsWithDelay());
            _canSpawn = false;
        }
    }
    
}