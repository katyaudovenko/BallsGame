using Controller.Pool;
using Services;
using UnityEngine;
using View;

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
        
        public T CreateBall<T>(Vector2 position, Transform parent) where T : Ball
        {
            var ball = _poolContainer.GetFreeElement<T>();
            ball.transform.position = position;
            ball.transform.SetParent(parent);
            ball.SetupPool(_poolContainer);
            return ball;
        }

        public Ball GetBall(TypeBalls type, Vector2 position, Transform parent)
        {
            switch (type)
            {
                case TypeBalls.SimpleBall:
                    return CreateBall<SimpleBall>(position, parent);
                case TypeBalls.CompositeBall:
                    return CreateBall<CompositeBall>(position, parent);                    
                case TypeBalls.HeavyBall:
                    return CreateBall<HeavyBall>(position, parent);
            }
            return null;
        }
    }
}