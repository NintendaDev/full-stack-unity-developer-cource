using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SpaceInvaders.Movement
{
    public sealed class DestinationAutoMover : MonoBehaviour
    {
        [SerializeField, Required] private Mover _mover;
        [SerializeField, MinValue(0)] private float _reachThreshold = 0.25f;
        
        private Transform _transform;
        private bool _isReached = true;
        private Vector2 _moveDirection;
        private Vector3 _destination;
        private bool _isInitialized;

        public event Action Reached;

        public void Initialize()
        {
            if (_isInitialized)
                return;
            
            _mover.Initialize();
            _mover.AddCantMoveCondition(() =>_isReached);
            _transform = transform;
            _isInitialized = true;
        }

        private bool CanMove => _isInitialized && _isReached == false;

        private void Update()
        {
            if (CanMove == false)
                return;
            
            _moveDirection = _destination - _transform.position;
            _mover.Move(_moveDirection);

            if (_moveDirection.magnitude <= _reachThreshold)
            {
                _isReached = true;
                Reached?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            if (CanMove == false)
                return;
            
            _mover.Move(_moveDirection);
        }

        public void SetDestination(Vector3 destination)
        {
            _destination = destination;
            _isReached = false;
        }
    }
}