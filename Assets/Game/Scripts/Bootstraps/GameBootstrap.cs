using Sirenix.OdinInspector;
using SpaceInvaders.Enemies;
using SpaceInvaders.PlayerComponents;
using SpaceInvaders.PlayerInput;
using UnityEngine;

namespace SpaceInvaders.Bootstraps
{
    public sealed class GameBootstrap : MonoBehaviour
    {
        [SerializeField, Required] private Player _player;
        [SerializeField, Required] private PlayerController _playerController;
        [SerializeField, Required] private EnemySpawner _enemySpawner;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _player.Initialize();
            
            IPlayerInput playerInput = new LegacyPlayerInput();
            _playerController.Initialize(playerInput);
            _enemySpawner.Initialize();
        }
    }
}