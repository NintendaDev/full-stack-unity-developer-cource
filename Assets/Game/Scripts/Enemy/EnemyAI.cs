using System;
using Sirenix.OdinInspector;
using SpaceInvaders.Transport;
using SpaceInvaders.Movement;
using SpaceInvaders.Weapons;
using UnityEngine;

namespace SpaceInvaders.Enemies
{
    [RequireComponent(typeof(Ship))]
    public sealed class EnemyAI : MonoBehaviour
    {
        [SerializeField, Required] private Ship _enemy;
        [SerializeField, Required] private Gun _weapon;
        [SerializeField, Required] private DestinationAutoMover _destinationAutoMover;
        [SerializeField, Required] private AutoShooter _autoShooter;

        public event Action<EnemyAI> Destroyed;

        public void Awake()
        {
            _weapon.AddCantShootCondition(() => _destinationAutoMover.IsReached == false);
        }

        private void OnEnable()
        {
            _enemy.Destroyed += OnEnemyDestroy;
        }

        private void OnDisable()
        {
            _enemy.Destroyed -= OnEnemyDestroy;
        }

        public void SetDestination(Vector2 endPoint) => _destinationAutoMover.SetDestination(endPoint);
        
        public void Reset() => _enemy.Reset();
        
        public void SetTarget(Transform target) => _autoShooter.SetTarget(target);

        private void OnEnemyDestroy(Ship enemy) => Destroyed?.Invoke(this);
    }
}