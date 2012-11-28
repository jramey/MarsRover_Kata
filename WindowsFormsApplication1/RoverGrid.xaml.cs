using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarsRover
{
    public partial class UserControl1 : UserControl
    {
        private const Int32 RowsNumber = 20;
        private const Int32 ColsNumber = 20;
        private Grid grid;
        private Rover rover;
        private IEnumerable<Coordinate> obstacles;
        private Direction direction;

        ImageSource img = new BitmapImage();
        ImageSource North = new BitmapImage(new Uri(@"C:\Users\jramey\Pictures\north.png"));
        ImageSource West = new BitmapImage(new Uri(@"C:\Users\jramey\Pictures\west.png"));
        ImageSource South = new BitmapImage(new Uri(@"C:\Users\jramey\Pictures\south.png"));
        ImageSource East = new BitmapImage(new Uri(@"C:\Users\jramey\Pictures\east.png"));
        ImageSource Boom = new BitmapImage(new Uri(@"C:\Users\jramey\Pictures\explosion.gif"));

        public UserControl1()
        {
            obstacles = new[] { new Coordinate(4, 3), new Coordinate(4, 4), new Coordinate(3, 4), new Coordinate(3, 3),
                                new Coordinate(4, 12), new Coordinate(4, 13), new Coordinate(3, 13), new Coordinate(3, 12),
                                new Coordinate(13, 3), new Coordinate(13, 4), new Coordinate(12, 4), new Coordinate(12, 3),
                                new Coordinate(13, 12), new Coordinate(13, 13), new Coordinate(12, 13), new Coordinate(12, 12),};
            grid = new Grid(RowsNumber, ColsNumber, obstacles);
            rover = new Rover(new Coordinate(2, 2), Direction.North, this.grid);
            InitializeComponent();
            SetupGrid();
            PlaceRover();
            PlaceObstacles();
        }


        private void SetImageSource()
        {
            direction = rover.Direction;
            Boolean boom = rover.IsObstructed;

            if (direction == Direction.North)
            {
                img = North;
            }
            else if (direction == Direction.East)
            {
                img = East;
            }
            else if (direction == Direction.West)
            {
                img = West;
            }
            else
            {
                img = South;
            }

             if (boom)
            {
                img = Boom;
            }
        }

        private void PlaceObstacles()
        {
            foreach (var obstacle in obstacles)
            {
                var panel = new DockPanel();
                panel.Background = new SolidColorBrush(Colors.Black);
                System.Windows.Controls.Grid.SetRow(panel, obstacle.X);
                System.Windows.Controls.Grid.SetColumn(panel, obstacle.Y);
                displayGrid.Children.Add(panel);
            }
        }

        private void PlaceRover()
        {
            displayGrid.Children.Clear();
            PlaceObstacles();
            SetImageSource();
            var panel = new DockPanel();

            panel.Background = new ImageBrush(img);

            System.Windows.Controls.Grid.SetRow(panel, rover.Location.X);
            System.Windows.Controls.Grid.SetColumn(panel, rover.Location.Y);

            displayGrid.Children.Add(panel);
        }

        private void SetupGrid()
        {
            this.grid = new Grid(RowsNumber, ColsNumber);

            for (int i = 0; i < grid.numOfRows; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                this.displayGrid.RowDefinitions.Add(rowDefinition);
            }

            for (int i = 0; i < grid.numOfCols; i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                this.displayGrid.ColumnDefinitions.Add(columnDefinition);
            }
        }

        private void displayGrid_KeyDown(object sender, KeyEventArgs e)
        {
            var commands = String.Empty;

            if (e.Key == Key.Down)
                commands = "b";
            else if (e.Key == Key.Up)
                commands = "f";
            else if (e.Key == Key.Right)
                commands = "r";
            else if (e.Key == Key.Left)
                commands = "l";

            rover.TakeCommands(commands);
            PlaceRover();
        }
    }
}
