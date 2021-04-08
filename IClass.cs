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


}
