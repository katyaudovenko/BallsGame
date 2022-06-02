using Controller.Pool;
using View.Balls.Abstract;

namespace View.Balls.Destroy
{
    public interface IBallDestroy
    {
        void SetupPool(PoolContainer pool);
        void OnDestroyBall<T>(T ball) where T : Ball;
    }
}