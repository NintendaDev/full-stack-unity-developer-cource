using Sirenix.OdinInspector;
using SpaceInvaders.PlayerComponents;
using UnityEngine;

namespace SpaceInvaders
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField, Required] private Player _player;

        private void OnEnable()
        {
            _player.Died += OnPlayerDie;
        }

        private void OnDisable()
        {
            _player.Died -= OnPlayerDie;
        }

        private void OnPlayerDie(Player player)
        {
            Time.timeScale = 0;
        }
    }
}