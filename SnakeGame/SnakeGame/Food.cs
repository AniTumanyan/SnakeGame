using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeGame
{
    class Food
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        Random rend = new Random();
        public Rectangle rect;

        MainWindow window;
        public Food(MainWindow window)
        {
            this.window = window;
            w = 20;
            x = rend.Next(0, (int)window.Width - 100);
            y = rend.Next(0, (int)window.Height - 100);
        }

        public void Nkarel()
        {
            rect = new Rectangle()
            {
                Width = w,
                Height = w,
                Fill = Brushes.Gray
            };
            Canvas.SetTop(rect, y);
            Canvas.SetLeft(rect, x);
            window.Board.Children.Add(rect);

        }

        public void Restart()
        {
            x = rend.Next(0, (int)window.Width - 100);
            y = rend.Next(0, (int)window.Height - 100);
            Canvas.SetTop(rect, y);
            Canvas.SetLeft(rect, x);
        }
    }
}

