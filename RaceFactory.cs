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
        



        public virtual void GetRace()
        {
        }
    }

    //RACES//
    [Serializable]
    public class Dwarf : Race
    {
        //This class inherits from the abstract class Race
        int bonusAmt;
        public Dwarf(int bonusAmount)
        {
            bonusAmt = bonusAmount;
        }

        public override RacialBonus bonus
        {
            get { return _bonus; }
            set {; }
        }

        public override void GetRace()
        {
            
        }

    }

    [Serializable]
    public class Elf : Race
    {
        //This class inherits from the abstract class Race
        private RacialBonus _bonus;
        int bonusAmt;
        public Elf(int bonusAmount)
        {
            _bonus = RacialBonus.DexBonus;
            bonusAmt = bonusAmount;
        }

        public override RacialBonus bonus
        {
            get { return _bonus; }
            set {; }
        }

        public override void GetRace()
        {

        }

    }

    [Serializable]
    public class Dragonborn : Race 
    {
        //Dragonborn get two racial bonuses. This is a work around.
        private RacialBonus _bonus1;
        private RacialBonus _bonus2;
        private int _bonusAmount1;
        private int _bonusAmount2;

        public Dragonborn(int bonusAmount1, int bonusAmount2)
        {
            _bonus1 = RacialBonus.StrBonus;
            _bonus2 = RacialBonus.CharismaBonus;
            _bonusAmount1 = bonusAmount1;
            _bonusAmount2 = bonusAmount2;

        }

        public override RacialBonus bonus
        {
            get { return _bonus1; }
            set {; }
        }

        public  RacialBonus bonus2
        {
            get { return _bonus2; }
            set {; }
        }

        public override void GetRace()
        {
           
        }

    }

    [Serializable]
    public class Gnome : Race
    {
        //This class inherits from the abstract class Race
        private RacialBonus _bonus;
        int bonusAmt;
        public Gnome(int bonusAmount)
        {
            _bonus = RacialBonus.IntBonus;
            bonusAmt = bonusAmount;
        }

        public override RacialBonus bonus
        {
            get { return _bonus; }
            set {; }
        }

        public override void GetRace()
        {

        }
    }

    [Serializable]
    public class HalfElf : Race 
    {
        //This class inherits from the abstract class Race

        //Half-elves get a base +2 to charisma, plus they get +1 to two other abilities of their choosing. This is why we have a different constructor.
        private RacialBonus _bonus;//This is the inherit bonus
        private RacialBonus _bonusChoice1;
        private RacialBonus _bonusChoice2;
        private int _bonusAmount;//Inherit bonus amount.
        private int _bonusChoiceAmount1;
        private int _bonusChoiceAmount2;
        public HalfElf(RacialBonus choice1, RacialBonus choice2, int bonusAmount, int bonusChoiceAmount1, int bonusChoiceAmount2)
        {
            _bonus = RacialBonus.ConstBonus;
            _bonusChoice1 = choice1;
            _bonusChoice2 = choice2;

            _bonusAmount = bonusAmount;

            _bonusChoiceAmount1 = bonusChoiceAmount1;
            _bonusChoiceAmount2 = bonusChoiceAmount2;

        }

        public override RacialBonus bonus
        {
            //returns inherit bonus
            get { return _bonus; }
            set {; }
        }

        public RacialBonus bonusChoice1
        {
            get { return _bonusChoice1; }
            set {; }
        }

        public RacialBonus bonusChoice2
        {
            get { return _bonusChoice2; }
            set {; }
        }

        public override void GetRace()
        {

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

        int _strengthBonus;
        int _charismaBonus;

        public DragonBornFactory(int strengthBonus, int charismaBonus)
        {
            _strengthBonus = strengthBonus;
            _charismaBonus = charismaBonus;
        }

        public override Race GetRace()
        {
            //2 strength, 1 charisma
            return new Dragonborn(_charismaBonus, _strengthBonus);
        }

    }

    //public class HalfElfFactory : RaceFactory
    //{
    //    public HalfElfFactory()
    //}



}
