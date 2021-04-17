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
        public string ClassName { get; set; }//May change these to custom class obects later

        public Race race { get; set; }

        public string RaceName { get; set; }

        public List<RacialBonus> bonuses;

        public string Background { get; set; }
        public int characterLevel;

        public CharacterClass characterClass;

        public CharDataContainer()
        {
            characterClass = new CharacterClass();
            characterLevel = 1;
            bonuses = new List<RacialBonus>();

            
        }

        public void AddStatBonus(RacialBonus bonus, int amount)
        {
            //Each bonus is +1 to a stat. We need to keep them seperate, in case the user changes them


            //This look stupid
            for (int i = 0; i < amount; i++)
            {
                bonuses.Add(bonus);
            }
            
        }



        public void RollStats()
        {
            //This is called when you click the roll stats button.
            characterClass.Roll();
        }

        
    }

}
