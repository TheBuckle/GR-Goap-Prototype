using GR_Goap_Proto.GOAP;

namespace GR_Goap_Proto.Actions
{
    public class ActionLibrary_Food
    {
        public static GoalAction Eat()
        {
            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Inventory.HasFood, 1);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.GoalForNeeds.Satiety, 5);

            GoalAction eatFood = new GoalAction("Eat Food", preconditions, effects);
            eatFood.Cost = 1;
            return eatFood;
        }

        public static GoalAction StealFood()
        {
            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.CharacterTrait.Lawless, 1);
            //preconditions.AddState(KeyLibrary.Inventory.HasMoney, 0);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.Inventory.HasFood, 1);

            GoalAction eatFood = new GoalAction("Steal Food", preconditions, effects);
            eatFood.Cost = 1;

            return eatFood;
        }

        public static GoalAction BuyFood()
        {
            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Inventory.HasMoney, 1);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.Inventory.HasFood, 1);

            GoalAction eatFood = new GoalAction("Buy Food", preconditions, effects);
            eatFood.Cost = 1;

            return eatFood;
        }

        public static GoalAction Forage()
        {
            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Open, 0);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.Inventory.HasFood, 1);

            GoalAction eatFood = new GoalAction("Forage", preconditions, effects);
            eatFood.Cost = 4;

            return eatFood;
        }

        public static GoalAction Hunt()
        {
            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Open, 0);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.Inventory.HasMeat, 1);

            GoalAction eatFood = new GoalAction("Hunt", preconditions, effects);
            eatFood.Cost = 3;

            return eatFood;
        }

        public static GoalAction Fish()
        {
            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Open, 0);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.Inventory.HasMeat, 1);

            GoalAction eatFood = new GoalAction("Fish", preconditions, effects);
            eatFood.Cost = 4;

            return eatFood;
        }

        public static GoalAction Cook()
        {
            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Inventory.HasMeat, 0);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.Inventory.HasFood, 1);

            GoalAction eatFood = new GoalAction("Cook", preconditions, effects);
            eatFood.Cost = 2;

            return eatFood;
        }

    }
}
