using Services;

namespace View.Balls
{
    public class BombBall : Ball
    {
        private DetonateService _detonateService;

        private void Start()
        {
            _detonateService = ServiceLocator.Instance.GetService<DetonateService>();
        }

        private void OnMouseDown()
        {
            DestroyBallByUser();
        }

        protected override void OnBallDestroy()
        {
            _detonateService.PlanDetonate(transform.position);
            Pool.ReturnElement(this);
        }
    }
}