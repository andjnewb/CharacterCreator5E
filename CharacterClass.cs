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
        public int HitPoints;
        public int Strength;
        public int Dexterity;
        public int Constitution;
        public int Intelligence;
        public int Wisdom;
        public int Charisma;
        private static RNGCryptoServiceProvider rngGen = new RNGCryptoServiceProvider();
        
        public void Roll()
        {
            int[] results = new int[6];

            for (int i= 0; i  <  6; i++)
            {
                results[i] = (Next(1, 8) + Next(1, 8) + Next(1, 8));
            }

            

            Strength = results[0];
            Dexterity = results[1];
            Constitution = results[2];
            Intelligence = results[3];
            Wisdom = results[4];
            Charisma = results[5];
            //    RollForStrength();
            //    RollForDex();
            //    RollForInt();
            //    RollForConstitution();
            //    RollForWisdom();
            //    RollForCharisma();
            //
        }

        //public void RollForCharisma()
        //{
        //    //Random rnd = new Random(DateTime.Now.Second);
        //    RNGCryptoServiceProvider rngGen = new RNGCryptoServiceProvider();
        //    int[] rolls = new int[4];//Rolls of a 6 sided die
        //    Byte[] byt = new Byte[1000];

        //    int lowest = 0;

        //    for (int i = 0; i < 4; i++)
        //    {


        //        rngGen.GetBytes(byt, 1, 7);
        //        if (lowest < byt[i])
        //        {
        //            lowest = i;

        //        }

        //    }
        //    byt[lowest] = 0;

        //    int totalForRoll = 0;

        //    foreach (int number in rolls)
        //    {
        //        totalForRoll += number;
        //    }

        //    Charisma = totalForRoll;

        //}

        //public void RollForWisdom()
        //{

        //    //Random rnd = new Random(DateTime.Now.Second);
        //    RNGCryptoServiceProvider rngGen = new RNGCryptoServiceProvider();
        //    int[] rolls = new int[4];//Rolls of a 6 sided die
        //    Byte[] byt = new Byte[1000];

        //    int lowest = 0;

        //    for (int i = 0; i < 4; i++)
        //    {


        //        rngGen.GetBytes(byt, 1, 7);
        //        if (lowest < byt[i])
        //        {
        //            lowest = i;

        //        }

        //    }
        //    byt[lowest] = 0;

        //    int totalForRoll = 0;

        //    foreach (int number in rolls)
        //    {
        //        totalForRoll += number;
        //    }

        //    Wisdom = totalForRoll;

        //}

        //public void RollForConstitution()
        //{
        //    //Random rnd = new Random(DateTime.Now.Second);
        //    RNGCryptoServiceProvider rngGen = new RNGCryptoServiceProvider();
        //    int[] rolls = new int[4];//Rolls of a 6 sided die
        //    Byte[] byt = new Byte[1000];

        //    int lowest = 0;

        //    for (int i = 0; i < 4; i++)
        //    {


        //        rngGen.GetBytes(byt, 1, 7);
        //        if (lowest < byt[i])
        //        {
        //            lowest = i;

        //        }

        //    }
        //    byt[lowest] = 0;

        //    int totalForRoll = 0;

        //    foreach (int number in rolls)
        //    {
        //        totalForRoll += number;
        //    }

        //    Constitution = totalForRoll;

        //}

        //public void RollForStrength()
        //{
        //    //Random rnd = new Random(DateTime.Now.Second);
        //    RNGCryptoServiceProvider rngGen = new RNGCryptoServiceProvider();
        //    int[] rolls = new int[4];//Rolls of a 6 sided die
        //    Byte[] byt = new Byte[1000];

        //    int lowest = 0;

        //    for (int i = 0; i < 4; i++)
        //    {


        //        rngGen.GetBytes(byt, 1, 7);
        //        if (lowest < byt[i])
        //        {
        //            lowest = i;

        //        }

        //    }
        //    byt[lowest] = 0;

        //    int totalForRoll = 0;

        //    foreach (int number in rolls)
        //    {
        //        totalForRoll += number;
        //    }

        //    Strength = totalForRoll;

        //}

        //public void RollForDex()
        //{
        //    //Random rnd = new Random(DateTime.Now.Second);
        //    RNGCryptoServiceProvider rngGen = new RNGCryptoServiceProvider();
        //    int[] rolls = new int[4];//Rolls of a 6 sided die
        //    Byte[] byt = new Byte[1000];

        //    int lowest = 0;

        //    for (int i = 0; i < 4; i++)
        //    {


        //        rngGen.GetBytes(byt, 1, 7);
        //        if (lowest < byt[i])
        //        {
        //            lowest = i;

        //        }

        //    }
        //    byt[lowest] = 0;

        //    int totalForRoll = 0;

        //    foreach (int number in rolls)
        //    {
        //        totalForRoll += number;
        //    }

        //    Dexterity = totalForRoll;
        //}

        //public void RollForInt()
        //{
        //    //Random rnd = new Random(DateTime.Now.Second);
        //    RNGCryptoServiceProvider rngGen = new RNGCryptoServiceProvider();
        //    int[] rolls = new int[6];//Rolls of a 6 sided die
        //    Byte[] byt = new Byte[4];
        //    rngGen.GetBytes(byt, 0, 4);
        //    int lowest = 0;



        //    //Intelligence = totalForRoll;
        //}

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
