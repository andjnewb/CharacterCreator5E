﻿using System.Windows;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewCharacterWindow newCharacterWindow = new NewCharacterWindow();
            newCharacterWindow.Show();

        }
    }
}
