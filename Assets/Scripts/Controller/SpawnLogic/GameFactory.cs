﻿using Controller.Pool;
using DG.Tweening;
using Services;
using Services.ServiceLocator;
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

        public Ball GetBall(BallType ballType, Vector2 position, Transform parent, Vector3 scale, Color color)
        {
            switch (ballType)
            {
                case BallType.SimpleBall:
                    return CreateBall<SimpleBall>(position, parent, scale, color);
                case BallType.CompositeBall:
                    return CreateBall<CompositeBall>(position, parent, scale, color);                    
                case BallType.HeavyBall:
                    return CreateBall<HeavyBall>(position, parent, scale, color);
                case BallType.ColdBall:
                    return CreateBall<ColdBall>(position, parent, scale, Color.white);
                case BallType.BombBall:
                    return CreateBall<BombBall>(position, parent, scale, Color.white);
            }
            return null;
        }

        private T CreateBall<T>(Vector2 position, Transform parent, Vector3 scale, Color color) where T : Ball
        {
            var ball = _poolContainer.GetFreeElement<T>();
            ball.transform.position = position;
            ball.transform.localScale = scale;
            SetColor(ball, color);
            ball.transform.SetParent(parent);
            ball.SetupPool(_poolContainer);
            return ball;
        }

        private void SetColor(Ball ball, Color color)
        {
            var renderer = ball.GetComponentInChildren<SpriteRenderer>();
            renderer.color = color;
        }
        
    }
}