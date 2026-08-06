using GR_Goap_Proto.GOAP.Internal;

namespace GR_Goap_Proto.GOAP
{
    public class GoalActionPlanner
    {
        /// <summary>Build a chain of actions that achieves a desired set of goals</summary>
        /// <remarks> Supply a list of available actions, a set of current states for the world and the characters involved,
        /// and the desired end goals. If the supplied actions can achieve the goal, the lowest cost chain is returned.
        /// Currently an exhaustive search is performed, an A* implementation is pending.
        /// </remarks>
        public bool MakePlan(List<GoalAction> availableActions, StatesCollection endGoals, StatesCollection startingStates, out Queue<GoalAction>? actionPlan)
        {
            actionPlan = default;

            List<GoalAction> usableActions = new();
            foreach (var a in availableActions)
            {
                if(a.IsAchievable()) usableActions.Add(a);
            }

            List<PlanningNode> leaves = new();
            PlanningNode startNode = new PlanningNode(null, 0, startingStates, null);

            bool success = BuildGraph(startNode, leaves, usableActions, endGoals);

            if (!success) return false;

            PlanningNode cheapest = null;
            foreach (PlanningNode pn in leaves)
            {
                if (cheapest == null) cheapest = pn;
                else
                {
                    if (pn.Cost < cheapest.Cost) cheapest = pn;
                }
            }

            Stack<GoalAction> result = new();
            PlanningNode node = cheapest;
            while (node != null)
            {
                if(node.Action != null)
                {
                    result.Push(node.Action);
                }
                node = node.ParentNode;
            }

            Queue<GoalAction> queue = new();
            while (result.Count != 0) queue.Enqueue(result.Pop());

            actionPlan = queue;
            return true;
        }
        

        private bool BuildGraph(PlanningNode nodeParent, List<PlanningNode> leaves, List<GoalAction> usableActions, StatesCollection goals)
        {
            bool foundPath = false;

            foreach (var action in usableActions)
            {
                if(action.PreconditionStatesAreMet(nodeParent.States))
                {
                    StatesCollection currentState = new StatesCollection(nodeParent.States);

                    //add this availableActions effects to the state
                    action.ApplyEffectsToState(currentState);

                    PlanningNode newNode = new PlanningNode(nodeParent, nodeParent.Cost + action.Cost, currentState, action);

                    if(GoalAchieved(goals, currentState))
                    {
                        leaves.Add(newNode);
                        foundPath = true;
                    }
                    else
                    {
                        List<GoalAction> subsetOfActions = ActionSubset(usableActions, action);
                        bool found = BuildGraph(newNode, leaves, subsetOfActions, goals);
                        if (found)
                        {
                            foundPath = true;
                        }
                    }
                }
            }
            return foundPath;
        }

        private bool GoalAchieved(StatesCollection goals, StatesCollection state)
        {
            foreach(var key in  goals.GetCopyOfCurrentKeys())
            {
                if (!state.HasState(key)) return false;
            }
            return true;
        }
        private List<GoalAction> ActionSubset(List<GoalAction> actions, GoalAction actionToRemove)
        {
            List<GoalAction> newActionSubset = new(actions);
            newActionSubset.Remove(actionToRemove);
            return newActionSubset;
        }
    }
}
