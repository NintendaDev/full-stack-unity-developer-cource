using System.Collections;
using Sirenix.OdinInspector;
using SpaceInvaders.Game.Scripts.World;
using SpaceInvaders.PlayerComponents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceInvaders.Enemies
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField, Required] private PointsCollector _spawnPoints;
        [SerializeField, Required] private PointsCollector _attackPoints;
        [SerializeField, Required] private EnemyFactory _factory;
        [SerializeField, Required] private Player _player;
        [SerializeField, MinValue(0)] private Vector2 _spawnTimeRange = new(1, 2);
        
        private IEnumerator Start()
        {
            bool isEnd = false;
            WaitForSeconds waiter = new WaitForSeconds(Random.Range(_spawnTimeRange.x, _spawnTimeRange.y));
            
            while (isEnd == false)
            {
                SpawnEnemy();
                
                yield return waiter;
            }
        }

        public void Initialize()
        {
            _factory.Initialize();
        }

        private void SpawnEnemy()
        {
            Transform randomSpawnPoint = _spawnPoints.GetRandomPoint();
            Enemy enemy = _factory.Create(randomSpawnPoint.position, randomSpawnPoint.rotation, randomSpawnPoint);
                
            Transform attackPosition = _attackPoints.GetRandomPoint();
            enemy.SetDestination(attackPosition.position);
            enemy.SetTarget(_player.transform);
        }
    }
}