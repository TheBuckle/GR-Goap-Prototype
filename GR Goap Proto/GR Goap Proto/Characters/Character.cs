using GR_Goap_Proto.GOAP;

namespace GR_Goap_Proto.Characters
{
    public class Character
    {


        Queue<GoalAction> _plannedActions; //to be filled by action planner
        private GoalAction _currentAction;

        string _currentGoal; //the state key of the current goal

    }
}
