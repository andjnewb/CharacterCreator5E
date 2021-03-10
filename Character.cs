using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CharacterCreator5E
{
    class Character
    {
        public string charName = "default";
        private Image charAvatar;

        public void setAvatar(string fileName)
        {
            charAvatar = Image.FromFile(fileName);
        }

        public void setName(string newCharName)
        {
            charName = newCharName;
            
        }


    }
}
