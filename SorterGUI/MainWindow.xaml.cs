using Microsoft.Win32;
using RoboSum.ObjectModels;
using RoboSum.Parser;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RoboSum_Sorter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Storage _storage;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Open_Click(sender, e);
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "CSV Files (*.csv)|*.csv"
            };

            bool? result = dialog.ShowDialog();

            if (result is true)
            {
                var fileName = dialog.FileName;

                LoadTeams(fileName);

                foreach(var team in _storage.Teams)
                {
                    TeamsGrid.Children.Add();
                }
            }

            TeamsGrid.Visibility = Visibility.Visible;
            LoadButton.Visibility = Visibility.Hidden;
        }

        private void LoadTeams(string filename)
        {
            _storage = new Storage();

            var parser = new CSVParser(_storage);

            parser.ParseTeams(filename);
        }
    }
}
