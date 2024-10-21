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
        private Vector2 _moveDirection;
        private Vector3 _destination;

        public event Action Reached;
        
        public bool IsReached { get; private set; }

        public void Awake()
        {
            _mover.AddCantMoveCondition(() => IsReached);
            _transform = transform;
        }

        private bool CanMove => IsReached == false;

        private void Update()
        {
            if (CanMove == false)
                return;
            
            _moveDirection = _destination - _transform.position;
            _mover.Move(_moveDirection);

            if (_moveDirection.magnitude <= _reachThreshold)
            {
                IsReached = true;
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
            IsReached = false;
        }
    }
}