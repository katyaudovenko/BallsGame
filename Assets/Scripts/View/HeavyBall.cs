using System;
using System.Collections;
using UnityEngine;

namespace View
{
    public class HeavyBall : Ball
    {
        [SerializeField] private int timeLife;

        private BallMove _ballMove;
        private float _currentTime;
        private bool _isPressed;

        private void Start()
        {
            _ballMove = GetComponent<BallMove>();
        }

        private void OnEnable()
        {
            _currentTime = timeLife;
            _isPressed = false;
        }

        private void Update()
        {
            if (_isPressed)
            {
                _currentTime -= Time.deltaTime;
                if (_currentTime <= 0)
                {
                    DestroyBall();
                }
            }
        }

        private void OnMouseDown()
        {
            _isPressed = true;
            _ballMove.StopMove();
        }

        private void OnMouseUp()
        {
            _isPressed = false;
            _ballMove.StartMove();
        }

        public override void DestroyBall()
        {
            Pool.ReturnElement(this);
        }
    }
}