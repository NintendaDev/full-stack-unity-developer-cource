using System;
using Sirenix.OdinInspector;
using SpaceInvaders.Movement;
using SpaceInvaders.Attributes;
using SpaceInvaders.Weapons;
using UnityEngine;

namespace SpaceInvaders.PlayerComponents
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField, Required] private Mover _mover;
        [SerializeField, Required] private Health _health;
        [SerializeField, Required] private Gun _gun;

        public Action<Player> Died;
        
        private void OnEnable()
        {
            _health.Died += OnDie;
        }

        private void OnDisable()
        {
            _health.Died -= OnDie;
        }

        public void Initialize()
        {
            _gun.Initialize();
            _mover.Initialize();
            _health.Initialize();
        }

        public void Fire() => _gun.Shoot();
        
        public void Move(Vector2 moveDirection) => _mover.Move(moveDirection);

        private void OnDie() => Died?.Invoke(this);
    }
}