using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules.ObjectManagement.Scripts.Pools
{
    public class ComponentPool<T> where T : Component
    {
        private readonly T _prefab;
        private readonly Queue<object> _items = new();

        public ComponentPool(T prefab)
        {
            _prefab = prefab;
        }

        public T Rent()
        {
            T item;
            
            if (_items.Count > 0) 
                item = (T)_items.Dequeue();
            else
                item = Object.Instantiate(_prefab);

            OnSpawn(item);

            return item;
        }

        public void Return(T item)
        {
            if (_items.Contains(item))
                throw new Exception("Item is already in pool");
            
            OnDespawn(item);
            _items.Enqueue(item);
        }

        protected virtual void OnSpawn(T item)
        {
            item.gameObject.SetActive(true);
        }

        protected virtual void OnDespawn(T item)
        {
            item.gameObject.SetActive(false);
        }
    }
}