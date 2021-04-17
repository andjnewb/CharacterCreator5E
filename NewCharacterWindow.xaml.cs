using System.Windows;
using System.Windows.Controls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GroupProject5ECharCreator
{
    /// <summary>
    /// Interaction logic for NewCharacterWindow.xaml
    /// </summary>
    public partial class NewCharacterWindow : Window
    {
        //Holds data related to the 5EDatabase.accdb file
        DataContainer container = new DataContainer();
        CharDataContainer CharContainer = new CharDataContainer();
        public NewCharacterWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Load up the RaceListBox with the races in DataContainer
            foreach (string str in container.races)
            {
                RaceListBox.Items.Add(str);
            }

            //Same as above but for ClassListBox
            foreach (string str in container.classes)
            {
                ClassListBox.Items.Add(str);
            }
            //Same as above.
            foreach (string str in container.backgrounds)
            {
                BackgroundListBox.Items.Add(str);
            }


            
        }


      

       

        private void ClassListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CharContainer.characterClass.ClassName = ClassListBox.SelectedItem.ToString();
            CharContainer.characterClass.changeClass(ClassListBox.SelectedItem.ToString());
            ContextInfoTextBlock.Text = CharContainer.characterClass.ClassData.classDescription;
        }

        private void BackgroundListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CharContainer.Background = ClassListBox.SelectedItem.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CharContainer.CharName = NameInputBox.Text;
            NameLblBox.Text = CharContainer.CharName;//Set the big name at the top to whatever is being changed in the name input box
        }

        private void RollStatsButton_Click(object sender, RoutedEventArgs e)
        {
            //Rolls the stats, fill all of the text block with the appropiate data in CharContainer's character class object
            CharContainer.RollStats();
            StrengthTextBlock.Text = CharContainer.characterClass.Strength.ToString();
            DexterityTextBlock.Text = CharContainer.characterClass.Dexterity.ToString();
            ConstitutionTextBlock.Text = CharContainer.characterClass.Constitution.ToString();
            IntelligenceTextBlock.Text = CharContainer.characterClass.Intelligence.ToString();
            WisdomTextBlock.Text = CharContainer.characterClass.Wisdom.ToString();
            CharismaTextBlock.Text = CharContainer.characterClass.Charisma.ToString();
        }

        private void SaveContainer()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(CharContainer.CharName + ".sav", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, CharContainer);
            stream.Close();
        }

        private void SaveProgressButton_Click(object sender, RoutedEventArgs e)
        {
            SaveContainer();
        }

        private void RaceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Constitution_Bonus_Box.Content = "";
            StrengthBonusBox.Content = "";
            Dexterity_Bonus_Box.Content = "";
            RaceFactory factory;
            

            //This switch catches whatever race the user has selected, and assigns factory with correct type of factory. It then uses that factory to assign CharContainer a race.
            switch (RaceListBox.SelectedItem.ToString())
            {
                case "Dwarf":
                    CharContainer.RaceName = "Dwarf";
                    //Using the factory method to set the race for our dwarf. Same will apply bellow
                    factory = new DwarfFactory();
                    CharContainer.race = factory.GetRace();
                    
                    
                    
                    break;
                case "Elf":
                    CharContainer.RaceName = "Elf";
                    factory = new ElfFactory();
                    CharContainer.race = factory.GetRace();
                    break;
                default:
                    break;
            }



            foreach (Label label in BonusGrid1.Children)
            {
                label.Content = null;
            }


        }
    }
}
