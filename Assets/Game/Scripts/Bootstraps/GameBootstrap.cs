using Sirenix.OdinInspector;
using SpaceInvaders.Controllers;
using SpaceInvaders.Enemies;
using SpaceInvaders.Transport;
using SpaceInvaders.PlayerInput;
using UnityEngine;

namespace SpaceInvaders.Bootstraps
{
    public sealed class GameBootstrap : MonoBehaviour
    {
        [SerializeField, Required] private Ship _player;
        [SerializeField, Required] private PlayerController _playerController;
        [SerializeField, Required] private EnemySpawner _enemySpawner;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            IPlayerInput playerInput = new PlayerInput.PlayerInput();
            _playerController.Initialize(playerInput);
            _enemySpawner.Initialize(_player);
        }
    }
}