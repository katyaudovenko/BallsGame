using UnityEngine;

namespace View
{
    public class HeavyBall : Ball
    {
        public override void DestroyBall()
        {
            Pool.ReturnElement(this);
        }
    }
}