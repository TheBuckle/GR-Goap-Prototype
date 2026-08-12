using GR_Goap_Proto.GOAP;

namespace GR_Goap_Proto.Characters
{
    public interface ICharacterBuilder
    {
        StatesCollection GetBeliefs();
        StatesCollection GetSkills();
    }
}
