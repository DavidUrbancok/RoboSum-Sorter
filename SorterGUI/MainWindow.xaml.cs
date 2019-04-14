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

                int row = 0;
                foreach (var team in _storage.Teams)
                {
                    AddTeamToGrid(team, row);

                    row++;
                }
            }

            TeamsGrid.Visibility = Visibility.Visible;
            LoadButton.Visibility = Visibility.Hidden;
        }

        private void AddTeamToGrid(Team team, int row)
        {
            TeamsGrid.RowDefinitions.Add(new RowDefinition());

            for (int i = 0; i < TeamsGrid.ColumnDefinitions.Count; i++)
            {
                var textBlock = new TextBlock();

                if (i == 0)
                {
                    textBlock.Text = team.Name;
                    textBlock.FontSize = 20;
                }
                else if (i == 1)
                {
                    textBlock.Text = team.School;
                }
                else
                {
                    textBlock.Text = team.City;
                }

                textBlock.VerticalAlignment = VerticalAlignment.Center;

                textBlock.SetValue(Grid.ColumnProperty, i);
                textBlock.SetValue(Grid.RowProperty, row);

                TeamsGrid.Children.Add(textBlock);
            }
        }

        private void LoadTeams(string filename)
        {
            _storage = new Storage();

            var parser = new CSVParser(_storage);

            parser.ParseTeams(filename);
        }
    }
}
