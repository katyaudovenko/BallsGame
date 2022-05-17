using System.Collections;
using Extensions;
using Model;
using Services;
using UnityEngine;
using View.Balls;
using Random = UnityEngine.Random;
// ReSharper disable IteratorNeverReturns

namespace Controller.SpawnLogic
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private SpawnInfo spawnInfo;
        [SerializeField] private BallInfo ballInfo;
        
        private GameFactory _gameFactory;
        private FreezeService _freezeService;
        private BallsManager _ballsManager;
        
        private void Start()
        {
            _gameFactory = ServiceLocator.Instance.GetService<GameFactory>();
            _ballsManager = ServiceLocator.Instance.GetService<BallsManager>();
            _freezeService = ServiceLocator.Instance.GetService<FreezeService>();
            StartCoroutine(SpawnBallsWithDelay());
        }
        
        private IEnumerator SpawnBallsWithDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnInfo.TimeSpawnDelay);
                
                yield return new WaitUntil(() => !_freezeService.IsEffectActive);

                var type = spawnInfo.SpawnObjects.GetRandomItem((config) => config.chance).ballType;
                var ball = _gameFactory.GetBall(type, GetBallPosition(), transform, ballInfo.BallSize, ballInfo.Color);
                _ballsManager.AddBall(ball);
            }
        }

        private Vector2 GetBallPosition()
        {
            var x = Random.Range(spawnInfo.MinPoint, spawnInfo.MaxPoint);
            var ballPosition = new Vector2(x, transform.position.y);
            return ballPosition;
        }
    }
    
}