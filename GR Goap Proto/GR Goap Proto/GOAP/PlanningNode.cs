namespace GR_Goap_Proto.GOAP.Internal
{
    public class PlanningNode
    {
        public PlanningNode? ParentNode;
        public float Cost;
        public StatesCollection States;
        public GoalAction? Action;

        public PlanningNode(PlanningNode? node, float cost, StatesCollection states, GoalAction? action)
        {
            ParentNode = node;
            Cost = cost;
            States = new StatesCollection(states);
            Action = action;
        }
    }
}
