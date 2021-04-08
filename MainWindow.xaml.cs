using System.Windows;

namespace GroupProject5ECharCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Create_A_Character_Button_Click(object sender, RoutedEventArgs e)
        {
            Window newChar = new NewCharacterWindow();
            newChar.Show();
        }

        private void Load_A_Character_Button_Click(object sender, RoutedEventArgs e)
        {
            Window loadChar = new ViewCharacter();
            loadChar.Show();
        }
    }
}
