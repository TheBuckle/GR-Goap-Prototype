using GR_Goap_Proto.GOAP;
using GR_Goap_Proto.GOAP.Test_Data;

namespace GR_Goap_Proto.Actions
{
    public class ActionLibraryTestData
    {
        public static GoalAction TestActionDoRedGoal()
        {
            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(TestKeyLibrary.GoalRed.HasRed, 1);

            StatesCollection effects = new StatesCollection();
            effects.AddState(TestKeyLibrary.GoalRed.RedLevel, 1);

            GoalAction goalIncRed = new GoalAction("Increase Red to complete goal", preconditions, effects, new StatesCollection());
            goalIncRed.Cost = 1;
            return goalIncRed;
        }
        public static GoalAction PickupRed()
        {
            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(TestKeyLibrary.GoalRed.LocalRedAmount, 1);

            StatesCollection effects = new StatesCollection();
            effects.AddState(TestKeyLibrary.GoalRed.HasRed, 1);

            GoalAction goalIncRed = new GoalAction("Get some Red", preconditions, effects, new StatesCollection());
            goalIncRed.Cost = 1;
            return goalIncRed;
        }

        public static GoalAction FindRed()
        {
            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(TestKeyLibrary.Open, 1);

            StatesCollection effects = new StatesCollection();
            effects.AddState(TestKeyLibrary.GoalRed.LocalRedAmount, 1);

            GoalAction goalIncRed = new GoalAction("Go to the Red", preconditions, effects, new StatesCollection());
            goalIncRed.Cost = 1;
            return goalIncRed;
        }
    }
}
