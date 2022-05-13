using System;
using System.Collections.Generic;
using System.Linq;
using Services;

namespace View.Balls
{
    public class BallsManager : IService
    {
        private readonly List<Ball> _balls = new List<Ball>();

        public void AddBall(Ball ball)
        {
            _balls.Add(ball);
        }

        public void RemoveBall(Ball ball)
        {
            _balls.Remove(ball);
        }
        
        public void InvokeActionOnBall<T>(Action<T> invokeAction) where T : Ball
        {
            foreach (var ball in _balls.OfType<T>())
            {
                invokeAction(ball);
            }
        }
    }
}