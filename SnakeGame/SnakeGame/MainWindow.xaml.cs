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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Snake oc;
        Food food;
        public DispatcherTimer timer;
        public int v = 100;
        public MainWindow()
        {
            InitializeComponent();
            food = new Food(this);
            oc = new Snake(this);

            oc.Paint();

            food.Nkarel();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, v);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            oc.Move();
            oc.Eat(food);
            food.Nkarel();
            //oc.GameOver();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                oc.direction = "Down";
            }
            else if (e.Key == Key.Up)
            {
                oc.direction = "Top";
            }
            else if (e.Key == Key.Left)
            {
                oc.direction = "Left";
            }
            else if (e.Key == Key.Right)
            {
                oc.direction = "Right";
            }
        }
    }
}
