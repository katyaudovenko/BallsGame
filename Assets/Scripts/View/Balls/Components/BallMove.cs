using Model.Infos;
using Services;
using Services.ServiceLocator;
using UnityEngine;
using View.Balls.Abstract;

namespace View.Balls.Components
{
    public class BallMove : MonoBehaviour, IBallComponent
    {
        private BallInfo _info;
        private Rigidbody2D _rigidbody2D;
        private FreezeService _freezeService;

        public void OnInitialize()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _info = ServiceLocator.Instance.GetService<ConfigService>().GetConfig<BallInfo>();
            _freezeService = ServiceLocator.Instance.GetService<FreezeService>();
        }

        public void OnSetup() => 
            StartMove();

        public void OnReset() {}
        
        public void StartMove()
        {
            if(!_freezeService.IsEffectActive)
                _rigidbody2D.velocity = Vector2.down * _info.Speed;
        }

        public void FreezeMove() => 
            _rigidbody2D.velocity = Vector2.down * 0.4f;

        public void StopMove() =>
            _rigidbody2D.velocity = Vector2.zero;
    }
}
