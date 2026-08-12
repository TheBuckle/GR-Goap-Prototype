using GR_Goap_Proto.Characters;
using GR_Goap_Proto.GOAP.Internal;

namespace GR_Goap_Proto.GOAP
{
    public abstract class GoalActionPlanner
    {
        /// <summary>Build a chain of actions that achieves a desired set of goals</summary>
        /// <remarks> Supply a list of available actions, a set of current states for the world and the characters involved,
        /// and the desired end goals. If the supplied actions can achieve the goal, the lowest cost chain is returned.
        /// </remarks>
        public bool MakePlan(Character actingCharacter, List<GoalAction> availableActions, StatesCollection endGoals, StatesCollection startingStates, out Queue<GoalAction>? actionPlan)
        {
            actionPlan = default;

            List<GoalAction> usableActions = FindActionsUsableByCharacter(actingCharacter, availableActions);

            List<PlanningNode> leaves = new();
            PlanningNode startNode = new PlanningNode(null, 0, startingStates, null);

            bool success = BuildGraph(startNode, leaves, usableActions, endGoals);

            if (!success) return false;
            if (leaves.Count == 0) return false;

            PlanningNode cheapest = FindCheapestNode(leaves);
            Stack<GoalAction> result = ChainActionsIntoResult(cheapest);
            actionPlan = ReverseStackIntoQueue(result);

            return true;
        }
        protected abstract bool BuildGraph(PlanningNode nodeParent, List<PlanningNode> leaves, 
                                            List<GoalAction> usableActions, StatesCollection targetStates);
        
        protected bool GoalAchieved(StatesCollection goals, StatesCollection state)
        {
            foreach (var key in goals.GetCopyOfCurrentKeys())
            {
                if (!state.HasState(key)) return false;
            }
            return true;
        }
        protected List<GoalAction> ActionSubset(List<GoalAction> actions, GoalAction actionToRemove)
        {
            List<GoalAction> newActionSubset = new(actions);
            newActionSubset.Remove(actionToRemove);
            return newActionSubset;
        }

        protected List<GoalAction> FindActionsUsableByCharacter(Character character, List<GoalAction> actions)
        {
            List<GoalAction> foundActions = new();

            foreach (var a in actions)
            {
                if (a.IsAchievableInWorld() && a.IsAchievableByCharacter(character)) foundActions.Add(a);
            }
            return foundActions;
        }
        protected Queue<GoalAction> ReverseStackIntoQueue(Stack<GoalAction> result)
        {
            Queue<GoalAction> queue = new();
            while (result.Count != 0) queue.Enqueue(result.Pop());
            return queue;
        }
        protected Stack<GoalAction> ChainActionsIntoResult(PlanningNode cheapest)
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
        protected PlanningNode FindCheapestNode(List<PlanningNode> leaves)
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
