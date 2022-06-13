using System.Collections;
using Controller.Pool;
using UnityEngine;

namespace View.Balls.Effects
{
    public class ExplosionEffect : PoolObject, IPoolBehaviour
    {
        private ParticleSystem _explosion;
        private PoolContainer _pool;

        public void SetupPool(PoolContainer pool) => 
            _pool = pool;

        public void OnInitialize() => 
            _explosion = GetComponent<ParticleSystem>();
        
        public void OnSetup()
        {
            _explosion.Play();
            StartCoroutine(WaitToDestroyEffect());
        }

        private IEnumerator WaitToDestroyEffect()
        {
            yield return new WaitWhile(() => _explosion.isPlaying);
            DestroyEffect();
        }

        public void OnReset() => 
            _explosion.Stop();

        private void DestroyEffect() => 
            _pool.ReturnElement(this);
    }
}