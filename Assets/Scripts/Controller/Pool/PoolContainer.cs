using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controller.Pool
{
    public class PoolContainer : MonoBehaviour
    {
        [SerializeField] private List<PoolInfo> poolsInfo;

        private Dictionary<Type, ObjectsPool> _poolsMap = new Dictionary<Type, ObjectsPool>();

        public void CreatePools()
        {
            foreach (var poolInfo in poolsInfo)
            {
                var type = poolInfo.Prefab.Behaviour.GetType();
                var pool = new ObjectsPool(poolInfo.Prefab, poolInfo.Count, CreateContainer(type.Name));
                _poolsMap.Add(type, pool);
            }
        }

        private Transform CreateContainer(string typeName)
        {
            var container = new GameObject($"{typeName}Pool");
            container.transform.SetParent(transform);
            return container.transform;
        }

        public T GetFreeElement<T>() where T : MonoBehaviour, IPoolBehaviour => 
            _poolsMap[typeof(T)].GetFreeElement<T>();

        public void ReturnElement<T>(T element) where T : MonoBehaviour, IPoolBehaviour => 
            _poolsMap[typeof(T)].ReturnElement<T>(element);
    }
}