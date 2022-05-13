using Controller.Pool;
using Services;
using UnityEngine;
using View.Balls;

namespace Controller.SpawnLogic
{
    public class GameFactory : IService
    {
        private const string PoolContainerPath = "Prefabs/PoolContainer";
        private readonly PoolContainer _poolContainer;
        
        public GameFactory()
        {
            var prefab = Resources.Load<PoolContainer>(PoolContainerPath);
            _poolContainer = Object.Instantiate(prefab);
            _poolContainer.CreatePools();
        }

        public Ball GetBall(BallType ballType, Vector2 position, Transform parent)
        {
            switch (ballType)
            {
                case BallType.SimpleBall:
                    return CreateBall<SimpleBall>(position, parent);
                case BallType.CompositeBall:
                    return CreateBall<CompositeBall>(position, parent);                    
                case BallType.HeavyBall:
                    return CreateBall<HeavyBall>(position, parent);
                case BallType.ColdBall:
                    return CreateBall<ColdBall>(position, parent);
                case BallType.BombBall:
                    return CreateBall<BombBall>(position, parent);
            }
            return null;
        }

        private T CreateBall<T>(Vector2 position, Transform parent) where T : Ball
        {
            var ball = _poolContainer.GetFreeElement<T>();
            ball.transform.position = position;
            ball.transform.SetParent(parent);
            ball.SetupPool(_poolContainer);
            return ball;
        }
    }
}