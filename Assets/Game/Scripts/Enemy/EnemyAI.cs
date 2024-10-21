using System;
using Sirenix.OdinInspector;
using SpaceInvaders.Transport;
using SpaceInvaders.Movement;
using SpaceInvaders.Weapons;
using UnityEngine;

namespace SpaceInvaders.Enemies
{
    [RequireComponent(typeof(Ship))]
    public sealed class EnemyAI : MonoBehaviour
    {
        [SerializeField, Required] private Gun _weapon;
        [SerializeField, Required] private DestinationAutoMover _destinationAutoMover;
        [SerializeField, Required] private AutoShooter _autoShooter;

        public void Awake()
        {
            _weapon.AddCantShootCondition(() => _destinationAutoMover.IsReached == false);
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destinationAutoMover.SetDestination(endPoint);
        }

        public void SetTarget(Transform target) => _autoShooter.SetTarget(target);
    }
}