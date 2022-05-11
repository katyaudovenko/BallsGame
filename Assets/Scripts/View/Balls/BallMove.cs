using UnityEngine;

namespace View.Balls
{
    public class BallMove : MonoBehaviour
    {
        public float speed;

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            StartMove();
        }

        public void StartMove()
        {
            _rigidbody2D.velocity = Vector2.down * speed;
        }

        public void StopMove()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}
