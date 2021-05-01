using System;
using System.Drawing;

namespace GroupProject5ECharCreator
{
    [Serializable]
    public class CharDataContainer
    {
        //This class holds the members and function related to a "character", represented in the form of a character sheet.

        //Name of the character, that the player chooses
        public string CharName { get; set; }

        //The players race
        public Race race { get; set; }

        public string RaceName { get; set; }

        public Tuple<string, string> background;
        public int characterLevel;

        public Image characterAvatar;

        public CharacterClass characterClass;
        public Skills characterSkills;

        public CharDataContainer()
        {
            characterClass = new CharacterClass();
            characterLevel = 1;


        }

        public void SetModifiers()
        {
            //Set the modifiers in CharacterClass, will be useful for later.

            if (race == null)
                return;

            foreach (var item in race.bonuses)
            {
                //switch (item.Item1)
                //{
                //    case RacialBonus.ConstBonus:
                //        characterClass.ClassData.constitutionModifier += item.Item2;
                //            break;
                //    case RacialBonus.StrBonus:
                //        characterClass.ClassData.strengthModifier += item.Item2;
                //        break;
                //    case RacialBonus.WisdomBonus:
                //        characterClass.ClassData.wisdomModifier += item.Item2;
                //        break;
                //    case RacialBonus.IntBonus:
                //        characterClass.ClassData.intelligenceModifier += item.Item2;
                //        break;
                //    case RacialBonus.CharismaBonus:
                //        characterClass.ClassData.charismaModifier += item.Item2;
                //        break;
                //    case RacialBonus.DexBonus:
                //        characterClass.ClassData.DexterityModifier += item.Item2;
                //        break;
                //}

                //Long if chains suck but a switch won't work because we are required to break >:|
                if (item.Item1 == RacialBonus.ConstBonus)
                {
                    characterClass.ClassData.constitutionModifier += item.Item2;
                }

                if (item.Item1 == RacialBonus.StrBonus)
                {
                    characterClass.ClassData.strengthModifier += item.Item2;
                }

                if (item.Item1 == RacialBonus.WisdomBonus)
                {
                    characterClass.ClassData.wisdomModifier += item.Item2;
                }

                if (item.Item1 == RacialBonus.IntBonus)
                {
                    characterClass.ClassData.intelligenceModifier += item.Item2;
                }

                if (item.Item1 == RacialBonus.CharismaBonus)
                {
                    characterClass.ClassData.charismaModifier += item.Item2;
                }

                if (item.Item1 == RacialBonus.DexBonus)
                {
                    characterClass.ClassData.DexterityModifier += item.Item2;
                }


            }

        }

        public void UpdateArmorClass()
        {
            //This is the only place that I could put this function. Some code refactoring is definitely needed. This also assume no armor. With armor, you just add the AC of the armor.
            switch (characterClass.ClassName)
            {
                case "Barbarian":
                    characterClass.ArmorClass = 10 + characterClass.ClassData.DexterityModifier + characterClass.ClassData.constitutionModifier;
                    break;
                case "Monk":
                    characterClass.ArmorClass = 10 + characterClass.ClassData.DexterityModifier + characterClass.ClassData.wisdomModifier;
                    break;
                default:
                    characterClass.ArmorClass = 10 + characterClass.ClassData.DexterityModifier;
                    break;
            }
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
