using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject5ECharCreator
{
    [Serializable]
    public class Skills
    {
        //Here, we actually use the stats of the character to determine skill scores. Each skills has a stat from which it draws it base value. Proficiencies are then added on top of that, if they exist.

        public List<(string, int)> skills;//List of skills. Each skill is paired with a integer determining the amount of skills a character will have.

        public Skills(CharacterClass character)
        {



            //These are currently static due to the limitations of Tuples in List form. So this will probably change in the future. Profinciy bonuses will soon be added.
            skills = new List<(string, int)>
            {
                ("Acrobatics", character.Dexterity),
                ("Animal Handling", character.Wisdom),
                ("Arcana", character.Intelligence),
                ("Athletics", character.Strength),
                ("Deception", character.Charisma),
                ("History", character.Intelligence),
                ("Insight", character.Wisdom),
                ("Intimidation", character.Charisma),
                ("Investigation", character.Intelligence),
                ("Medicine", character.Wisdom),
                ("Nature", character.Intelligence),
                ("Perception", character.Wisdom),
                ("Performance", character.Charisma),
                ("Persuasion", character.Charisma),
                ("Religion", character.Intelligence),
                ("Sleight of Hand", character.Dexterity),
                ("Stealth", character.Dexterity),
                ("Survival", character.Wisdom),
            };


        }


    }
}
