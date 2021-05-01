using System;
using System.Security.Cryptography;


namespace GroupProject5ECharCreator
{
    [Serializable]
    public class CharacterClass
    {
        //Contains all of the information about the character being created. The class at the end has nothing to do with DND classes, and that probably wasn't the best name to pick.

        public int HitPoints;
        public int ArmorClass;
        public int Strength;
        public int Dexterity;
        public int Constitution;
        public int Intelligence;
        public int Wisdom;
        public int Charisma;
        public IClass ClassData;//Contains all of the information related to this character's DND class
        public string ClassName;//Name of the class, may remove later
        private static RNGCryptoServiceProvider rngGen = new RNGCryptoServiceProvider();

        public CharacterClass()
        {
            ClassData = new Barbarian();
            ClassName = "Barbarian";
        }

        public void changeClass(string ChangeTo)
        {


            ClassName = ChangeTo;

            if (ChangeTo == "Barbarian")
            {
                ClassData = new Barbarian();


            }

            if (ChangeTo == "Bard")
            {
                ClassData = new Bard();

            }

            if (ChangeTo == "Cleric")
            {
                ClassData = new Cleric();

            }

            if (ChangeTo == "Druid")
            {
                ClassData = new Druid();

            }

            if (ChangeTo == "Fighter")
            {
                ClassData = new Fighter();

            }

            if (ChangeTo == "Monk")
            {
                ClassData = new Monk();

            }

            if (ChangeTo == "Paladin")
            {
                ClassData = new Paladin();
            }

            if (ChangeTo == "Ranger")
            {
                ClassData = new Ranger();
            }

            if (ChangeTo == "Rogue")
            {
                ClassData = new Rogue();
            }

            if (ChangeTo == "Sorcerer")
            {
                ClassData = new Sorcerer();
            }

            if (ChangeTo == "Warlock")
            {
                ClassData = new Warlock();
            }

            if (ChangeTo == "Wizard")
            {
                ClassData = new Wizard();
            }


            ClassData.hitPoints = Next(ClassData.hitDie.Item1, ClassData.hitDie.Item2);
        }


        public void Roll()
        {
            int[] results = new int[6];

            for (int i = 0; i < 6; i++)
            {
                results[i] = (Next(1, 8) + Next(1, 8) + Next(1, 8));
            }


            Strength = results[0];
            Dexterity = results[1];
            Constitution = results[2];
            Intelligence = results[3];
            Wisdom = results[4];
            Charisma = results[5];


        }



        public Int32 Next(Int32 minValue, Int32 maxValue)
        {
            byte[] bytes = new byte[6];
            RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();
            if (minValue > maxValue)
                throw new ArgumentOutOfRangeException("minValue");
            if (minValue == maxValue) return minValue;
            Int64 diff = maxValue - minValue;
            while (true)
            {
                _rng.GetBytes(bytes);
                UInt32 rand = BitConverter.ToUInt32(bytes, 0);

                Int64 max = (1 + (Int64)UInt32.MaxValue);
                Int64 remainder = max % diff;
                if (rand < max - remainder)
                {
                    return (Int32)(minValue + (rand % diff));
                }
            }
        }
    }

}
