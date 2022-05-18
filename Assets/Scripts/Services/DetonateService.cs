using System;
using System.Collections.Generic;
using Model;
using UnityEngine;
using View.Balls;

namespace Services
{
    public class DetonateService : IService
    {
        private readonly DetonateInfo _info;
        private readonly BallsManager _ballsManager;
        private readonly Queue<Action> _detonateQueue = new Queue<Action>();
        private bool _isEffectActive;

        public DetonateService(BallsManager ballsManager)
        {
            _ballsManager = ballsManager;
            _info = ConfigService.Instance.GetConfig<DetonateInfo>();
        }

        public void PlanDetonate(Vector3 position)
        {
            if (!_isEffectActive)
                Detonate(position);
            else
                _detonateQueue.Enqueue(() => Detonate(position));
        }

        private void Detonate(Vector3 position)
        {
            var destroyBalls = FindDestroyBalls(position);
            DestroyBalls(destroyBalls);
            InvokeQueue();
        }

        private List<Ball> FindDestroyBalls(Vector3 position)
        {
            var destroyBalls = new List<Ball>();
            _ballsManager.InvokeActionOnBall<Ball>(ball =>
            {
                var distance = (ball.transform.position - position).magnitude;
                if (distance < _info.Radius)
                {
                    destroyBalls.Add(ball);
                }
            });
            return destroyBalls;
        }

        private void DestroyBalls(List<Ball> destroyBalls)
        {
            _isEffectActive = true;
            foreach (var ball in destroyBalls)
            {
                ball.DestroyBallByUser();
            }

            _isEffectActive = false;
        }

        private void InvokeQueue()
        {
            while (_detonateQueue.Count > 0)
            {
                Action detonateAction = _detonateQueue.Dequeue();
                detonateAction.Invoke();
            }
        }
    }
}