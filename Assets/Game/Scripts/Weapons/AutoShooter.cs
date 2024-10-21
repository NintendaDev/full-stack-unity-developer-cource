using Modules.Timers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SpaceInvaders.Weapons
{
    public sealed class AutoShooter : MonoBehaviour
    {
        [SerializeField, Required] private Gun _gun;
        [SerializeField, MinValue(0), Unit(Units.Second)] private float _shootPeriod = 1f;
        
        private Transform _target;
        private CountdownTimer _shootTimer;
        private bool _subscribed;
        private bool _isInitialized;

        private void Awake()
        {
            _shootTimer = new CountdownTimer(_shootPeriod);
            
        }

        private void OnEnable()
        {
            _shootTimer.Finished += OnShootTimerFinish;
        }

        private void OnDisable()
        {
            _shootTimer.Finished -= OnShootTimerFinish;
        }

        private void Start()
        {
            _shootTimer.Start();
        }

        private void Update()
        {
            _shootTimer.Tick(Time.deltaTime);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void OnShootTimerFinish()
        {
            if (TryCalculateShootDirection(out Vector3 direction))
                _gun.Shoot(direction);
            
            _shootTimer.Reset();
        }

        private bool TryCalculateShootDirection(out Vector3 direction)
        {
            direction = default;
            
            if (_target == null)
                return false;
            
            direction = (_target.position - _gun.FirePoint).normalized;

            return true;
        }
    }
}