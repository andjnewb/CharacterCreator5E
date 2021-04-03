using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject5ECharCreator
{
    public class CharDataContainer
    {
        //This class holds the members and function related to a "character", represented in the form of a character sheet.

        public string CharName { get; set; }
        public string ClassName { get; set; }//May change these to custom class obects later

        public string RaceName { get; set; }

        public string Background { get; set; }

        public CharacterClass characterClass;

        public CharDataContainer()
        {
            characterClass = new CharacterClass();
            //Nothing for now
        }

        public void RollStats()
        {
            characterClass.Roll();
        }





    }
}
