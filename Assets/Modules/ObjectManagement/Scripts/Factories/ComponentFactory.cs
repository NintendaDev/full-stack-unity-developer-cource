using Modules.ObjectManagement.Scripts.Pools;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.ObjectManagement.Factories
{
    public abstract class ComponentFactory<T> : MonoBehaviour where T : Component
    {
        [SerializeField, Required] private T _prefab;
        
        private ComponentPool<T> _pool;
        
        protected T Prefab => _prefab;

        private void Awake()
        {
            _pool = CreatePool();
        }

        public T Create(Vector3 position, Quaternion rotation, Transform parent)
        {
            T newObject = _pool.Rent();
            
            newObject.transform.position = position;
            newObject.transform.rotation = rotation;
            newObject.transform.SetParent(parent);

            return newObject;
        }

        protected abstract ComponentPool<T> CreatePool();
    }
}