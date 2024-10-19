using UnityEngine;

namespace SpaceInvaders.PlayerInput
{
    public interface IPlayerInput
    {
        public bool IsPressedFire();
        
        public Vector2 ReadMoveDirection();
    }
}