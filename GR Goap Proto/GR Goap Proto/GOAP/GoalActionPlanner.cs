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

            bool success = BuildGraph(leaves, usableActions, startingStates, endGoals);

            if (!success) return false;
            if (leaves.Count == 0) return false;

            PlanningNode cheapest = FindCheapestNode(leaves);
            Stack<GoalAction> result = ChainActionsIntoResult(cheapest);
            actionPlan = ReverseStackIntoQueue(result);

            return true;
        }
        protected abstract bool BuildGraph(List<PlanningNode> actionPathLeaves, List<GoalAction> usableActions,
                                            StatesCollection startingStates, StatesCollection endGoals);
        
        protected bool GoalAchieved(StatesCollection goals, StatesCollection state)
        {
            foreach (var key in goals.GetCopyOfCurrentKeys())
            {
                if (!state.HasState(key)) return false;
            }
            return true;
        }
        protected List<GoalAction> CreateActionSubset(List<GoalAction> actions, GoalAction[] actionsToRemove)
        {
            List<GoalAction> newActionSubset = new(actions);
            foreach(var a  in actionsToRemove)
            {
                newActionSubset.Remove(a);
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usableActions">A list of actions to be evaluated</param>
        /// <param name="preconditions">The goals that the actions effects must achieve</param>
        /// <param name="queuedActionsThatAchievePreconditions"></param>
        /// <param name="usedActions"></param>
        /// <returns></returns>
        protected bool TryQueueAllActionsThatEffectTargetPreconditions(List<GoalAction> usableActions, StatesCollection preconditions,
                            out PriorityQueue<GoalAction, float> queuedActionsThatAchievePreconditions,
                            out List<GoalAction> usedActions)
        {
            queuedActionsThatAchievePreconditions = new();
            usedActions = new();

            foreach (var action in usableActions)
            {
                var effectOfThisAction = action.GetTotalGoalEffectForTargetStates(preconditions);
                if (effectOfThisAction > 0)
                {
                    queuedActionsThatAchievePreconditions.Enqueue(action, effectOfThisAction);
                    usedActions.Add(action);
                }
            }

            if (queuedActionsThatAchievePreconditions.Count == 0) return false;
            return true;
        }
    }
}
