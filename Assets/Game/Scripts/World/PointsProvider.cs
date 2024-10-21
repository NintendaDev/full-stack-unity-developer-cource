using Sirenix.OdinInspector;
using UnityEngine;

namespace SpaceInvaders.Game.Scripts.World
{
    public sealed class PointsProvider : MonoBehaviour
    {
        [SerializeField, RequiredListLength(1, null)] 
        private Transform[] _points;

        public Transform GetRandomPoint() => _points[Random.Range(0, _points.Length)];
    }
}