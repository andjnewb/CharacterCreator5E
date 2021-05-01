using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;


namespace GroupProject5ECharCreator
{
    /// <summary>
    /// Interaction logic for ViewCharacter.xaml
    /// </summary>
    public partial class ViewCharacter : Window
    {
        System.Windows.Forms.PictureBox CharacterPicture = new System.Windows.Forms.PictureBox();
        public ViewCharacter()
        {
            InitializeComponent();
            Character_Image_Host.Child = CharacterPicture;

            CharacterPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            Background_Description_Textblock.Text = charDataContainer.background.Item2;


            CharacterPicture.Image = charDataContainer.characterAvatar;

            SetAbilities();
            SetTraits();
        }

        void SetAbilities()
        {
            //Lambda goodness. I chose it because it was easier to copy one to make another
            //Acrobatics_Text_Block1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Acrobatics").Item2.ToString();
            //AnimalHandling_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Animal Handling").Item2.ToString();
            //Arcana_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Arcana").Item2.ToString();
            //Athletics_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Athletics").Item2.ToString();
            //Deception_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Deception").Item2.ToString();
            //History_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "History").Item2.ToString();
            //Insight_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Insight").Item2.ToString();
            //Intimidation_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Intimidation").Item2.ToString();
            //Investigation_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Investigation").Item2.ToString();
            //Medicine_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Medicine").Item2.ToString();
            //Nature_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Nature").Item2.ToString();
            //Perception_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Perception").Item2.ToString();
            //Performance_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Performance").Item2.ToString();
            //Persuasion_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Persuasion").Item2.ToString();
            //Religion_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Religion").Item2.ToString();
            //Sleight_Of_Hand_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Sleight of Hand").Item2.ToString();
            //Stealth_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Stealth").Item2.ToString();
            //Survival_Textblock1.Text = charDataContainer.characterSkills.skills.Find(x => x.Item1 == "Survival").Item2.ToString();

            foreach (var item in charDataContainer.characterSkills.skills)
            {


                //Doing some awesome stuff with predicates and such. Honestly, after hours of debugging I still have no idea how this works. Let's just say that the ghost of Dennis Ritchie possessed me for a moment. 
                switch (item.Item1)
                {
                    
                    case "Acrobatics":
                        int value = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.DexBonus).Item2 + item.Item2;
                        Acrobatics_Text_Block1.Text = value.ToString();
                        break;
                    case "Animal Handling":
                        int value13 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.WisdomBonus).Item2 + item.Item2;
                        AnimalHandling_Textblock1.Text = value13.ToString();
                        break;
                    case "Arcana":
                        int value2 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.IntBonus).Item2 + item.Item2;
                        Arcana_Textblock1.Text = value2.ToString();
                        break;
                    case "Athletics":
                        int value1 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.StrBonus).Item2 + item.Item2;
                        Athletics_Textblock1.Text = value1.ToString();
                        break;
                    case "Deception":
                        int value13222 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.CharismaBonus).Item2 + item.Item2;
                        Deception_Textblock1.Text = value13222.ToString();
                        break;
                    case "History":
                        int value24 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.IntBonus).Item2 + item.Item2;
                        History_Textblock1.Text = value24.ToString();
                        break;
                    case "Insight":
                        int value137 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.WisdomBonus).Item2 + item.Item2;
                        Insight_Textblock1.Text = value137.ToString();
                        break;
                    case "Intimidation":
                        int value1322 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.CharismaBonus).Item2 + item.Item2;
                        Intimidation_Textblock1.Text = value1322.ToString();
                        break;
                    case "Investigation":
                        int value222 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.IntBonus).Item2 + item.Item2;
                        Investigation_Textblock1.Text = value222.ToString();
                        break;
                    case "Medicine":
                        int value1333 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.WisdomBonus).Item2 + item.Item2;
                        Medicine_Textblock1.Text = value1333.ToString();
                        break;
                    case "Nature":
                        int value234 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.IntBonus).Item2 + item.Item2;
                        Nature_Textblock1.Text = value234.ToString();
                        break;
                    case "Perception":
                        int value13225 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.WisdomBonus).Item2 + item.Item2;
                        Perception_Textblock1.Text = value13225.ToString();
                        break;
                    case "Performance":
                        int value14 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.CharismaBonus).Item2 + item.Item2;
                        Performance_Textblock1.Text = value14.ToString();
                        break;
                    case "Persuasion":
                        int value122 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.CharismaBonus).Item2 + item.Item2;
                        Persuasion_Textblock1.Text = value122.ToString();
                        break;
                    case "Religion":
                        int value266 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.IntBonus).Item2 + item.Item2;
                        Religion_Textblock1.Text = value266.ToString();
                        break;
                    case "Sleight of Hand":
                        int value23 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.DexBonus).Item2 + item.Item2;
                        Sleight_Of_Hand_Textblock1.Text = value23.ToString();
                        break;
                    case "Stealth":
                        int value3 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.DexBonus).Item2 + item.Item2;
                        Stealth_Textblock1.Text = value3.ToString();
                        break;
                    case "Survival":
                        int value1111 = charDataContainer.race.bonuses.Find(x => x.Item1 == RacialBonus.WisdomBonus).Item2 + item.Item2;
                        Survival_Textblock1.Text = value1111.ToString();
                        break;


                }
            }

        }

        public void SetTraits()
        {
            Racial_Traits_Listbox.Items.Clear();
            foreach (var trait in charDataContainer.race.racialTraits)
            {
                Racial_Traits_Listbox.Items.Add(trait.Item1).ToString();
            }
        }

        private void Racial_Traits_Listbox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            foreach (var trait in charDataContainer.race.racialTraits)
            {
                if (trait.Item1 == Racial_Traits_Listbox.SelectedItem.ToString())
                {
                    Background_Description_Textblock.Text = trait.Item2;
                }
            }
        }
    }
}
