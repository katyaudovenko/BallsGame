using UnityEngine;

namespace Controller.Pool
{
    public class PoolObject : MonoBehaviour
    {
        private IPoolBehaviour _behaviour;

        public IPoolBehaviour Behaviour
        {
            get
            {
                if (_behaviour == null && !TryGetComponent(out _behaviour))
                {
                    Debug.LogError("Object has not got link");
                }
                return _behaviour;
            }
        }
    }
}