using GR_Goap_Proto.GOAP.Internal;
using System.DirectoryServices.ActiveDirectory;

namespace GR_Goap_Proto.GOAP
{
    public class SimpleBackwardsGoalActionPlanner : GoalActionPlanner
    {
        protected override bool BuildGraph(List<PlanningNode> actionPathLeaves, List<GoalAction> usableActions,
                                            StatesCollection startingStates, StatesCollection endGoals)
        {
            //initial dummy seed data
            GoalAction endGoalAction = new GoalAction("Null Goal Action", endGoals, endGoals);
            PlanningNode endNode = new PlanningNode(null, 0, startingStates, endGoalAction);
            return BuildBackwardsGraph(endNode, actionPathLeaves, usableActions, startingStates);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="previousNode"></param>
        /// <param name="leaves"></param>
        /// <param name="usableActions"></param>
        /// <param name="goals"></param>
        /// <returns></returns>
        private bool BuildBackwardsGraph(PlanningNode previousNode, List<PlanningNode> leaves, 
                                            List<GoalAction> usableActions, StatesCollection startingStates)
        {
            PriorityQueue<GoalAction, float> actionsThatMoveTowardsGoal;
            List<GoalAction> usedActions;

            var preconditionToAchieve = previousNode.Action.GetCopyOfPreconditions();

            if (!TryQueueAllActionsThatEffectTargetPreconditions(usableActions, preconditionToAchieve,
                                                    out actionsThatMoveTowardsGoal, out usedActions)) 
            { return false; }

            var actionsThatAreNotUsed = CreateActionSubset(usableActions, usedActions.ToArray());

            while (actionsThatMoveTowardsGoal.Count > 0)
            {
                var actionWithHighestEffect = actionsThatMoveTowardsGoal.Dequeue();
                
                var preconditions = actionWithHighestEffect.GetCopyOfPreconditions();

                if (startingStates.EffectsAchievePreconditions(preconditions))// preconditions.DoesAchieveAll(startingStates))
                {//path complete
                    PlanningNode lastNode = new PlanningNode(previousNode, actionWithHighestEffect.Cost, startingStates, actionWithHighestEffect);
                    leaves.Add(lastNode);
                    return true;
                }

                PlanningNode nextNode = new PlanningNode(previousNode, actionWithHighestEffect.Cost, startingStates, actionWithHighestEffect);

                var success = BuildBackwardsGraph(nextNode, leaves, actionsThatAreNotUsed, startingStates);

                if (success) return true;
            }
            return false;
        }

        
    }
}
