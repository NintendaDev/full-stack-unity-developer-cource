using Sirenix.OdinInspector;
using SpaceInvaders.Transport;
using SpaceInvaders.PlayerInput;
using UnityEngine;

namespace SpaceInvaders.Controllers
{
    [RequireComponent(typeof(Ship))]
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField, Required] private Ship _player;
        
        private bool _fireRequired;
        private Vector2 _moveDirection;
        private IPlayerInput _playerInput;

        public void Initialize(IPlayerInput playerInput)
        {
            _playerInput = playerInput;
        }

        private void Update()
        {
            _fireRequired |= _playerInput.IsPressedFire();
            _moveDirection = _playerInput.ReadMoveDirection();
        }

        private void FixedUpdate()
        {
            if (_fireRequired)
            {
                _player.Fire();
                _fireRequired = false;
            }
            
            _player.Move(_moveDirection);
        }
    }
}