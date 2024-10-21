using System;
using Sirenix.OdinInspector;
using SpaceInvaders.Movement;
using SpaceInvaders.Attributes;
using SpaceInvaders.Weapons;
using UnityEngine;

namespace SpaceInvaders.Transport
{
    public sealed class Ship : MonoBehaviour
    {
        [SerializeField, Required] private Mover _mover;
        [SerializeField, Required] private Health _health;
        [SerializeField, Required] private Gun _gun;

        public Action<Ship> Destroyed;
        
        private void OnEnable()
        {
            _health.Died += OnDie;
        }

        private void OnDisable()
        {
            _health.Died -= OnDie;
        }

        public void Fire() => _gun.Shoot();
        
        public void Move(Vector2 moveDirection) => _mover.Move(moveDirection);
        
        public void Reset() => _health.Reset();

        private void OnDie() => Destroyed?.Invoke(this);
    }
}