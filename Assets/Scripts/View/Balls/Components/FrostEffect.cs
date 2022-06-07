﻿using Controller.Pool;
using UnityEngine;

namespace View.Balls.Components
{
    public class FrostEffect : PoolObject, IPoolBehaviour
    {
        private ParticleSystem _coldEffect;
        private PoolContainer _pool;

        public void SetupPool(PoolContainer pool) => _pool = pool;
        
        public void OnInitialize() => 
            _coldEffect = GetComponent<ParticleSystem>();

        public void OnSetup()
        {
            _coldEffect.Play();
        }

        public void OnReset()
        {
            _coldEffect.Stop();
        }

        public void DestroyEffect()
        {
            _pool.ReturnElement(this);
        }
    }
}