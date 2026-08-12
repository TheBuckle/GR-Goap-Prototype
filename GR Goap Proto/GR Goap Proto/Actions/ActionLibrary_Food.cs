using GR_Goap_Proto.GOAP;

namespace GR_Goap_Proto.Actions
{
    public class ActionLibrary_Food
    {
        public static GoalAction Eat()
        {
            GoalAction eatFood = new GoalAction("Eat Food");
            eatFood.Cost = 1;

            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Inventory.HasFood, 1);
            eatFood.InsertPreconditions(preconditions);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.GoalForNeeds.Satiety, 1);
            eatFood.InsertEffects(effects);

            return eatFood;
        }

        public static GoalAction StealFood()
        {
            GoalAction eatFood = new GoalAction("Steal Food");
            eatFood.Cost = 1;

            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Inventory.HasMoney, 0);
            eatFood.InsertPreconditions(preconditions);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.Inventory.HasFood, 1);
            eatFood.InsertEffects(effects);

            return eatFood;
        }

        public static GoalAction BuyFood()
        {
            GoalAction eatFood = new GoalAction("Buy Food");
            eatFood.Cost = 1;

            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Inventory.HasMoney, 1);
            eatFood.InsertPreconditions(preconditions);


            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.Inventory.HasFood, 1);
            eatFood.InsertEffects(effects);

            return eatFood;
        }

        public static GoalAction Forage()
        {
            GoalAction eatFood = new GoalAction("Forage");
            eatFood.Cost = 4;

            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Open, 0);
            eatFood.InsertPreconditions(preconditions);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.Inventory.HasFood, 1);
            eatFood.InsertEffects(effects);

            return eatFood;
        }

        public static GoalAction Hunt()
        {
            GoalAction eatFood = new GoalAction("Hunt");
            eatFood.Cost = 3;

            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Open, 0);
            eatFood.InsertPreconditions(preconditions);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.Inventory.HasMeat, 1);
            eatFood.InsertEffects(effects);

            return eatFood;
        }

        public static GoalAction Fish()
        {
            GoalAction eatFood = new GoalAction("Fish");
            eatFood.Cost = 4;

            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Open, 0);
            eatFood.InsertPreconditions(preconditions);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.Inventory.HasMeat, 1);
            eatFood.InsertEffects(effects);

            return eatFood;
        }

        public static GoalAction Cook()
        {
            GoalAction eatFood = new GoalAction("Cook");
            eatFood.Cost = 2;

            StatesCollection preconditions = new StatesCollection();
            preconditions.AddState(KeyLibrary.Inventory.HasMeat, 0);
            eatFood.InsertPreconditions(preconditions);

            StatesCollection effects = new StatesCollection();
            effects.AddState(KeyLibrary.Inventory.HasFood, 1);
            eatFood.InsertEffects(effects);

            return eatFood;
        }

    }
}
