using System;
using UnityEngine;

namespace SpaceInvaders.Weapons
{
    public interface IWeapon
    {
        public Vector3 FirePoint { get; }
        
        public void AddCantShootCondition(Func<bool> condition);
        
        public bool CanShoot();
        
        public void Shoot();
        
        public void Shoot(Vector2 direction);
    }
}