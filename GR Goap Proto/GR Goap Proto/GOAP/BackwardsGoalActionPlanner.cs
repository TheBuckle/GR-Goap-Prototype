using GR_Goap_Proto.GOAP.Internal;
using System.DirectoryServices.ActiveDirectory;

namespace GR_Goap_Proto.GOAP
{
    public class BackwardsGoalActionPlanner : GoalActionPlanner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="leaves"></param>
        /// <param name="usableActions"></param>
        /// <param name="goals"></param>
        /// <returns></returns>

        protected override bool BuildGraph(PlanningNode parentNode, List<PlanningNode> leaves, 
                                            List<GoalAction> usableActions, StatesCollection targetStates)
        {
            //bool foundPath = false;

            //target node has the goal states as preconditions to achieve

            PriorityQueue<GoalAction, float> actionsThatMoveTowardsGoal = new();
            List<GoalAction> usedActions = new();

            foreach (var action in usableActions)
            {
                var effectOfThisAction = action.GetTotalGoalEffectForStates(parentNode.States);
                if(effectOfThisAction > 0)
                {
                    actionsThatMoveTowardsGoal.Enqueue(action, effectOfThisAction);
                    usedActions.Add(action);
                }
            }

            if (actionsThatMoveTowardsGoal.Count == 0) return false;
            var actionsThatRemain = ActionSubset(usableActions, usedActions.ToArray());

            while (actionsThatMoveTowardsGoal.Count > 0)
            {
                var actionWithHighestEffect = actionsThatMoveTowardsGoal.Dequeue();

                var preconditions = actionWithHighestEffect.GetCopyOfPreconditions();

                if (actionWithHighestEffect.PreconditionStatesAreMet(targetStates))
                {
                    PlanningNode lastNode = new PlanningNode(parentNode, actionWithHighestEffect.Cost, preconditions, actionWithHighestEffect);

                    leaves.Add(lastNode);

                    return true;
                }

                PlanningNode nextNode = new PlanningNode(parentNode, actionWithHighestEffect.Cost, preconditions, actionWithHighestEffect);



                var success = BuildGraph(nextNode, leaves, actionsThatRemain, targetStates);

                if (success)
                {
                    leaves.Add(nextNode);
                    return true;
                }
            }

            return false;
        }

    }
}
