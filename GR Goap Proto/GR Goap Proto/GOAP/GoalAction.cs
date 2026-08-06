namespace GR_Goap_Proto.GOAP
{
    public class GoalAction
    {
        private string _name;
        private StatesCollection _requiredPreconditionsForAction;
        private StatesCollection _precludingPreconditionsForAction;
        private StatesCollection _effectsAppliedByAction;
        private StatesCollection _effectsRemovedByAction;

        public string Name { get => _name; }
        public int Cost { get; set; } //need to create a cost class to handle the complexities of cost

        public GoalAction(string name)
        {
            _name = name;

            _requiredPreconditionsForAction = new();
            _precludingPreconditionsForAction = new();
            _effectsAppliedByAction = new();
            _effectsRemovedByAction = new();
        }

        public bool IsAchievable()
        {
            return true; //pending
        }

        public void InsertEffects(StatesCollection statesApplied, StatesCollection statesRemoved)//needs to be better
        {
            _effectsAppliedByAction = statesApplied;
            _effectsRemovedByAction = statesRemoved;
        }
        public void InsertPreconditions(StatesCollection requiredStates, StatesCollection precludedStates)//needs to be better
        {
            _requiredPreconditionsForAction = requiredStates;
            _precludingPreconditionsForAction = precludedStates;
        }

        public bool PreconditionStatesAreMet(StatesCollection stateToCheck)
        {
            return stateToCheck.DoesContainAll(_requiredPreconditionsForAction.GetCopyOfCurrentKeys()) &&
                    stateToCheck.DoesNotContainAll(_precludingPreconditionsForAction.GetCopyOfCurrentKeys());
        }

        public void ApplyEffectsToState(StatesCollection stateToReceiveEffects)
        {
            stateToReceiveEffects.RemoveStatesAll(_effectsRemovedByAction);
            stateToReceiveEffects.AddStatesAll(_effectsAppliedByAction);
        }
    }
}
