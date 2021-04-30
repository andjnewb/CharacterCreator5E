using System.Windows;
using System.Windows.Controls;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GroupProject5ECharCreator
{
    /// <summary>
    /// Interaction logic for NewCharacterWindow.xaml
    /// </summary>
    public partial class NewCharacterWindow : Window
    {
        //Warning! This code is a disgusting mess. If you are easily nauseasted, venture no further.
        //Holds data related to the 5EDatabase.accdb file
        DataContainer container = new DataContainer();
        CharDataContainer CharContainer = new CharDataContainer();
        RaceFactory factory;
        System.Windows.Forms.PictureBox RacePicture = new System.Windows.Forms.PictureBox();


        
        public NewCharacterWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Welcome to switch statment hell. Because one must do what they can with only one brain cell. 

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
            //foreach (string str in container.backgrounds)
            //{
            //    BackgroundListBox.Items.Add(str);
            //}

            foreach (var item in container.backgrounds)
            {
                BackgroundListBox.Items.Add(item.Item1);
            }

            //HOLY FUCKING SHIT FINALLY FUCK MY FUCKING LIFE


            Race_Image_Host.Child = RacePicture;
            RacePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            
        }

       
      

       

        private void ClassListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CharContainer.characterClass.ClassName = ClassListBox.SelectedItem.ToString();
            CharContainer.characterClass.changeClass(ClassListBox.SelectedItem.ToString());
            CharContainer.SetModifiers();
            ContextInfoTextBlock.Text = CharContainer.characterClass.ClassData.classDescription;
            HitPointsBar.Maximum = CharContainer.characterClass.ClassData.hitDie.Item2;
            HitPointsBar.Value = CharContainer.characterClass.ClassData.hitPoints;
            HP_Textblock.Text = CharContainer.characterClass.ClassData.hitPoints.ToString();
            CharContainer.SetModifiers();
            CharContainer.UpdateArmorClass();
            Armor_Class_Text_Box.Text = CharContainer.characterClass.ArmorClass.ToString();

        }

        private void BackgroundListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            
            foreach (var item in container.backgrounds)
            {
                if (item.Item1 == BackgroundListBox.SelectedItem.ToString())
                {
                    ContextInfoTextBlock.Text = item.Item2;
                    CharContainer.background = Tuple.Create(item.Item1, item.Item2);
                    break;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CharContainer.CharName = NameInputBox.Text;
            NameLblBox.Text = CharContainer.CharName;//Set the big name at the top to whatever is being changed in the name input box
        }

        private void RollStatsButton_Click(object sender, RoutedEventArgs e)
        {

            if (CharContainer.race == null)
                return;

            //Rolls the stats, fill all of the text block with the appropiate data in CharContainer's character class object
            CharContainer.RollStats();
            StrengthTextBlock.Text = CharContainer.characterClass.Strength.ToString();
            DexterityTextBlock.Text = CharContainer.characterClass.Dexterity.ToString();
            ConstitutionTextBlock.Text = CharContainer.characterClass.Constitution.ToString();
            IntelligenceTextBlock.Text = CharContainer.characterClass.Intelligence.ToString();
            WisdomTextBlock.Text = CharContainer.characterClass.Wisdom.ToString();
            CharismaTextBlock.Text = CharContainer.characterClass.Charisma.ToString();
            CharContainer.SetModifiers();
            CharContainer.UpdateArmorClass();


            //Here we fill the abilities


            foreach (var item in CharContainer.characterSkills.skills)
            {
                

                //Doing some awesome stuff with predicates and such. Honestly, after hours of debugging I still have no idea how this works. Let's just say that the ghost of Dennis Ritchie possessed me for a moment. 
                switch (item.Item1)
                {
                    //Example of what would happen if geohotz was also a crack addict.These int variables have stupid names because apparently being inside of a case is still in the same scope as the other cases.
                    case "Acrobatics":
                        int value =  CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.DexBonus).Item2 + item.Item2;
                        Acrobatics_Text_Block.Text =  value.ToString();
                        break;
                    case "Animal Handling":
                        int value13 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.WisdomBonus).Item2 + item.Item2;
                        AnimalHandling_Textblock.Text = value13.ToString();
                        break;
                    case "Arcana":
                        int value2 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.IntBonus).Item2 + item.Item2;
                        Arcana_Textblock.Text = value2.ToString();
                        break;
                    case "Athletics":
                        int value1 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.StrBonus).Item2 + item.Item2;
                        Athletics_Textblock.Text = value1.ToString();
                        break;
                    case "Deception":
                        int value13222 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.CharismaBonus).Item2 + item.Item2;
                        Deception_Textblock.Text = value13222.ToString();
                        break;
                    case "History":
                        int value24 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.IntBonus).Item2 + item.Item2;
                        History_Textblock.Text = value24.ToString();
                        break;
                    case "Insight":
                        int value137 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.WisdomBonus).Item2 + item.Item2;
                        Insight_Textblock.Text = value137.ToString();
                        break;
                    case "Intimidation":
                        int value1322 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.CharismaBonus).Item2 + item.Item2;
                        Intimidation_Textblock.Text = value1322.ToString();
                        break;
                    case "Investigation":
                        int value222= CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.IntBonus).Item2 + item.Item2;
                        Investigation_Textblock.Text = value222.ToString();
                        break;
                    case "Medicine":
                        int value1333 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.WisdomBonus).Item2 + item.Item2;
                        Medicine_Textblock.Text = value1333.ToString();
                        break;
                    case "Nature":
                        int value234 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.IntBonus).Item2 + item.Item2;
                        Nature_Textblock.Text = value234.ToString();
                        break;
                    case "Perception":
                        int value13225 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.WisdomBonus).Item2 + item.Item2;
                        Perception_Textblock.Text = value13225.ToString();
                        break;
                    case "Performance":
                        int value14 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.CharismaBonus).Item2 + item.Item2;
                        Performance_Textblock.Text = value14.ToString();
                        break;
                    case "Persuasion":
                        int value122 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.CharismaBonus).Item2 + item.Item2;
                        Persuasion_Textblock.Text = value122.ToString();
                        break;
                    case "Religion":
                        int value266 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.IntBonus).Item2 + item.Item2;
                        Religion_Textblock.Text = value266.ToString();
                        break;
                    case "Sleight of Hand":
                        int value23= CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.DexBonus).Item2 + item.Item2;
                        SleightOfHand_Textblock.Text = value23.ToString();
                        break;
                    case "Stealth":
                        int value3 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.DexBonus).Item2 + item.Item2;
                        Stealth_Textblock.Text = value3.ToString();
                        break;
                    case "Survival":
                        int value1111 = CharContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.WisdomBonus).Item2 + item.Item2;
                        Survival_Textblock.Text = value1111.ToString();
                        break;


                }
            }
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
            Racial_Traits_Listbox.Items.Clear();
            



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

            //Filling up the racial traits LIstbox
            foreach (var trait in CharContainer.race.racialTraits)
            {
                Racial_Traits_Listbox.Items.Add(trait.Item1);
            }

            foreach (var image in container.raceImages)
            {
                if (CharContainer.RaceName == image.Item1)
                {
                    
                    RacePicture.Image = image.Item2;
                    
                }
            }

            CharContainer.SetModifiers();
            CharContainer.UpdateArmorClass();
            Armor_Class_Text_Box.Text = CharContainer.characterClass.ArmorClass.ToString();

        }

        void ModifyBonusBoxes()
        {

            //Here, we modify the bonuses to the right of the stats by checking Race's bonuses value. 
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

        private void Racial_Traits_Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var trait in CharContainer.race.racialTraits)
            {
                if (Racial_Traits_Listbox.SelectedItem != null && Racial_Traits_Listbox.SelectedItem.ToString() == trait.Item1)
                {
                    ContextInfoTextBlock.Text = trait.Item2;
                }

            }
        }

        
    }

    


}
