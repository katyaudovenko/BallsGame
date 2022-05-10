using Controller.Pool;
using Services;

namespace View.Balls
{
    public abstract class Ball : PoolObject, IPoolBehaviour
    {
        protected PoolContainer Pool;
        protected FreezeService FreezeService;
        protected BallMove BallMove { get; private set; }
        
        public void SetupPool(PoolContainer pool)
        {
            Pool = pool;
        }
        
        public virtual void OnInitialize()
        {
            BallMove = GetComponent<BallMove>();
            FreezeService = ServiceLocator.Instance.GetService<FreezeService>();
        }

        public virtual void OnSetup()
        {
            FreezeService.OnStartFreeze += BallMove.StopMove;
            FreezeService.OnEndFreeze += BallMove.StartMove;
        }

        public virtual void OnReset()
        {
            FreezeService.OnStartFreeze -= BallMove.StopMove;
            FreezeService.OnEndFreeze -= BallMove.StartMove;
        }

        public abstract void DestroyBall();
    }
}