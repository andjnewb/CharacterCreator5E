using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace GroupProject5ECharCreator
{

    public class CharacterClass
    {
        //Contains all of the information about the character being created. The class at the end has nothing to do with DND classes, and that probably wasn't the best name to pick.

        public int HitPoints;
        public int Strength;
        public int Dexterity;
        public int Constitution;
        public int Intelligence;
        public int Wisdom;
        public int Charisma;
        public IClass ClassData;//Contains all of the information related to this character's DND class
        private static RNGCryptoServiceProvider rngGen = new RNGCryptoServiceProvider();

        public CharacterClass()
        {
            ClassData = new Barbarian();
        }

        public void changeClass(string ChangeTo)
        {
            if (ChangeTo == "Barbarian")
            {
                ClassData = new Barbarian();
            }

            if (ChangeTo == "Bard")
            {
                ClassData = new Bard();
            }

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

       

        public  Int32 Next(Int32 minValue, Int32 maxValue)
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
