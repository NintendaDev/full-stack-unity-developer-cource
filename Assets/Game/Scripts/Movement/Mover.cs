using System;
using SpaceInvaders.Core;
using UnityEngine;

namespace SpaceInvaders.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 5.0f;

        private readonly ConditionValidator _canMoveValidator = new(isNegativeConditions: true);
        private Rigidbody2D _rigidbody;
        private Vector2 _moveDirection;
        private Transform _transform;
        private Vector2 _moveStep;
        private Vector3 _movePosition;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _transform = transform;
        }

        public bool CanMove => _canMoveValidator.IsValid() && _moveDirection.sqrMagnitude > 0;

        private void FixedUpdate()
        {
            if (CanMove == false)
                return;
            
            _moveStep = _moveDirection * (Time.fixedDeltaTime * _speed);
            
            _movePosition = new Vector3(_transform.position.x + _moveStep.x,
                _transform.position.y + _moveStep.y, _transform.position.z);

            _rigidbody.MovePosition(_movePosition);
        }

        public void AddCantMoveCondition(Func<bool> condition) => _canMoveValidator.Add(condition);

        public void Move(Vector2 moveDirection)
        {
            _moveDirection = moveDirection;
        }
    }
}