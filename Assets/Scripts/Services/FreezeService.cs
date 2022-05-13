using UnityEngine;
using View.Balls;

namespace Services
{
    public class FreezeService : MonoBehaviour, IService
    {
        [SerializeField] private float freezeTime = 2;
        private readonly BallsManager _ballsManager = ServiceLocator.Instance.GetService<BallsManager>();

        private float _currentTime;
        public bool IsEffectActive { get; private set; }

        private void Update()
        {
            if (!IsEffectActive) 
                return;
            
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                EndFreeze();
            }
        }

        public void StartFreeze()
        {
            _currentTime = freezeTime;
            IsEffectActive = true;
           _ballsManager.InvokeActionOnBall<Ball>(ball => ball.BallMove.StopMove());
        }

        private void EndFreeze()
        {
            IsEffectActive = false;
            _ballsManager.InvokeActionOnBall<Ball>(ball => ball.BallMove.StartMove());
        }
       
    }
}