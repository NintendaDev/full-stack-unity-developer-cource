using Sirenix.OdinInspector;
using SpaceInvaders.Transport;
using UnityEngine;

namespace SpaceInvaders
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField, Required] private Ship _player;

        private void OnEnable()
        {
            _player.Destroyed += OnPlayerDie;
        }

        private void OnDisable()
        {
            _player.Destroyed -= OnPlayerDie;
        }

        private void OnPlayerDie(Ship player)
        {
            Time.timeScale = 0;
        }
    }
}