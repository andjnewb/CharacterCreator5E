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
        int strengthModifier { get; set; }
        int constitutionModifier { get; set; }
        int charismaModifier { get; set; }
        int DexterityModifier { get; set; }
        int intelligenceModifier { get; set; }
        int wisdomModifier { get; set; }
        string classDescription { get; }
    }

    [Serializable]
    public class Barbarian : IClass
    {
        //Concrete class for the DND barbarian
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        string IClass.classDescription => "A fierce warrior with the capability of entering rage.";

        public Barbarian()
        {
            //strengthModifier += 2;
        }
    }

    [Serializable]
    public class Bard : IClass
    {
        //Concrete class for the DND barbarian
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        string IClass.classDescription => "A magician whose power lies in music.";

        public Bard()
        {
            //strengthModifier += 2;
        }
    }

    [Serializable]
    public class Cleric : IClass
    {
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        string IClass.classDescription => "A magical champion of god whose power lies in divine magic.";

        public Cleric()
        { }
    }

    [Serializable]
    public class Druid : IClass
    {
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        string IClass.classDescription => "A priest of ancient faith, whose power lies in a strong bond with nature.";

        public Druid()
        {
            
        }

    }

    [Serializable]
    public class Fighter : IClass
    {
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        string IClass.classDescription => "An expert in martial combat, skilled with any types of weapons and armor.";

        public Fighter()
        {

        }
    }

    [Serializable]
    public class Monk : IClass
    {
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        string IClass.classDescription => "An expert in martial arts, drawing their strength from the body and spirit.";

        public Monk()
        {

        }
    }

    [Serializable]
    public class Paladin : IClass
    {
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        string IClass.classDescription => "A holy warrior with a focus on raw power and charisma.";

        public Paladin()
        {

        }
    }

    [Serializable]
    public class Ranger : IClass
    {
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        string IClass.classDescription => "A lone warrior who strikes from afar before closing in, prefers skill over brute force.";

        public Ranger()
        {

        }
    }

    [Serializable]
    public class Rogue : IClass
    {
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        string IClass.classDescription => "A scoundrel from the streets who is an expert in trickery and fast combat.";

        public Rogue()
        {

        }
    }

    [Serializable]
    public class Sorcerer : IClass
    {
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        string IClass.classDescription => "A spellcaster whose magical abilities are innate, whether bestowed upon them or inherited.";

        public Sorcerer()
        {

        }
    }

    [Serializable]
    public class Warlock : IClass
    {
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        string IClass.classDescription => "A magic wielder who gained their powers from an entity that lives on a different plane of existence.";

        public Warlock()
        {

        }
    }

    [Serializable]
    public class Wizard : IClass
    {
        public int strengthModifier { get; set; }
        public int constitutionModifier { get; set; }
        public int charismaModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int intelligenceModifier { get; set; }
        public int wisdomModifier { get; set; }

        string IClass.classDescription => "A studious magic wielder with the capability to change reality.";

        public Wizard()
        {

        }
    }

}
