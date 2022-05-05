using System.Collections;
using Services;
using UnityEngine;
using View;

namespace Controller.SpawnLogic
{
    public class Spawner : MonoBehaviour
    {
        private const float MaxRange = 2.2f;
        private const float MinRange = -2.2f;
        
        private GameFactory _gameFactory;

        private void Start()
        {
            _gameFactory = ServiceLocator.Instance.GetService<GameFactory>();
            StartCoroutine(SpawnBallsWithDelay());
        }
        
        private IEnumerator SpawnBallsWithDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                var probability = Random.Range(0f, 1f);
                if (probability >= 0.4)
                {
                    CreateSimpleBall();
                }

                if (probability < 0.4 && probability >= 0.2)
                {
                    CreateCompositeBall();
                }

                if (probability < 0.2)
                {
                    CreateHeavyBall();
                }
            }
        }
        
        private void CreateSimpleBall() =>
        _gameFactory.CreateBall<SimpleBall>(BallPosition(), transform);

        private void CreateCompositeBall()=>
            _gameFactory.CreateBall<CompositeBall>(BallPosition(), transform);

        private void CreateHeavyBall()=>
            _gameFactory.CreateBall<HeavyBall>(BallPosition(), transform);
        
        private Vector2 BallPosition()
        {
            var x = Random.Range(MinRange, MaxRange);
            var ballPosition = new Vector2(x, transform.position.y);
            return ballPosition;
        }
    }
}