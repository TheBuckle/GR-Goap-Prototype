using GR_Goap_Proto.GOAP.Internal;

namespace GR_Goap_Proto.GOAP
{
    public class ForwardGoalActionPlanner : GoalActionPlanner
    {

        /// <summary>
        /// Start at the start node and connect actions until you have reached the goal.
        /// Currently an exhaustive search is performed, an A* (or similar) improvement is pending.
        /// </summary>
        /// <param name="nodeParent">The node from the previous step, which is linked to</param>
        /// <param name="actionPathLeaves">A list of completed action paths</param>
        /// <param name="usableActions">The achieveable actions that are available for the graph</param>
        /// <param name="targetStates">The target goal that the graph will try to meet</param>
        /// <returns></returns>
        protected override bool BuildGraph(List<PlanningNode> actionPathLeaves, List<GoalAction> usableActions, 
                                            StatesCollection startingStates, StatesCollection endGoals)
        {
            PlanningNode startNode = new PlanningNode(null, 0, startingStates, null);
            return BuildForwardGraph(startNode, actionPathLeaves, usableActions, endGoals);
        }

        private bool BuildForwardGraph(PlanningNode nodeParent, List<PlanningNode> leaves,
                                            List<GoalAction> usableActions, StatesCollection targetStates)
        {
            bool foundPath = false;

            foreach (var action in usableActions)
            {
                if (action.PreconditionStatesAreMet(nodeParent.States))
                {
                    StatesCollection updatedStates = new StatesCollection(nodeParent.States);

                    //add this actions effects to the state
                    action.ApplyEffectsToState(updatedStates);

                    PlanningNode newNode = new PlanningNode(nodeParent, nodeParent.Cost + action.Cost, updatedStates, action);

                    if (GoalAchieved(targetStates, updatedStates))
                    {
                        leaves.Add(newNode);
                        foundPath = true;
                    }
                    else
                    {
                        List<GoalAction> subsetOfActions = CreateActionSubset(usableActions, new GoalAction[] { action });
                        bool found = BuildForwardGraph(newNode, leaves, subsetOfActions, targetStates);
                        if (found)
                        {
                            foundPath = true;
                        }
                    }
                }
            }
            return foundPath;
        }
        
    }
}
