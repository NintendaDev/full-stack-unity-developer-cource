using System;
using Modules.Types.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SpaceInvaders.Attributes
{
    public sealed class Health : MonoBehaviour, IDamageable
    {
        [SerializeField, MinValue(0)] private float _maxValue;
        
        private MemorizedValue<float> _currentValue;

        public event Action Died;

        [ShowInInspector, ReadOnly, HideInEditorMode]
        public float CurrentValue 
        { 
            get => _currentValue.Value;
            
            private set
            {
                _currentValue.Set(Mathf.Max(0, value));

                if (_currentValue is { IsChanged: true, Value: 0 })
                    Died?.Invoke();
            }
        }


        private void Awake()
        {
            Reset();
        }

        public void TakeDamage(float damage)
        {
            if (damage <= 0)
                throw new ArgumentException("Damage must be greater or equal 0");
            
            CurrentValue -= damage;
        }

        public void Reset()
        {
            CurrentValue = _maxValue;
        }
    }
}