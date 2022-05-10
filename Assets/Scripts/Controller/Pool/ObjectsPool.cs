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

        private PoolObject CreatePoolElement()
        {
            var createdElement = Object.Instantiate(_prefab, _container);
            createdElement.gameObject.SetActive(false);
            createdElement.Behaviour.OnInitialize();
            return createdElement;
        }

        public void ReturnElement<T>(T element) where T : PoolObject, IPoolBehaviour
        {
            _pool.Push(element);
            element.transform.SetParent(_container);
            element.gameObject.SetActive(false);
            element.Behaviour.OnReset();
        }

        public T GetFreeElement<T>() where T : PoolObject, IPoolBehaviour
        {
            var element = (_pool.Count == 0 ? 
                CreatePoolElement().Behaviour : 
                _pool.Pop()) as T;
            element.gameObject.SetActive(true);
            element.Behaviour.OnSetup();
            return element;
        }
    }
}