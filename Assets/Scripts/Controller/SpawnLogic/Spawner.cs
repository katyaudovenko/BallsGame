using System;
using System.Collections;
using Extensions;
using Services;
using UnityEngine;
using Random = UnityEngine.Random;
// ReSharper disable IteratorNeverReturns

namespace Controller.SpawnLogic
{
    public class Spawner : MonoBehaviour
    {
        private const float MaxRange = 2.2f;
        private const float MinRange = -2.2f;

        [SerializeField] private SpawnConfig[] spawnObjects;
        private GameFactory _gameFactory;
        private FreezeService _freezeService;
 

        private void Start()
        {
            _gameFactory = ServiceLocator.Instance.GetService<GameFactory>();
            _freezeService = ServiceLocator.Instance.GetService<FreezeService>();
            StartCoroutine(SpawnBallsWithDelay());
        }
        
        private IEnumerator SpawnBallsWithDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                
                yield return new WaitUntil(() => !_freezeService.IsEffectActive);

                var type = spawnObjects.GetRandomItem((config) => config.chance).ballType;
                _gameFactory.GetBall(type, GetBallPosition(), transform);
            }
        }

        private Vector2 GetBallPosition()
        {
            var x = Random.Range(MinRange, MaxRange);
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