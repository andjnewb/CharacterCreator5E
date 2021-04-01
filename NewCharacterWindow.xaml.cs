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

namespace GroupProject5ECharCreator
{
    /// <summary>
    /// Interaction logic for NewCharacterWindow.xaml
    /// </summary>
    public partial class NewCharacterWindow : Window
    {
        public NewCharacterWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //All of the horrid mass below is related to loading the databases in. VS did this for me automatically so its black magic as far as Im concerned.

            GroupProject5ECharCreator._5EDatabaseDataSet _5EDatabaseDataSet = ((GroupProject5ECharCreator._5EDatabaseDataSet)(this.FindResource("_5EDatabaseDataSet")));
            // Load data into the table Classes. You can modify this code as needed.
            GroupProject5ECharCreator._5EDatabaseDataSetTableAdapters.ClassesTableAdapter _5EDatabaseDataSetClassesTableAdapter = new GroupProject5ECharCreator._5EDatabaseDataSetTableAdapters.ClassesTableAdapter();
            _5EDatabaseDataSetClassesTableAdapter.Fill(_5EDatabaseDataSet.Classes);
            System.Windows.Data.CollectionViewSource classesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("classesViewSource")));
            classesViewSource.View.MoveCurrentToFirst();
            // Load data into the table Races. You can modify this code as needed.
            GroupProject5ECharCreator._5EDatabaseDataSetTableAdapters.RacesTableAdapter _5EDatabaseDataSetRacesTableAdapter = new GroupProject5ECharCreator._5EDatabaseDataSetTableAdapters.RacesTableAdapter();
            _5EDatabaseDataSetRacesTableAdapter.Fill(_5EDatabaseDataSet.Races);
            System.Windows.Data.CollectionViewSource racesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("racesViewSource")));
            racesViewSource.View.MoveCurrentToFirst();
            GroupProject5ECharCreator._5EDatabaseDataSet1 _5EDatabaseDataSet1 = ((GroupProject5ECharCreator._5EDatabaseDataSet1)(this.FindResource("_5EDatabaseDataSet1")));
            // Load data into the table Classes. You can modify this code as needed.
            GroupProject5ECharCreator._5EDatabaseDataSet1TableAdapters.ClassesTableAdapter _5EDatabaseDataSet1ClassesTableAdapter = new GroupProject5ECharCreator._5EDatabaseDataSet1TableAdapters.ClassesTableAdapter();
            _5EDatabaseDataSet1ClassesTableAdapter.Fill(_5EDatabaseDataSet1.Classes);
            System.Windows.Data.CollectionViewSource classesViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("classesViewSource1")));
            classesViewSource1.View.MoveCurrentToFirst();
            // Load data into the table Races. You can modify this code as needed.
            GroupProject5ECharCreator._5EDatabaseDataSet1TableAdapters.RacesTableAdapter _5EDatabaseDataSet1RacesTableAdapter = new GroupProject5ECharCreator._5EDatabaseDataSet1TableAdapters.RacesTableAdapter();
            _5EDatabaseDataSet1RacesTableAdapter.Fill(_5EDatabaseDataSet1.Races);
            System.Windows.Data.CollectionViewSource racesViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("racesViewSource1")));
            racesViewSource1.View.MoveCurrentToFirst();
        }

  
        private void classComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
