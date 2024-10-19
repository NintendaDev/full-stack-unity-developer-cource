using Sirenix.OdinInspector;
using SpaceInvaders.Timers;
using UnityEngine;

namespace SpaceInvaders.Weapons
{
    public sealed class AutoShooter : MonoBehaviour
    {
        [SerializeField, MinValue(0), Unit(Units.Second)] private float _shootPeriod = 1f;
        
        private Transform _target;
        private CountdownTimer _shootTimer;
        private bool _subscribed;
        private bool _isInitialized;
        private IWeapon _weapon;

        public void Initialize(IWeapon weapon)
        {
            _weapon = weapon;
            _shootTimer = new CountdownTimer(_shootPeriod);
            _isInitialized = true;
            
            Subscribe();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
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
        
        private void Subscribe()
        {
            if (_subscribed || _isInitialized == false)
                return;
            
            _shootTimer.Finished += OnShootTimerFinish;
            _subscribed = true;
        }

        private void OnShootTimerFinish()
        {
            if (TryCalculateShootDirection(out Vector3 direction))
                _weapon.Shoot(direction);
            
            _shootTimer.Reset();
        }

        private void Unsubscribe()
        {
            if (_subscribed == false || _isInitialized == false)
                return;
            
            _shootTimer.Finished -= OnShootTimerFinish;
            _subscribed = false;
        }

        private bool TryCalculateShootDirection(out Vector3 direction)
        {
            direction = default;
            
            if (_target == null)
                return false;
            
            direction = (_target.position - _weapon.FirePoint).normalized;

            return true;
        }
    }
}