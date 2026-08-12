
namespace GR_Goap_Proto.GOAP
{
    public class StatesCollection
    {
        /*
         *  A class to hold and manage a collection of state keys
         */
        private Dictionary<string, int> _managedStateKeys;

        public StatesCollection()
        {
            _managedStateKeys = new Dictionary<string, int>();
        }
        public StatesCollection(Dictionary<string, int> stateKeysToInitialiseWith)
        {
            _managedStateKeys = new Dictionary<string, int>(stateKeysToInitialiseWith);
        }
        public StatesCollection(StatesCollection statesToInitialiseWith)
        {
            _managedStateKeys = new Dictionary<string, int>();
            if (!statesToInitialiseWith.CopyMyStatesInto(_managedStateKeys))
            {
                //PENDING: log and handle error
            }
        }

        private bool CopyMyStatesInto(Dictionary<string, int> targetToInsertstateKeys)//may need alternate Overwrite/AppendStatesTo method
        {
            if(targetToInsertstateKeys == null) return false;
            foreach (var k in _managedStateKeys.Keys)
            {
                if(targetToInsertstateKeys.ContainsKey(k))
                {
                    //Bug? do I need to add, ignore, or replace here?
                    //this could be an issue later, could be context dependant
                    targetToInsertstateKeys[k] += _managedStateKeys[k];
                }
                else
                {
                    targetToInsertstateKeys.Add(k, _managedStateKeys[k]);
                }                    
            }
            return true;
        }

        /// <summary>Check collection for specified key</summary>
        /// <remarks>This calls ContainsKey on the managed dictionary.
        /// </remarks>
        public bool HasState(string stateKey) => _managedStateKeys.ContainsKey(stateKey);
        /// <summary>Add the specified state to the collection</summary>
        /// <remarks>If the state already exists it will increment the existing value
        /// by the specified amount.</remarks>
        public void AddState(string stateKey, int valueAdded) => Add(stateKey, valueAdded);        
        public void SetState(string stateKey, int value)
        {
            if (_managedStateKeys.ContainsKey(stateKey))
            {
                _managedStateKeys[stateKey] = value;
            }
            else { _managedStateKeys.Add(stateKey, value); }
        }
        public void RemoveState(string stateKey, int value) => Remove(stateKey, value);
        public bool TryGetValue(string key, out int value) => _managedStateKeys.TryGetValue(key, out value);

        /// <summary>Returns a snapshot of the current state keys.</summary>
        /// <remarks>The returned list is a point-in-time copy. Keys may be
        /// added or removed afterward; do not cache it—re-query when needed.</remarks>
        public IEnumerable<string> GetCopyOfCurrentKeys() => _managedStateKeys.Keys.ToList();

        /// <summary></summary>
        /// <remarks>
        /// </remarks>
        public bool DoesAchieveAll(StatesCollection stateToCheck)
        {
            foreach (var k in stateToCheck.GetCopyOfCurrentKeys())
            {
                if (!_managedStateKeys.TryGetValue(k, out var internalValue)) return false;
                if (stateToCheck.TryGetValue(k, out var checkingValue) 
                            && internalValue < checkingValue)
                    return false;                
            }
            return true;
        }
        public float GetTotalEffectImprovementOfTargetStates(StatesCollection stateToCheck)
        {
            float improvement = 0;
            foreach (var k in stateToCheck.GetCopyOfCurrentKeys())
            {
                //if it has the key, is the effect value positive
                if (_managedStateKeys.TryGetValue(k, out var internalValue))
                {
                    improvement += internalValue;
                }
            }
            return improvement;
        }
        public float CalculateTotalEffectsOfAllStates()
        {
            float improvement = 0;
            foreach (var k in _managedStateKeys.Keys)
            {
                improvement += _managedStateKeys[k];
            }
            return improvement;
        }
        public void RemoveStatesAll(StatesCollection effectsRemovedByAction)
        {
            foreach(var key in effectsRemovedByAction.GetCopyOfCurrentKeys())
            {
                if(effectsRemovedByAction.TryGetValue(key, out var value))
                {
                    Remove(key, value);
                }                
            }
        }
        public void AddStatesAll(StatesCollection effectsAppliedByAction)
        {
            foreach (var key in effectsAppliedByAction.GetCopyOfCurrentKeys())
            {
                if (effectsAppliedByAction.TryGetValue(key, out var value))
                {
                    Add(key, value);
                }
            }
        }

        private void Remove(string stateKey, int value)
        {
            if (_managedStateKeys.ContainsKey(stateKey))
            {
                _managedStateKeys[stateKey] -= value;
                if (_managedStateKeys[stateKey] <= 0) _managedStateKeys.Remove(stateKey);
            }
        }
        private void Add(string stateKey, int valueAdded)
        {
            _managedStateKeys.TryGetValue(stateKey, out int currentValue);
            _managedStateKeys[stateKey] = currentValue + valueAdded;
        }

        
    }
}
