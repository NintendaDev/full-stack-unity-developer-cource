using System;
using System.Collections;
using Sirenix.OdinInspector;
using SpaceInvaders.Factories;
using SpaceInvaders.Game.Scripts.World;
using SpaceInvaders.Transport;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceInvaders.Enemies
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField, Required] private PointsProvider _spawnPoints;
        [SerializeField, Required] private PointsProvider _attackPoints;
        [SerializeField, Required] private ShipFactory _factory;
        [SerializeField, MinValue(0)] private Vector2 _spawnTimeRange = new(1, 2);
        
        private Ship _player;

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

        public void Initialize(Ship player)
        {
            _player = player;
        }

        private void SpawnEnemy()
        {
            Transform randomSpawnPoint = _spawnPoints.GetRandomPoint();
            Ship enemy = _factory.Create(randomSpawnPoint.position, randomSpawnPoint.rotation, randomSpawnPoint);
                
            Transform attackPosition = _attackPoints.GetRandomPoint();

            if (enemy.TryGetComponent(out EnemyAI enemyAI) == false)
                throw new Exception("The Enemy AI component was not found when creating an enemy ship");
            
            enemyAI.SetDestination(attackPosition.position);
            enemyAI.SetTarget(_player.transform);
        }
    }
}