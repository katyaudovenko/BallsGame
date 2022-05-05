using UnityEngine;

namespace View
{
    public class CompositeBall : Ball
    {
        public override void DestroyBall()
        {
            Pool.ReturnElement(this);
        }
    }
}