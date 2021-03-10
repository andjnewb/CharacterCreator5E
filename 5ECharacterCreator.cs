using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator5E
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreateNewCharacter_Click(object sender, EventArgs e)
        {
            //In Form1, we want to open the NewCharacter form when the create a character button is clicked
            var newCharWindow = new NewCharacter();
            


            newCharWindow.Show();
        }
    }
}
