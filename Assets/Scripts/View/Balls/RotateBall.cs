using DG.Tweening;
using UnityEngine;

namespace View.Balls
{
    public class RotateBall : MonoBehaviour
    {
        private Tween _rotateAnimation;

        public void StartAnimation()
        {
            _rotateAnimation = transform
                .DORotate(new Vector3(0,0, 360), 7f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }

        public void StopAnimation()
        {
            _rotateAnimation.Pause();
        }

        public void ResetAnimation()
        {
            transform.rotation = Quaternion.identity;
            _rotateAnimation.Kill();
        }
    }
}