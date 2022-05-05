using Controller.Pool;
using UnityEngine;

namespace View
{
    public abstract class Ball : MonoBehaviour, IPoolBehaviour
    {
        protected PoolContainer Pool;
        public void SetupPool(PoolContainer pool)
        {
            Pool = pool;
        }
        public virtual void OnInitialize() { }

        public abstract void DestroyBall();
    }
}