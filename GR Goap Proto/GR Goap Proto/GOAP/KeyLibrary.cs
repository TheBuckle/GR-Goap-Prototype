namespace GR_Goap_Proto.GOAP
{
    public class KeyLibrary
    {
        public const string Open = "Open";

        public struct GoalForNeeds
        {
            public const string Satiety = "Satiety";
            public const string Happiness = "Happiness";
            public const string Intoxication = "Intoxication";
            public const string Hydration = "Hydration";
            public const string Enrichment = "Enrichment";
        }
        public struct Inventory
        {
            public const string HasFood = "InventoryHasFood";
            public const string HasMeat = "InventoryHasMeat";
            public const string HasMoney = "InventoryHasMoney";

        }
        public struct Camp
        {
            public const string Made = "MadeCamp";
            public const string None = "NoCampMade";
        }
        public struct Kitchen
        {
            public const string HasFood = "KitchenHasFood";
            public const string HasMeat = "KitchenHasMeat";
        }
        public struct Skills
        {
            public const string CanHunt = "CanHunt";
            public const string CanFish = "CanFish";
            public const string CanPickLock = "CanPickLock";
            public const string CanCook = "CanCook";
        }
        public struct NeedLocation
        {
            public const string Mine = "NeedMine";
            public const string Home = "NeedHome";
            public const string DarkWood = "NeedDarkWood";
            public const string Pub = "NeedPub";
            public const string Lake = "NeedLake";
            public const string Shop = "NeedShop";
            public const string Assayist = "NeedAssayist";
        }
        public struct CharacterAt
        {
            public const string Mine = "CharAtMine";
            public const string Home = "CharAtHome";
            public const string DarkWood = "CharAtDarkWood";
            public const string Pub = "CharAtPub";
            public const string Lake = "CharAtLake";
            public const string Shop = "CharAtShop";
            public const string Assayist = "CharAtAssayist";

        }
        public struct CharacterVisited
        {
            public const string Mine = "CharVisitedMine";
            public const string Home = "CharVisitedHome";
            public const string DarkWood = "CharVisitedDarkWood";
            public const string Pub = "CharVisitedPub";
            public const string Lake = "CharVisitedLake";
            public const string Shop = "CharVisitedShop";
            public const string Assayist = "CharVisitedAssayist";

        }

    }
}
