using System;
using Sirenix.OdinInspector;
using SpaceInvaders.Core;
using SpaceInvaders.Weapons.Bullets;
using UnityEngine;

namespace SpaceInvaders.Weapons
{
    public sealed class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField, Required] private BulletFactory _bulletFactory;
        [SerializeField, Required] private Transform _firePoint;

        private readonly ConditionValidator _canShootValidator = new(isNegativeConditions: true);
        private Transform _transform;

        public Vector3 FirePoint => _firePoint.position;

        public void Initialize()
        {
            _bulletFactory.Initialize();
        }
        
        public void AddCantShootCondition(Func<bool> condition) => _canShootValidator.Add(condition);

        public bool CanShoot() => _canShootValidator.IsValid();

        public void Shoot() =>
            Shoot(_firePoint.up);

        public void Shoot(Vector2 direction)
        {
            if (CanShoot() == false)
                return;
            
            Bullet bullet = _bulletFactory.Create(_firePoint.position, _firePoint.rotation, _firePoint);
            bullet.Launch(direction);
        }
    }
}