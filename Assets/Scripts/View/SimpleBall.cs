using UnityEngine;

namespace View
{
    public class SimpleBall : Ball
    {
        public override void DestroyBall()
        {
            Pool.ReturnElement(this);
        }
    }
}