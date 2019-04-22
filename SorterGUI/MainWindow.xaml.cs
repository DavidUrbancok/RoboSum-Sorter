using Microsoft.Win32;
using RoboSum.ObjectModels;
using RoboSum.Parser;
using System;
using System.Threading;
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
        private readonly Random random = new Random();
        private int _As;
        private int _Bs;

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

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            int row = 0;

            foreach (var team in _storage.Teams)
            {
                AssignGroupToTeam(row);

                Thread.Sleep(25);

                row++;
            }

            SortButton.Visibility = Visibility.Hidden;
        }

        private void AssignGroupToTeam(int row)
        {
            const int column = 4;

            var textBlock = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 20
            };

            if (random.Next(0, 1000) % 2 == 0)
            {
                if (_As > 0)
                {
                    _As--;
                    textBlock.Text = "A";
                }
                else
                {
                    _Bs--;
                    textBlock.Text = "B";
                }

            }
            else
            {
                if (_Bs > 0)
                {
                    _Bs--;
                    textBlock.Text = "B";
                }
                else
                {
                    _As--;
                    textBlock.Text = "A";
                }
            }

            textBlock.SetValue(Grid.ColumnProperty, column);
            textBlock.SetValue(Grid.RowProperty, row);

            TeamsGrid.Children.Add(textBlock);
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
            SortButton.Visibility = Visibility.Visible;
        }

        private void AddTeamToGrid(Team team, int row)
        {
            TeamsGrid.RowDefinitions.Add(new RowDefinition());

            for (int i = 0; i < TeamsGrid.ColumnDefinitions.Count - 1; i++)
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

            _As = _storage.Teams.Count / 2;
            _Bs = _storage.Teams.Count - _As;
        }
    }
}
