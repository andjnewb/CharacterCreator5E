using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GroupProject5ECharCreator
{
    [Serializable]
    public class CharDataContainer
    {
        //This class holds the members and function related to a "character", represented in the form of a character sheet.

        public string CharName { get; set; }
        

        public Race race { get; set; }

        public string RaceName { get; set; }

        public string Background { get; set; }
        public int characterLevel;

        public CharacterClass characterClass;
        public Skills characterSkills;

        public CharDataContainer()
        {
            characterClass = new CharacterClass();
            characterLevel = 1;

            
        }



        public void RollStats()
        {
            //This is called when you click the roll stats button.
            characterClass.Roll();

            //Set the skills only when we roll. This helps avoid null value errors.
            characterSkills = new Skills(characterClass);
        }

        
    }

}
