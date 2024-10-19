using System;
using System.Collections.Generic;

namespace SpaceInvaders.Core
{
    public sealed class ConditionValidator
    {
        private readonly bool _isNegativeConditions;
        private readonly List<Func<bool>> _conditions = new();

        public ConditionValidator(bool isNegativeConditions)
        {
            _isNegativeConditions = isNegativeConditions;
        }
        
        public void Add(Func<bool> condition) => _conditions.Add(condition);
        
        public bool IsValid()
        {
            bool isSuccessCondition = false;
            
            foreach (Func<bool> condition in _conditions)
            {
                isSuccessCondition = condition.Invoke();

                if (isSuccessCondition)
                    break;
            }

            return (isSuccessCondition && _isNegativeConditions == false) || 
                   (isSuccessCondition == false && _isNegativeConditions);
        }
    }
}