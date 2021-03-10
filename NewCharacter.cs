using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CharacterCreator5E
{
    public partial class NewCharacter : Form
    {
        Character newCharacter = new Character();
        public NewCharacter()
        {
            InitializeComponent();
        }

        private void AvatarFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                newCharacter.setAvatar(openFileDialog1.FileName);
                


            }


        }

        //NameEntry
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            newCharacter.setName(NameEntry.Text); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
