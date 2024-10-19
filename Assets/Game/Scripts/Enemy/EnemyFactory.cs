using Sirenix.OdinInspector;
using UnityEngine;

namespace SpaceInvaders.Enemies
{
    public sealed class EnemyFactory : MonoBehaviour
    {
        [SerializeField, Required] private Enemy _prefab;
        
        private EnemyPool _pool;

        public void Initialize()
        {
            _pool = new EnemyPool(_prefab);
        }

        public Enemy Create(Vector3 position, Quaternion rotation, Transform parent)
        {
            Enemy enemy = _pool.Rent();
            
            enemy.Initialize();
            enemy.transform.position = position;
            enemy.transform.rotation = rotation;
            enemy.transform.SetParent(parent);

            return enemy;
        }
    }
}