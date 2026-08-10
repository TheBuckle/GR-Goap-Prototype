namespace GR_Goap_Proto.GOAP.Internal
{
    public class PlanningNode
    {
        public PlanningNode? ParentNode;
        public float Cost; //A* G cost
        public StatesCollection States;
        public GoalAction? Action;
        public float HCost;
        public float FCost { get => Cost + FCost; }

        public PlanningNode(PlanningNode? node, float cost, StatesCollection states, GoalAction? action)
        {
            ParentNode = node;
            Cost = cost;
            States = new StatesCollection(states);
            Action = action;
        }
    }
}
