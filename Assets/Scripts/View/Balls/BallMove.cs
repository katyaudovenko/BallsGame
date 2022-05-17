using Model;
using UnityEngine;

namespace View.Balls
{
    public class BallMove : MonoBehaviour
    {
        [SerializeField] private BallInfo info;

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
            _rigidbody2D.velocity = Vector2.down * info.Speed;
        }

        public void StopMove()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}
