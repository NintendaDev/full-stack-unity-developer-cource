using System;
using Modules.Types.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SpaceInvaders.Attributes
{
    public sealed class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private bool _isImmortal;
        [SerializeField, MinValue(0)] private float _maxValue;
        
        private MemorizedValue<float> _currentValue;

        public event Action<float> Changed;

        public event Action Died;

        [ShowInInspector, ReadOnly, HideInEditorMode]
        public float CurrentValue 
        { 
            get => _currentValue.Value;
            
            private set
            {
                _currentValue.Set(Mathf.Max(0, value));

                if (_currentValue.IsChanged)
                {
                    Changed?.Invoke(_currentValue.Value);

                    if (_currentValue.Value == 0)
                        Died?.Invoke();
                }
            }
        }

        public void Initialize()
        {
            Reset();
        }

        public void TakeDamage(float damage)
        {
            if (_isImmortal)
                return;
            
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