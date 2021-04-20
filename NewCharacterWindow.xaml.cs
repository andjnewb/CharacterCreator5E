using System.Windows;
using System.Windows.Controls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

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
        RaceFactory factory;
        public NewCharacterWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Hide the racial bonus selection stuff, as only certain Races can select their bonuses.
            Bonus_1_Combo_Box.Visibility = Visibility.Hidden;
            Bonus_2_Combo_Box.Visibility = Visibility.Hidden;
            Racial_Bonus_Selection_Label.Visibility = Visibility.Hidden;

            //This sucks but its filling the Bonus boxes up with all of the stats
            Bonus_1_Combo_Box.Items.Add("Strength");
            Bonus_2_Combo_Box.Items.Add("Strength");
            Bonus_1_Combo_Box.Items.Add("Dexterity");
            Bonus_2_Combo_Box.Items.Add("Dexterity");
            Bonus_1_Combo_Box.Items.Add("Intelligence");
            Bonus_2_Combo_Box.Items.Add("Intelligence");
            Bonus_1_Combo_Box.Items.Add("Wisdom");
            Bonus_2_Combo_Box.Items.Add("Wisdom");
            Bonus_1_Combo_Box.Items.Add("Constitution");
            Bonus_2_Combo_Box.Items.Add("Constitution");

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
            CharContainer.Background = BackgroundListBox.SelectedItem.ToString();
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
            //Serialize the current CharDataContainer, and store it in a .sav file
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

            

            //Cleaning up the bonus boxes if the race is changed.
            foreach (Label label in BonusGrid1.Children)
            {
                label.Content = null;
            }


            //This switch catches whatever race the user has selected, and assigns factory with correct type of factory. It then uses that factory to assign CharContainer a race.
            switch (RaceListBox.SelectedItem.ToString())
            {
                case "Dwarf":
                    Bonus_1_Combo_Box.Visibility = Visibility.Hidden;
                    Bonus_2_Combo_Box.Visibility = Visibility.Hidden;

                    CharContainer.RaceName = "Dwarf";
                    //Using the factory method to set the race for our dwarf. Same will apply below
                    factory = new DwarfFactory();
                    CharContainer.race = factory.GetRace();
                    ModifyBonusBoxes();
                    break;
                case "Elf":
                    Bonus_1_Combo_Box.Visibility = Visibility.Hidden;
                    Bonus_2_Combo_Box.Visibility = Visibility.Hidden;
                    CharContainer.RaceName = "Elf";
                    factory = new ElfFactory();
                    CharContainer.race = factory.GetRace();
                    ModifyBonusBoxes();
                    break;
                case "Half Elf":
                    Bonus_1_Combo_Box.Visibility = Visibility.Visible;
                    Bonus_2_Combo_Box.Visibility = Visibility.Visible;
                    CharContainer.RaceName = "Half Elf";

                    factory = ConvertChoicesToRacialBonus();

                    CharContainer.race = factory.GetRace();
                    ModifyBonusBoxes();
                    //return new HalfElfFactory();

                    break;
                case "Dragonborn":
                    Bonus_1_Combo_Box.Visibility = Visibility.Hidden;
                    Bonus_2_Combo_Box.Visibility = Visibility.Hidden;
                    CharContainer.RaceName = "Dragonborn";
                    factory = new DragonBornFactory();
                    CharContainer.race = factory.GetRace();
                    ModifyBonusBoxes();
                    break;
                case "Gnome":
                    Bonus_1_Combo_Box.Visibility = Visibility.Hidden;
                    Bonus_2_Combo_Box.Visibility = Visibility.Hidden;
                    CharContainer.RaceName = "Gnome";
                    factory = new GnomeFactory();
                    CharContainer.race = factory.GetRace();
                    ModifyBonusBoxes();
                    break;
                case "Half Orc":
                    Bonus_1_Combo_Box.Visibility = Visibility.Hidden;
                    Bonus_2_Combo_Box.Visibility = Visibility.Hidden;
                    CharContainer.RaceName = "Half Orc";
                    factory = new HalfOrcFactory();
                    CharContainer.race = factory.GetRace();
                    ModifyBonusBoxes();
                    break;
                case "Human":
                    Bonus_1_Combo_Box.Visibility = Visibility.Hidden;
                    Bonus_2_Combo_Box.Visibility = Visibility.Hidden;
                    CharContainer.RaceName = "Human";
                    factory = new HumanFactory();
                    CharContainer.race = factory.GetRace();
                    ModifyBonusBoxes();
                    break;
                case "Tiefling":
                    Bonus_1_Combo_Box.Visibility = Visibility.Hidden;
                    Bonus_2_Combo_Box.Visibility = Visibility.Hidden;
                    CharContainer.RaceName = "Tielfing";
                    factory = new TieflingFactory();
                    CharContainer.race = factory.GetRace();
                    ModifyBonusBoxes();
                    break;
                case "Halfling":
                    Bonus_1_Combo_Box.Visibility = Visibility.Hidden;
                    Bonus_2_Combo_Box.Visibility = Visibility.Hidden;
                    CharContainer.RaceName = "Halfling";
                    factory = new HalflingFactory();
                    CharContainer.race = factory.GetRace();
                    ModifyBonusBoxes();
                    break;
                default:
                    break;
            }

            if (CharContainer.race != null)
                ContextInfoTextBlock.Text = CharContainer.race.RaceDescription;


        }

        void ModifyBonusBoxes()
        {

            //Here,
            foreach (var bonus in CharContainer.race.bonuses)
            {
                switch (bonus.Item1)
                {
                    case RacialBonus.ConstBonus:
                        Constitution_Bonus_Box.Content = "+" + bonus.Item2.ToString();
                        break;
                    case RacialBonus.StrBonus:
                        Strength_Bonus_Box.Content = "+" + bonus.Item2.ToString();
                        break;
                    case RacialBonus.CharismaBonus:
                        Charisma_Bonus_Box.Content = "+" + bonus.Item2.ToString();
                        break;
                    case RacialBonus.DexBonus:
                        Dexterity_Bonus_Box.Content = "+" + bonus.Item2.ToString();
                        break;
                    case RacialBonus.IntBonus:
                        Intelligence_Bonus_Box.Content = "+" + bonus.Item2.ToString();
                        break;
                    case RacialBonus.WisdomBonus:
                        Wisdom_Bonus_Box.Content = "+" + bonus.Item2.ToString();
                            break;
                    default:break;
                }


            }
        }

        RaceFactory ConvertChoicesToRacialBonus()
        {
            RacialBonus bonus1 = RacialBonus.StrBonus;
            RacialBonus bonus2 = RacialBonus.CharismaBonus;

            switch (Bonus_1_Combo_Box.SelectedItem.ToString())
            {
                case "Strength":
                    bonus1 = RacialBonus.StrBonus;
                    break;
                case "Intelligence":
                    bonus1 = RacialBonus.IntBonus;
                    break;
                case "Wisdom":
                    bonus1 = RacialBonus.WisdomBonus;
                    break;
                case "Constitution":
                    bonus1 = RacialBonus.ConstBonus;
                    break;
                case "Dexterity":
                    bonus1 = RacialBonus.DexBonus;
                    break;


                default:break;
            }

            switch (Bonus_2_Combo_Box.SelectedItem.ToString())
            {
                case "Strength":
                    bonus2 = RacialBonus.StrBonus;
                    break;
                case "Intelligence":
                    bonus2 = RacialBonus.IntBonus;
                    break;
                case "Wisdom":
                    bonus2 = RacialBonus.WisdomBonus;
                    break;
                case "Constitution":
                    bonus2 = RacialBonus.ConstBonus;
                    break;
                case "Dexterity":
                    bonus2 = RacialBonus.DexBonus;
                    break;


                default: break;
            }

            return new HalfElfFactory(bonus1,bonus2);

        }

        private void Bonus_1_Combo_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ContextInfoTextBlock.Text = "As a half elf, you get to select your racial bonuses! Choose from one of the 5. Note that you can't stack bonuses i.e. you can't select strength twice.";

            if (Bonus_1_Combo_Box.SelectedIndex == Bonus_2_Combo_Box.SelectedIndex)
            {
                ContextInfoTextBlock.Text = "You can't have two of the same bonuses, sorry!";
                Bonus_1_Combo_Box.SelectedIndex = 0;
                Bonus_2_Combo_Box.SelectedIndex = 1;
            }

            
            foreach (Label label in BonusGrid1.Children)
            {
                label.Content = null;
            }

            if (factory != null && CharContainer.race != null)
            {
                factory = ConvertChoicesToRacialBonus();
                CharContainer.race = factory.GetRace();
                ModifyBonusBoxes();
            }
        }

        private void Bonus_2_Combo_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ContextInfoTextBlock.Text = "As a half elf, you get to select your racial bonuses! Choose from one of the 5. Note that you can't stack bonuses i.e. you can't select strength twice.";


            if (Bonus_1_Combo_Box.SelectedIndex == Bonus_2_Combo_Box.SelectedIndex)
            {
                ContextInfoTextBlock.Text = "You can't have two of the same bonuses, sorry!";
                Bonus_1_Combo_Box.SelectedIndex = 0;
                Bonus_2_Combo_Box.SelectedIndex = 1;
            }

            foreach (Label label in BonusGrid1.Children)
            {
                label.Content = null;
            }

            if (factory != null && CharContainer.race != null)
            {
                factory = ConvertChoicesToRacialBonus();
                CharContainer.race = factory.GetRace();
                ModifyBonusBoxes();
            }
        }
    }

    


}
