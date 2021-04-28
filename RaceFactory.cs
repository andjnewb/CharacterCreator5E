using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject5ECharCreator
{
    [Serializable]
    public enum RacialBonus
    {
        //These refer to the stat boosts that each race gets, not the traits such as Darkvision or Bravery
        StrBonus,
        DexBonus,
        IntBonus,
        ConstBonus,
        CharismaBonus,
        WisdomBonus,

    }

    [Serializable]
    public class RacialTraitsContainer
    {
        public List<(string, string)> dwarfTraits = new List<(string, string)> 
        {
            ("Darkvision", "You touch a willing creature to grant it the ability to see in the dark. For the duration, that creature has darkvision out to a range of 60 feet."),
            ("Dwarven Resilience","You have advantage on Saving Throws against poison, and you have Resistance against poison damage."),
            ("Dwarven Combat Training","You have proficiency with the Battleaxe, Handaxe, Light Hammer, and Warhammer."),
            ("Tool Proficiency","You gain proficiency with the artisan’s tools of your choice: smith’s tools, brewer’s supplies, or mason’s tools."),
            ("Stonecunning","Whenever you make an Intelligence (History) check related to the Origin of stonework, you are considered proficient in the History skill and add double your Proficiency Bonus to the check, instead of your normal Proficiency Bonus."),
            ("Languages","Common, Dwarvish")

        };

        public List<(string, string)> halfelfTraits = new List<(string, string)> 
        {
            ("Darkvision", "You touch a willing creature to grant it the ability to see in the dark. For the duration, that creature has darkvision out to a range of 60 feet."),
            ("Fey Ancestry","You have advantage on Saving Throws against being Charmed, and magic can’t put you to sleep."),
            ("Skill Versatility","You gain proficiency in two Skills of your choice."),
            ("Languages","Common, Elvish")
        };

        public List<(string, string)> elfTraits = new List<(string, string)> 
        {
            ("Darkvision", "You touch a willing creature to grant it the ability to see in the dark. For the duration, that creature has darkvision out to a range of 60 feet."),
            ("Keen Senses","You have proficiency in the Perception skill."),
            ("Fey Ancestry","You have advantage on Saving Throws against being Charmed, and magic can’t put you to sleep."),
            ("Trance","Elves don’t need to sleep. Instead, they meditate deeply, remaining semiconscious, for 4 hours a day. (The Common word for such meditation is “trance.”) While meditating, you can dream after a fashion; such dreams are actually mental exercises that have become reflexive through years of practice. After Resting in this way, you gain the same benefit that a human does from 8 hours of sleep."),
            ("Languages","Common, Elvish")
        };

        public List<(string, string)> humanTraits = new List<(string, string)>
        {
            ("Languages","Common, Elvish")
        };

        public List<(string, string)> tieflingTraits = new List<(string, string)>
        {
            ("Darkvision", "You touch a willing creature to grant it the ability to see in the dark. For the duration, that creature has darkvision out to a range of 60 feet."),
            ("Hellish Resistance","You have Resistance to fire damage"),
            ("Infernal Legacy","You know the Thaumaturgy cantrip. At level three, you can cast Hellish Rebuke once per rest.  At level 5, you can cast Darkness once per rest. You perform a charisma check for casting these."),
            ("Lanugages","Common, Infernal")
        };

        public List<(string, string)> halflingTraits = new List<(string, string)>
        {
            ("Lucky","When you roll a 1 on The D20 for an Attack roll, ability check, or saving throw, you can reroll the die and must use the new roll."),
            ("Brave","You have advantage on Saving Throws against being Frightened."),
            ("Halfling Nimbleness","You can move through the space of any creature that is of a size larger than yours."),
            ("Languages","Common, Halfling")
        };

        public List<(string, string)> gnomeTraits = new List<(string, string)>
        {
            ("Darkvision","You can see in dim light within 60 feet of you as if it were bright light, and in Darkness as if it were dim light."),
            ("Gnome Cunning","You have advantage on all Intelligence, Wisdom, and Charisma Saving Throws against magic."),
            ("Languages","Common, Gnomish")

        };

        public List<(string, string)> halforcTraits = new List<(string, string)>
        {
            ("Darkvision","Thanks to your orc blood, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern color in darkness, only shades of gray."),
            ("Menacing","You gain proficiency in the Intimidation skill."),
            ("Relentless Endurance","When you are reduced to 0 hit points but not killed outright, you can drop to 1 hit point instead. You can't use this feature again until you finish a long rest."),
            ("Savage Attacks","When you score a critical hit with a melee weapon attack, you can roll one of the weapon's damage dice one additional time and add it to the extra damage of the critical hit."),
            ("Languages","Common, Orc")
        };

        public List<(string, string)> dragonbornTraits = new List<(string, string)>
        {
            ("Draconic Ancesty","Choose your ancestry to determine your breath ability."),
            ("Languages", "Common, Draconic")
        };

        public List<(string, string)> GetRacialTraits(string raceName)
        {
            //This is probably just a placeholder, ideally we wou
            switch (raceName)
            {
                case "Dwarf":
                    return dwarfTraits;
                case "Elf":
                    return elfTraits;
                case "Half Elf":
                    return halfelfTraits;
                case "Dragonborn":
                    return dragonbornTraits;
                case "Human":
                    return humanTraits;
                case "Tiefling":
                    return tieflingTraits;
                case "Half Orc":
                    return halforcTraits;
                case "Gnome":
                    return gnomeTraits;
                case "Halfling":
                    return halflingTraits;

                default:break;
            }

            return null;
        }



    }


    [Serializable]
    public abstract class Race
    {
        public List<(RacialBonus, int)> bonuses;//Contains all of the bonuses for that race. It is a list, since some races have multiple or let you select which bonuses you want. 
        public List<(string, string)> racialTraits;
        public RacialTraitsContainer container = new RacialTraitsContainer();

        public string RaceName;
        public string RaceDescription;
    }

    //RACES//
    [Serializable]
    public class Dwarf : Race
    {
        //This class inherits from the abstract class Race
        public Dwarf(int ConstBonusAmount)
        {
            

            bonuses =  new List<(RacialBonus, int)> { (RacialBonus.ConstBonus, ConstBonusAmount)};//This is our list of tuples. Dwarves, for examples. get a constitution bonus of +2. For some reason, I can't get .Add() to work for this list so we're going with initializing it here for now.
            RaceName = "Dwarf"; //Might not be necessary, but could be useful for later.
            RaceDescription = "Dwarves are hardy masters of both stone and metal. They make excellent fighters.";
            racialTraits = container.GetRacialTraits(RaceName);
        }

    }

    [Serializable]
    public class Elf : Race
    {
        //This class inherits from the abstract class Race
       
        public Elf(int DexterityBonusAmount)
        {
            
            
            bonuses = new List<(RacialBonus, int)> { (RacialBonus.DexBonus, DexterityBonusAmount) };
            RaceName = "Elf";
            RaceDescription = "Graceful, magical, and one with nature, Elves are excellent fighters with innate abilities that make them in-tune with the natural world.";
            racialTraits = container.GetRacialTraits(RaceName);
        }
    }

    [Serializable]
    public class Dragonborn : Race 
    {
        //Dragonborn get two racial bonuses. This is a work around.


        public Dragonborn(int StrBonusAmount, int CharismaBonusAmount)
        {
            


            bonuses = new List<(RacialBonus, int)> { (RacialBonus.StrBonus, StrBonusAmount) , (RacialBonus.CharismaBonus, CharismaBonusAmount) };
            RaceName = "Dragonborn";
            RaceDescription = "Dragonborn are known for their striking appearance, with a Humanoid body covered in scales. They are strong and charismatic.";
            racialTraits = container.GetRacialTraits(RaceName);
        }

   

    }

    [Serializable]
    public class Gnome : Race
    {
        //This class inherits from the abstract class Race
        
        public Gnome(int IntBonusAmount)
        {
       
           

            bonuses = new List<(RacialBonus, int)> { (RacialBonus.IntBonus, IntBonusAmount) };
            RaceName = "Gnome";
            RaceDescription = "Don't let the Gnome's dimunitive stature fool you. They are bright with ample energy and intelligence to match it.";
            racialTraits = container.GetRacialTraits(RaceName);
        }
    }

    [Serializable]
    public class HalfElf : Race 
    {
        //The situation is different for a half-elf, since they get to pick 2 bonuses to add +1 to, in addition to their inherent +2 to charisma. Half-elf OP


        public HalfElf(RacialBonus choice1, RacialBonus choice2)
        {
            bonuses = new List<(RacialBonus, int)> { (RacialBonus.CharismaBonus, 2) ,(choice1, 1), (choice2,1)};
            RaceName = "Half Elf";
            RaceDescription = "Half-elves are the perfect mixture of Human and Elf. They are not confined by a zealous reverance of nature, nor a lust for technological advancement.";
            racialTraits = container.GetRacialTraits(RaceName);
        }


    }

    [Serializable]
    public class Halfling : Race 
    {
        public Halfling(int DexBonusAmount)
        {
            //Halfings always get +2 to Dex but we have it as a parameter just in case you wanted to modify these easily from the factory
            bonuses = new List<(RacialBonus, int)> {(RacialBonus.DexBonus, DexBonusAmount) };
            RaceName = "Halfling";
            RaceDescription = "Haflings survive in a world of giants by the nimbleness of their fingers, and almost all of their race are brave even in the face of certain demise.";
            racialTraits = container.GetRacialTraits(RaceName);
        }


    }

    [Serializable]
    public class HalfOrc : Race
    {
        public HalfOrc(int StrengthBonusAmount, int ConstitutionBonusAmount)
        {
            bonuses = new List<(RacialBonus, int)> { (RacialBonus.StrBonus, StrengthBonusAmount), (RacialBonus.ConstBonus, ConstitutionBonusAmount) };
            RaceName = "Half Orc";
            RaceDescription = "This crossbreed of Human and Orc makes for a fearsome warrior, capable of destroying almost any other in single hand-to-hand combat.";
            racialTraits = container.GetRacialTraits(RaceName);
        }
    }

    [Serializable]
    public class Human : Race
    {
        public Human(int AbilityBonusAmount)
        {
            //Humans get +1 to every stat, but we have a parameter here in case you wanted to easily make an overpowered or weaker human.
            bonuses = new List<(RacialBonus, int)> 
            { 
                (RacialBonus.StrBonus, AbilityBonusAmount), 
                (RacialBonus.ConstBonus, AbilityBonusAmount), 
                (RacialBonus.DexBonus, AbilityBonusAmount), 
                (RacialBonus.IntBonus, AbilityBonusAmount), 
                (RacialBonus.WisdomBonus, AbilityBonusAmount),
                (RacialBonus.CharismaBonus, AbilityBonusAmount)
            };
            RaceName = "Human";
            RaceDescription = "Humans are the drivers of innovation, and show no preference for any particular skillset. They are highly diverse and can be fearsome warriors or excellent magicians.";
            racialTraits = container.GetRacialTraits(RaceName);

        }
    }
    [Serializable]
    public class Tiefling : Race
    {
        public Tiefling(int CharismaBonusAmount, int IntelligenceBonusAmount)
        {
            bonuses = new List<(RacialBonus, int)> { (RacialBonus.CharismaBonus, CharismaBonusAmount), (RacialBonus.IntBonus, IntelligenceBonusAmount) };
            RaceName = "Tiefling";
            RaceDescription = "Distrusted by many, the tiefling almost always possesses much charisma and intelligence.";
            racialTraits = container.GetRacialTraits(RaceName);
        }
    }



    //FACTORIES//
    [Serializable]
    public abstract class RaceFactory
    {
        public abstract Race GetRace();
    }

    [Serializable]
    public class DwarfFactory : RaceFactory
    {
        public  DwarfFactory()
        {
            
        }
        public override Race GetRace()
        {
            //The dwarf is automatically assigned the constitution bonus. Here we specify that a dwarf gets +2 Constitution.
            return new Dwarf(2);
        }

    }
    [Serializable]
    public class ElfFactory : RaceFactory
    {

        public ElfFactory()
        { }

        public override Race GetRace()
        {
            return new Elf(2);
        }
    }
    [Serializable]
    public class DragonBornFactory : RaceFactory
    {



        public DragonBornFactory()
        {
        }

        public override Race GetRace()
        {
            //2 strength, 1 charisma
            return new Dragonborn(2, 1);
        }

    }
    [Serializable]
    public class GnomeFactory : RaceFactory 
    {
        public GnomeFactory()
        { }

        public override Race GetRace()
        {
            return new Gnome(2);
        }
    }
    [Serializable]
    public class HalfElfFactory : RaceFactory
    {
        RacialBonus _choice1;
        RacialBonus _choice2;

        public HalfElfFactory(RacialBonus choice1, RacialBonus choice2)
        {
            _choice1 = choice1;
            _choice2 = choice2;
        }

        public override Race GetRace()
        {
            return new HalfElf(_choice1, _choice2);
        }
    }
    [Serializable]
    public class HalflingFactory : RaceFactory
    {
        public HalflingFactory()
        { }

        public override Race GetRace()
        {
            return new Halfling(2);
        }
    }
    [Serializable]
    public class HalfOrcFactory : RaceFactory
    {
        public HalfOrcFactory()
        { }

        public override Race GetRace()
        {
            return new HalfOrc(2, 1);
        }


    }
    [Serializable]
    public class TieflingFactory : RaceFactory
    {
        public TieflingFactory()
        { }

        public override Race GetRace()
        {
            return new Tiefling(2, 1);
        }
    }
    [Serializable]
    public class HumanFactory : RaceFactory
    {
        public HumanFactory()
        { }


        public override Race GetRace()
        {
            return new Human(1);
        }
    }



}
