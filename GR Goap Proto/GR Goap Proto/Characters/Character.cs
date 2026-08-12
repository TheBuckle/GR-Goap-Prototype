using GR_Goap_Proto.GOAP;

namespace GR_Goap_Proto.Characters
{
    public class Character
    {
        public string Name;
        public StatesCollection Beliefs;
        public StatesCollection Skills;

        Queue<GoalAction> _plannedActions; //to be filled by action planner
        private GoalAction _currentAction;

        string _currentGoal; //the state key of the current goal

        public Character(string name, ICharacterBuilder builder)
        {
            Name = name;
            Beliefs = builder.GetBeliefs();
            Skills = builder.GetSkills();
        }

    }
}
