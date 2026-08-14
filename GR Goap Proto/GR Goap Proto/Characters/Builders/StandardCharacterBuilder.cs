using GR_Goap_Proto.GOAP;

namespace GR_Goap_Proto.Characters.Builders
{
    public class StandardCharacterBuilder : ICharacterBuilder
    {
        public virtual StatesCollection GetBeliefs()
        {
            StatesCollection states = new StatesCollection();
            states.AddState(KeyLibrary.Inventory.HasMoney, 0);
            states.AddState(KeyLibrary.Inventory.HasFood, 0);
            return states;
        }

        public virtual StatesCollection GetSkills()
        {
            StatesCollection states = new StatesCollection();
            states.AddState(KeyLibrary.Skills.CanFish, 1);
            return states;
        }
    }
}
