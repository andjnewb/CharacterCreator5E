using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject5ECharCreator
{
    
    public interface IClass
    {
        //Interface for the actual concrete classes.

        int hitPoints { get; set; }

        int strengthModifier { get; set; }
        int constitutionModifier { get; set; }
        int charismaModifier { get; set; }
        int DexterityModifier { get; set; }
        int intelligenceModifier { get; set; }
        int wisdomModifier { get; set; }
        string classDescription { get; }
        Tuple<int, int> hitDie { get; set; }
    }

    [Serializable]
    public class Barbarian : IClass
    {
        //Concrete class for the DND barbarian
        public int hitPoints { get; set; }
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }
        public Tuple<int, int> hitDie { get; set; }//Item1 represents the minimum health recovery, and 12 the max.

        string IClass.classDescription => "A fierce warrior with the capability of entering rage.";

        public Barbarian()
        {
            //strengthModifier += 2;

            hitDie = new Tuple<int, int>(1,12);
        }
    }

    [Serializable]
    public class Bard : IClass
    {
        //Concrete class for the DND barbarian
        public int hitPoints { get; set; }
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }
        public Tuple<int, int> hitDie { get; set; }

        string IClass.classDescription => "A magician whose power lies in music.";

        public Bard()
        {
            //strengthModifier += 2;
            hitDie = new Tuple<int, int>(1, 8);
        }
    }

    [Serializable]
    public class Cleric : IClass
    {
        public int hitPoints { get; set; }
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }
        public Tuple<int, int> hitDie { get; set; }

        string IClass.classDescription => "A magical champion of god whose power lies in divine magic.";

        public Cleric()
        {
            hitDie = new Tuple<int, int>(1, 8);
        }
    }

    [Serializable]
    public class Druid : IClass
    {
        public int hitPoints { get; set; }
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }
        public Tuple<int, int> hitDie { get; set; }

        string IClass.classDescription => "A priest of ancient faith, whose power lies in a strong bond with nature.";

        public Druid()
        {
            hitDie = new Tuple<int, int>(1, 8);
        }

    }

    [Serializable]
    public class Fighter : IClass
    {
        public int hitPoints { get; set; }
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }
        public Tuple<int, int> hitDie { get; set; }

        string IClass.classDescription => "An expert in martial combat, skilled with any types of weapons and armor.";

        public Fighter()
        {
            hitDie = new Tuple<int, int>(1, 10);
        }
    }

    [Serializable]
    public class Monk : IClass
    {
        public int hitPoints { get; set; }
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }
        public Tuple<int, int> hitDie { get; set; }

        string IClass.classDescription => "An expert in martial arts, drawing their strength from the body and spirit.";

        public Monk()
        {
            hitDie = new Tuple<int, int>(1, 8);
        }
    }

    [Serializable]
    public class Paladin : IClass
    {
        public int hitPoints { get; set; }
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }
        public Tuple<int, int> hitDie { get; set; }

        string IClass.classDescription => "A holy warrior with a focus on raw power and charisma.";

        public Paladin()
        {
            hitDie = new Tuple<int, int>(1, 10);
        }
    }

    [Serializable]
    public class Ranger : IClass
    {
        public int hitPoints { get; set; }
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        public Tuple<int, int> hitDie { get; set; }

        string IClass.classDescription => "A lone warrior who strikes from afar before closing in, prefers skill over brute force.";

        public Ranger()
        {
            hitDie = new Tuple<int, int>(1, 10);
        }
    }

    [Serializable]
    public class Rogue : IClass
    {
        public int hitPoints { get; set; }
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        public Tuple<int, int> hitDie { get; set; }

        string IClass.classDescription => "A scoundrel from the streets who is an expert in trickery and fast combat.";

        public Rogue()
        {
            hitDie = new Tuple<int, int>(1, 8);
        }
    }

    [Serializable]
    public class Sorcerer : IClass
    {
        public int hitPoints { get; set; }
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        public Tuple<int, int> hitDie { get; set; }

        string IClass.classDescription => "A spellcaster whose magical abilities are innate, whether bestowed upon them or inherited.";

        public Sorcerer()
        {
            hitDie = new Tuple<int, int>(1, 6);
        }
    }

    [Serializable]
    public class Warlock : IClass
    {
        public int hitPoints { get; set; }
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        public Tuple<int, int> hitDie { get; set; }

        string IClass.classDescription => "A magic wielder who gained their powers from an entity that lives on a different plane of existence.";

        public Warlock()
        {
            hitDie = new Tuple<int, int>(1, 8);
        }
    }

    [Serializable]
    public class Wizard : IClass
    {
        public int hitPoints { get; set; }
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        public Tuple<int, int> hitDie { get; set; }

        string IClass.classDescription => "A studious magic wielder with the capability to change reality.";

        public Wizard()
        {
            hitDie = new Tuple<int, int>(1, 6);
        }
    }

}
