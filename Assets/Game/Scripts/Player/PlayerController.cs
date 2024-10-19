using SpaceInvaders.PlayerInput;
using UnityEngine;

namespace SpaceInvaders.PlayerComponents
{
    [RequireComponent(typeof(Player))]
    public sealed class PlayerController : MonoBehaviour
    {
        private Player _player;
        private bool _fireRequired;
        private Vector2 _moveDirection;
        private IPlayerInput _playerInput;

        public void Initialize(IPlayerInput playerInput)
        {
            _playerInput = playerInput;
            _player = GetComponent<Player>();
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