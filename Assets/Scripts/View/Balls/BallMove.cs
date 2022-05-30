using Model;
using Model.Infos;
using Services;
using Services.ServiceLocator;
using UnityEngine;

namespace View.Balls
{
    public class BallMove : MonoBehaviour
    {
        private BallInfo _info;
        private Rigidbody2D _rigidbody2D;
        private FreezeService _freezeService;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _info = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<BallInfo>();
            _freezeService = ServiceLocator.Instance.GetService<FreezeService>();
        }

        private void OnEnable()
        {
            StartMove();
        }

        public void StartMove()
        {
            if(!_freezeService.IsEffectActive)
                _rigidbody2D.velocity = Vector2.down * _info.Speed;
        }

        public void StopMove()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}
