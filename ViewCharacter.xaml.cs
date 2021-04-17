using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace GroupProject5ECharCreator
{
    /// <summary>
    /// Interaction logic for ViewCharacter.xaml
    /// </summary>
    public partial class ViewCharacter : Window
    {
        public ViewCharacter()
        {
            InitializeComponent();
        }
        CharDataContainer charDataContainer = new CharDataContainer();

        private void LoadCharacterButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "sav files(*.sav)| *.sav | All files(*.*) | *.* ";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            //dialog.ShowDialog();


            if ((bool)dialog.ShowDialog())
            {
                //Get the path of specified file
                string filePath = dialog.FileName;
                IFormatter formatter = new BinaryFormatter();

                //Read the contents of the file into a stream
                //var fileStream = dialog.OpenFile();
                Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                charDataContainer = (CharDataContainer)formatter.Deserialize(stream);
                stream.Close();
            }

            //Now that we have the object, we can begin filling the information in the window
            NameLabel.Content = charDataContainer.CharName;
            Strength_Display_Box.Text = charDataContainer.characterClass.Strength.ToString();
            Dexterity_Display_Box.Text = charDataContainer.characterClass.Dexterity.ToString();
            Constitution_Display_Box.Text = charDataContainer.characterClass.Constitution.ToString();
            Intelligence_Display_Box.Text = charDataContainer.characterClass.Intelligence.ToString();
            Wisdom_Display_Box.Text = charDataContainer.characterClass.Wisdom.ToString();
            Charisma_Display_Box.Text = charDataContainer.characterClass.Charisma.ToString();
            Class_Display_Box.Text = charDataContainer.characterClass.ClassName;
            Race_Display_Box.Text = charDataContainer.RaceName;


        }
    }
}
