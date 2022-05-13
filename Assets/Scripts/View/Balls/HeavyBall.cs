﻿using UnityEngine;

namespace View.Balls
{
    public class HeavyBall : Ball
    {
        [SerializeField] private int timeLife;
        
        private float _currentTime;
        private bool _isPressed;

        public override void OnSetup()
        {
            base.OnSetup();
            _currentTime = timeLife;
            _isPressed = false;
        }

        private void Update()
        {
            if (_isPressed)
            {
                _currentTime -= Time.deltaTime;
                if (_currentTime <= 0) 
                    DestroyBallByUser();
            }
        }

        private void OnMouseDown()
        {
            _isPressed = true;
            BallMove.StopMove();
        }

        private void OnMouseUp()
        {
            if (FreezeService.IsEffectActive) return;
            _isPressed = false;
            BallMove.StartMove();
        }

        protected override void OnBallDestroy()
        {
            Pool.ReturnElement(this);
        }
    }
}