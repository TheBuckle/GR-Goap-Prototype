using GR_Goap_Proto.Actions;
using GR_Goap_Proto.Characters;
using GR_Goap_Proto.GOAP;

namespace GR_Goap_Proto.Simulator
{
    public class Simulation
    {

        private StatesCollection _world;


        public Simulation() { 
            _world = new StatesCollection();
        }

        public void RunSimulation()
        {
            ForwardGoalActionPlanner planner = new ForwardGoalActionPlanner();

            Character tom = CharacterLibrary.Tom();

            List<GoalAction> actions = new List<GoalAction>();
            actions.Add(ActionLibrary_Food.Eat());
            actions.Add(ActionLibrary_Food.BuyFood());
            actions.Add(ActionLibrary_Food.StealFood());
            actions.Add(ActionLibrary_Food.Hunt());
            actions.Add(ActionLibrary_Food.Cook());
            actions.Add(ActionLibrary_Food.Forage());
            actions.Add(ActionLibrary_Food.Fish());


            StatesCollection endGoals = new StatesCollection();
            endGoals.AddState(KeyLibrary.GoalForNeeds.Satiety, 1);


            StatesCollection startingStates = new StatesCollection();
            startingStates.AddState(KeyLibrary.GoalForNeeds.Satiety, 0);


            if (planner.MakePlan(tom, actions, endGoals, startingStates, out var actionPlan))
            {
                var a = 1;//dummy code for break point
            }


        }
    }
}
