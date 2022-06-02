using Controller.Pool;
using UnityEngine;
using View.Balls.Abstract;

namespace View.Balls.Destroy
{
    public class BonusBallDestroy : MonoBehaviour, IBallDestroy
    {
        private PoolContainer _pool;
        
        public void SetupPool(PoolContainer pool) => _pool = pool;

        public void OnDestroyBall<T>(T ball) where T : Ball 
            => _pool.ReturnElement(ball);
    }
}