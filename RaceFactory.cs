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
    public abstract class Race
    {
        public List<(RacialBonus, int)> bonuses;//Contains all of the bonuses for that race. It is a list, since some races have multiple or let you select which bonuses you want. 

        public string RaceName;
        public string RaceDescription;
    }

    //RACES//
    [Serializable]
    public class Dwarf : Race
    {
        //This class inherits from the abstract class Race
        int _ConstBonusAmt;
        public Dwarf(int ConstBonusAmount)
        {
            _ConstBonusAmt = ConstBonusAmount;

            bonuses =  new List<(RacialBonus, int)> { (RacialBonus.ConstBonus, _ConstBonusAmt)};//This is our list of tuples. Dwarves, for examples. get a constitution bonus of +2. For some reason, I can't get .Add() to work for this list so we're going with initializing it here for now.
            RaceName = "Dwarf"; //Might not be necessary, but could be useful for later.
            RaceDescription = "Dwarves are hardy masters of both stone and metal. They make excellent fighters.";

        }

    }

    [Serializable]
    public class Elf : Race
    {
        //This class inherits from the abstract class Race
        int _DexterityBonusAmt;
        public Elf(int DexterityBonusAmount)
        {
            
            _DexterityBonusAmt = DexterityBonusAmount;
            bonuses = new List<(RacialBonus, int)> { (RacialBonus.DexBonus, _DexterityBonusAmt) };
            RaceName = "Elf";
            RaceDescription = "Graceful, magical, and one with nature, Elves are excellent fighters with innate abilities that make them in-tune with the natural world.";
        }
    }

    [Serializable]
    public class Dragonborn : Race 
    {
        //Dragonborn get two racial bonuses. This is a work around.

        int _StrBonusAmt;
        int _CharismaBonusAmt;
        public Dragonborn(int StrBonusAmount, int CharismaBonusAmount)
        {
            _StrBonusAmt = StrBonusAmount;
            _CharismaBonusAmt = CharismaBonusAmount;


            bonuses = new List<(RacialBonus, int)> { (RacialBonus.StrBonus, _StrBonusAmt) , (RacialBonus.CharismaBonus, _CharismaBonusAmt) };
            RaceName = "Dragonborn";
            RaceDescription = "Dragonborn are known for their striking appearance, with a Humanoid body covered in scales. They are strong and charismatic.";
        }

   

    }

    [Serializable]
    public class Gnome : Race
    {
        //This class inherits from the abstract class Race
        int _IntBonusAmt;
        public Gnome(int IntBonusAmount)
        {
       
            _IntBonusAmt = IntBonusAmount;

            bonuses = new List<(RacialBonus, int)> { (RacialBonus.IntBonus, _IntBonusAmt) };
            RaceName = "Gnome";
            RaceDescription = "Don't let the Gnome's dimunitive stature fool you. They are bright with ample energy and intelligence to match it.";
        }
    }

    [Serializable]
    public class HalfElf : Race 
    {
        //The situation is different for a half-elf, since they get to pick 2 bonuses to add +1 to, in addition to their inherent +2 to charisma. Half-elf OP


        public HalfElf(RacialBonus choice1, RacialBonus choice2)
        {
            bonuses = new List<(RacialBonus, int)> { (RacialBonus.CharismaBonus, 2) ,(choice1, 1), (choice2,1)};
            RaceName = "Half-Elf";
            RaceDescription = "Half-elves are the perfect mixture of Human and Elf. They are not confined by a zealous reverance of nature, nor a lust for technological advancement.";
        }


    }

    public class Halfling : Race 
    {
        public Halfling(int DexBonusAmount)
        {
            //Halfings always get +2 to Dex but we have it as a parameter just in case you wanted to modify these easily from the factory
            bonuses = new List<(RacialBonus, int)> {(RacialBonus.DexBonus, DexBonusAmount) };
            RaceName = "Halfling";
            RaceDescription = "Haflings survive in a world of giants by the nimbleness of their fingers, and almost all of their race are brave even in the face of certain demise.";
        }


    }

    public class HalfOrc : Race
    {
        public HalfOrc(int StrengthBonusAmount, int ConstitutionBonusAmount)
        {
            bonuses = new List<(RacialBonus, int)> { (RacialBonus.StrBonus, StrengthBonusAmount), (RacialBonus.ConstBonus, ConstitutionBonusAmount) };
            RaceName = "Half-Orc";
            RaceDescription = "This crossbreed of Human and Orc makes for a fearsome warrior, capable of destroying almost any other in single hand-to-hand combat.";
        }
    }

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
        }
    }

    public class Tiefling : Race
    {
        public Tiefling(int CharismaBonusAmount, int IntelligenceBonusAmount)
        {
            bonuses = new List<(RacialBonus, int)> { (RacialBonus.CharismaBonus, CharismaBonusAmount), (RacialBonus.IntBonus, IntelligenceBonusAmount) };
            RaceName = "Tiefling";
            RaceDescription = "Distrusted by many, the tiefling almost always possesses much charisma and intelligence.";
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

    public class ElfFactory : RaceFactory
    {

        public ElfFactory()
        { }

        public override Race GetRace()
        {
            return new Elf(2);
        }
    }

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

    public class GnomeFactory : RaceFactory 
    {
        public GnomeFactory()
        { }

        public override Race GetRace()
        {
            return new Gnome(2);
        }
    }

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

    public class HalflingFactory : RaceFactory
    {
        public HalflingFactory()
        { }

        public override Race GetRace()
        {
            return new Halfling(2);
        }
    }

    public class HalfOrcFactory : RaceFactory
    {
        public HalfOrcFactory()
        { }

        public override Race GetRace()
        {
            return new HalfOrc(2, 1);
        }


    }

    public class TieflingFactory : RaceFactory
    {
        public TieflingFactory()
        { }

        public override Race GetRace()
        {
            return new Tiefling(2, 1);
        }
    }

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
