using GR_Goap_Proto.Characters;

namespace GR_Goap_Proto.GOAP
{
    public class GoalAction
    {
        private readonly string _name;
        private readonly StatesCollection _requiredPreconditionsForAction;
        private readonly StatesCollection _effectsAppliedByAction;
        private readonly float _totalEffects;

        public string Name { get => _name; }
        public int Cost { get; set; } //need to create a cost class to handle the complexities of cost
        public float TotalEffects { get => _totalEffects;}

        public GoalAction(string name, StatesCollection preconditions, StatesCollection effects)
        {
            _requiredPreconditionsForAction = preconditions;
            _effectsAppliedByAction = effects;
            _name = name;
            _totalEffects = _effectsAppliedByAction.CalculateTotalEffectsOfAllStates();
        }
        /// <summary>
        /// Determines if this action is available under the current world state conditions
        /// </summary>
        /// <remarks>This checks is available to be performed, should an appropriate character attempt to do so.</remarks>        
        public bool IsAchievableInWorld()
        {
            return true; //pending
        }
        /// <summary>
        /// Determines if the provided character is capble of performing the action.
        /// </summary>
        /// <remarks>This assumes that the actions is available to be performed in the current world states,
        /// and only checks the characters capability of perfroming it.</remarks>
        public bool IsAchievableByCharacter(Character character)
        {
            return true; //pending
        }

        public bool PreconditionStatesAreMet(StatesCollection stateToCheck)
        {
            return stateToCheck.DoesAchieveAll(_requiredPreconditionsForAction);
        }
        public float GetTotalGoalEffectForStates(StatesCollection stateToCheck)
        {
            return _effectsAppliedByAction.GetTotalEffectImprovementOfTargetStates(stateToCheck);
            //return stateToCheck.GetTotalEffectImprovementOfTargetStates(_effectsAppliedByAction);
        }
        public void ApplyEffectsToState(StatesCollection stateToReceiveEffects)
        {
            stateToReceiveEffects.AddStatesAll(_effectsAppliedByAction);
        }

        public StatesCollection GetCopyOfPreconditions()
        {
            return new StatesCollection(_requiredPreconditionsForAction);
        }
        
    }
}
