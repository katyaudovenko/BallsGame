using System;
using System.Collections;
using Extensions;
using Services;
using UnityEngine;
using View;
using View.Balls;
using Random = UnityEngine.Random;
// ReSharper disable IteratorNeverReturns

namespace Controller.SpawnLogic
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private SpawnConfig[] spawnObjects;
        [SerializeField] private float timeSpawnDelay = 1;
        private GameFactory _gameFactory;
        private FreezeService _freezeService;
        private BallsManager _ballsManager;

        private float _maxRange;
        private float _minRange;

        private void Start()
        {
            _gameFactory = ServiceLocator.Instance.GetService<GameFactory>();
            _ballsManager = ServiceLocator.Instance.GetService<BallsManager>();
            _freezeService = ServiceLocator.Instance.GetService<FreezeService>();
            _maxRange = SpawnZoneSize.RightBorder();
            _minRange = SpawnZoneSize.LeftBorder();
            StartCoroutine(SpawnBallsWithDelay());
        }
        
        private IEnumerator SpawnBallsWithDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(timeSpawnDelay);
                
                yield return new WaitUntil(() => !_freezeService.IsEffectActive);

                var type = spawnObjects.GetRandomItem((config) => config.chance).ballType;
                var ball = _gameFactory.GetBall(type, GetBallPosition(), transform);
                _ballsManager.AddBall(ball);
            }
        }

        private Vector2 GetBallPosition()
        {
            var x = Random.Range(_minRange, _maxRange);
            var ballPosition = new Vector2(x, transform.position.y);
            return ballPosition;
        }
    }

    [Serializable]
    public class SpawnConfig
    {
        [Range(0f,100f)] public float chance;
        public BallType ballType;
    }
}