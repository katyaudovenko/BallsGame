using System;
using UnityEngine;

namespace Controller.Pool
{
    [Serializable]
    public class PoolInfo
    {
        public int Count;
        public PoolObject Prefab;
    }
}