using System;

namespace Modules.Types.Scripts
{
    public struct MemorizedValue<T>
    {
        private T _currentValue;
        private T _previousValue;
        
        public MemorizedValue(T value)
        {
            _currentValue = value;
            _previousValue = value;
        }
        
        public bool IsChanged => _previousValue.Equals(_currentValue) == false;
        
        public T Value => _currentValue;

        public void Set(T value)
        {
            _previousValue = _currentValue;
            _currentValue = value;
        }
    }
}