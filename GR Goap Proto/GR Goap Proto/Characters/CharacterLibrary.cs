using GR_Goap_Proto.Characters.Builders;
using GR_Goap_Proto.GOAP;
using System.Security.Policy;

namespace GR_Goap_Proto.Characters
{
    public class CharacterLibrary
    {
        public static Character Tom()
        {
            return new Character("Tom", new StandardCharacterBuilder());
        }

        public static Character Dick()
        {
            return new Character("Dick", new StandardCharacterBuilder());
        }

        public static Character Harry()
        {
            return new Character("Harry", new StandardCharacterBuilder());
        }
    }
}
