using GR_Goap_Proto.Characters;
using GR_Goap_Proto.GOAP.Internal;

namespace GR_Goap_Proto.GOAP
{
    public class GoalActionPlanner_WorkingForward
    {
        /// <summary>Build a chain of actions that achieves a desired set of goals</summary>
        /// <remarks> Supply a list of available actions, a set of current states for the world and the characters involved,
        /// and the desired end goals. If the supplied actions can achieve the goal, the lowest cost chain is returned.
        /// Currently an exhaustive search is performed, an A* (or similar) improvement is pending.
        /// </remarks>
        public bool MakePlan(Character actingCharacter, List<GoalAction> availableActions, StatesCollection endGoals, StatesCollection startingStates, out Queue<GoalAction>? actionPlan)
        {
            actionPlan = default;

            List<GoalAction> usableActions = FindActionsUsableByCharacter(actingCharacter, availableActions);
            
            List<PlanningNode> leaves = new();
            PlanningNode startNode = new PlanningNode(null, 0, startingStates, null);

            bool success = BuildGraph(startNode, leaves, usableActions, endGoals);

            if (!success) return false;
            if(leaves.Count == 0) return false;

            PlanningNode cheapest = FindCheapestNode(leaves);            
            Stack<GoalAction> result = ChainActionsIntoResult(cheapest);
            actionPlan = ReverseStackIntoQueue(result);

            return true;
        }

        /// <summary>
        ///  Start at the start node and connect actions until you have reached the goal.
        /// </summary>
        /// <param name="nodeParent">The node from the previous step, which is linked to</param>
        /// <param name="leaves">A list of completed action paths</param>
        /// <param name="usableActions">The achieveable actions that are available for the graph</param>
        /// <param name="goals">The target goal that the graph will try to meet</param>
        /// <returns></returns>
        private bool BuildGraph(PlanningNode nodeParent, List<PlanningNode> leaves, List<GoalAction> usableActions, StatesCollection goals)
        {
            bool foundPath = false;

            foreach (var action in usableActions)
            {
                if(action.PreconditionStatesAreMet(nodeParent.States))
                {
                    StatesCollection updatedStates = new StatesCollection(nodeParent.States);

                    //add this actions effects to the state
                    action.ApplyEffectsToState(updatedStates);

                    PlanningNode newNode = new PlanningNode(nodeParent, nodeParent.Cost + action.Cost, updatedStates, action);

                    if(GoalAchieved(goals, updatedStates))
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

        private List<GoalAction> FindActionsUsableByCharacter(Character character, List<GoalAction> actions)
        {
            List<GoalAction> foundActions = new();

            foreach (var a in actions)
            {
                if (a.IsAchievableInWorld() && a.IsAchievableByCharacter(character)) foundActions.Add(a);
            }
            return foundActions;
        }
        private Queue<GoalAction> ReverseStackIntoQueue(Stack<GoalAction> result)
        {
            Queue<GoalAction> queue = new();
            while (result.Count != 0) queue.Enqueue(result.Pop());
            return queue;
        }

        private Stack<GoalAction> ChainActionsIntoResult(PlanningNode cheapest)
        {
            Stack<GoalAction> result = new();
            PlanningNode node = cheapest;
            while (node != null)
            {
                if (node.Action != null)
                {
                    result.Push(node.Action);
                }
                node = node.ParentNode;//when parentNode == null, end reached, exit
            }
            return result;
        }

        private PlanningNode FindCheapestNode(List<PlanningNode> leaves)
        {
            PlanningNode cheapest = leaves[0];
            foreach (PlanningNode pn in leaves)
            {
                if (pn.Cost < cheapest.Cost) cheapest = pn;
            }
            return cheapest;
        }
    }
}
