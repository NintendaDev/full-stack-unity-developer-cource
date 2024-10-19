using System;
using Sirenix.OdinInspector;
using SpaceInvaders.Attributes;
using SpaceInvaders.Movement;
using SpaceInvaders.Weapons;
using UnityEngine;

namespace SpaceInvaders.Enemies
{
    public sealed class Enemy : MonoBehaviour
    {
        [SerializeField, Required] private Gun _weapon;
        [SerializeField, Required] private Health _health;
        [SerializeField, Required] private DestinationAutoMover _destinationAutoMover;
        [SerializeField, Required] private AutoShooter _autoShooter;
        
        private bool _isReachedShootPoint;
        private bool _isInitialized;
        private bool _isSubscribed;

        public event Action<Enemy> Died;

        public void Initialize()
        {
            if (_isInitialized)
                return;
            
            _weapon.Initialize();
            _weapon.AddCantShootCondition(() =>_isReachedShootPoint == false);
            _autoShooter.Initialize(_weapon);
            _destinationAutoMover.Initialize();
            
            _isInitialized  = true;
            
            Subscribe();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }
        public void SetDestination(Vector2 endPoint)
        {
            _destinationAutoMover.SetDestination(endPoint);
            _isReachedShootPoint = false;
        }

        public void SetTarget(Transform target) => _autoShooter.SetTarget(target);

        public void Reset()
        {
            _health.Reset();
        }

        private void Subscribe()
        {
            if (_isSubscribed || _isInitialized == false)
                return;
            
            _destinationAutoMover.Reached += OnReachPosition;
            _health.Died += OnDied;

            _isSubscribed = true;
        }

        private void OnReachPosition()
        {
            _isReachedShootPoint = true;
        }

        private void OnDied()
        {
            Died?.Invoke(this);
        }

        private void Unsubscribe()
        {
            if (_isSubscribed == false || _isInitialized == false)
                return;
            
            _destinationAutoMover.Reached -= OnReachPosition;
            _health.Died -= OnDied;

            _isSubscribed = false;
        }
    }
}