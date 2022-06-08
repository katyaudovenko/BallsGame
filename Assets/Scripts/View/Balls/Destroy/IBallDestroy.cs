using System;
using Controller.Pool;
using View.Balls.Abstract;

namespace View.Balls.Destroy
{
    public interface IBallDestroy
    {
        event Action OnDestroyByUser;
        void SetupPool(PoolContainer pool);
        void OnDestroyBall<T>(T ball) where T : Ball;
        void OnDestroyBallByUser<T>(T ball) where T : Ball;
    }
}