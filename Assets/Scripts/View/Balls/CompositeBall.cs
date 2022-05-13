﻿using UnityEngine;

namespace View.Balls
{
    public class CompositeBall : Ball
    {
        [SerializeField] private int livesCount = 2;

        private int _livesCount;

        private void OnEnable()
        {
            _livesCount = livesCount;
        }

        private void OnMouseDown()
        {
            Damage();
        }
        
        private void Damage()
        {
            _livesCount--;
            if (_livesCount <= 0) 
                DestroyBallByUser();
        }
        protected override void OnBallDestroy()
        {
            Pool.ReturnElement(this);
        }
        
    }
}