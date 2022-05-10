using System;
using System.Collections;
using Services;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controller.SpawnLogic
{
    public class Spawner : MonoBehaviour
    {
        private const float MaxRange = 2.2f;
        private const float MinRange = -2.2f;

        [SerializeField] private SpawnConfig[] spawnObjects;
        private GameFactory _gameFactory;
        private float _accumulatedWeight;

        private void Start()
        {
            _gameFactory = ServiceLocator.Instance.GetService<GameFactory>();
            CalculateWeight();
            StartCoroutine(SpawnBallsWithDelay());
        }
        
        private void CalculateWeight()
        {
            _accumulatedWeight = 0;
            foreach (var ball in spawnObjects)
            {
                _accumulatedWeight += ball.chance;
                ball.weight = _accumulatedWeight;
            }
        }
        
        private IEnumerator SpawnBallsWithDelay()
        {
            while (true)
            {
                var type = (TypeBalls)GetRandomTypeBall();
                yield return new WaitForSeconds(0.5f);
                _gameFactory.GetBall(type, GetBallPosition(), transform);
            }
        }

        private int GetRandomTypeBall()
        {
            var random = Random.value * _accumulatedWeight;
            for (var i = 0; i < spawnObjects.Length; i++)
                if (spawnObjects[i].weight >= random)
                    return i;

            return 0;
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
        [HideInInspector] public float weight;
    }
}