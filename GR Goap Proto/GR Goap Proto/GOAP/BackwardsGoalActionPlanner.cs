using GR_Goap_Proto.GOAP.Internal;

namespace GR_Goap_Proto.GOAP
{
    public class BackwardsGoalActionPlanner : GoalActionPlanner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeParent"></param>
        /// <param name="leaves"></param>
        /// <param name="usableActions"></param>
        /// <param name="goals"></param>
        /// <returns></returns>

        protected override bool BuildGraph(PlanningNode nodeParent, List<PlanningNode> leaves, 
                                            List<GoalAction> usableActions, StatesCollection targetStates)
        {
            bool foundPath = false;

            foreach (var action in usableActions)
            {



            }




            return foundPath;
        }

    }
}
