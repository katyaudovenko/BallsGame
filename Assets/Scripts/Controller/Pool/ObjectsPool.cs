using System.Collections.Generic;
using UnityEngine;

namespace Controller.Pool
{
    public class ObjectsPool
    {
        private readonly PoolObject _prefab;
        private readonly Transform _container;
        private Stack<IPoolBehaviour> _pool;

        public ObjectsPool(PoolObject prefab, int count, Transform container)
        {
            _prefab = prefab;
            _container = container;
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new Stack<IPoolBehaviour>();
            for (int i = 0; i < count; i++)
            {
                var element = CreatePoolElement();
                _pool.Push(element.Behaviour);
            }
        }

        private PoolObject CreatePoolElement(bool isActiveByDefault = false)
        {
            var createdElement = Object.Instantiate(_prefab, _container);
            createdElement.gameObject.SetActive(isActiveByDefault);
            createdElement.Behaviour.OnInitialize();
            return createdElement;
        }

        public void ReturnElement<T>(T element) where T : MonoBehaviour, IPoolBehaviour
        {
            _pool.Push(element);
            element.transform.SetParent(_container);
            element.gameObject.SetActive(false);
        }

        public T GetFreeElement<T>() where T : MonoBehaviour, IPoolBehaviour
        {
            if (_pool.Count == 0)
                return CreatePoolElement(true).Behaviour as T;
            var element = _pool.Pop() as T;
            element.gameObject.SetActive(true);
            return element;
        }
    }
}