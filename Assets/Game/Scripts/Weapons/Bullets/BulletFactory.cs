using Sirenix.OdinInspector;
using UnityEngine;

namespace SpaceInvaders.Weapons.Bullets
{
    public sealed class BulletFactory : MonoBehaviour
    {
        [SerializeField, Required] private Bullet _prefab;
        
        private BulletPool _pool;

        public void Initialize()
        {
            _pool = new BulletPool(_prefab);
        }

        public Bullet Create(Vector3 position, Quaternion rotation, Transform parent)
        {
            Bullet bullet = _pool.Rent();
            bullet.transform.SetPositionAndRotation(position, rotation); 
            bullet.transform.SetParent(parent);
            bullet.Initialize();

            return bullet;
        }
    }
}