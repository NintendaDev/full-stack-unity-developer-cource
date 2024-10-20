using UnityEngine;

namespace SpaceInvaders.PlayerInput
{
    public sealed class LegacyPlayerInput : IPlayerInput
    {
        private readonly Vector2 _leftDirection = new(-1, 0);
        private readonly Vector2 _rightDirection = new(1, 0);
        private readonly Vector2 _defaultDirection = Vector2.zero;

        public bool IsPressedFire() => Input.GetKeyDown(KeyCode.Space);

        public Vector2 ReadMoveDirection()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                return _leftDirection;

            if (Input.GetKey(KeyCode.RightArrow))
                return _rightDirection;

            return _defaultDirection;
        }
    }
}