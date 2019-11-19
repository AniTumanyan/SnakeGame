using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeGame
{
    class Snake
    {
        public string direction { get; set; } = "Right";

        MainWindow window;
        public Rectangle rect;
        List<Rectangle> body = new List<Rectangle>();


        public double x { get; set; }
        public double y { get; set; }

        public double fx { get; set; }
        public double fy { get; set; }
        public object MessegeBox { get; private set; }

        public Snake(MainWindow window)
        {
            for (int i = 0; i < 3; i++)
            {
                this.window = window;
                rect = new Rectangle() { Width = 20, Height = 20, Fill = Brushes.Red };
                Canvas.SetLeft(rect, 50);
                Canvas.SetTop(rect, 50);

                body.Add(rect);
            }

        }

        public void Paint()
        {
            window.Board.Children.Clear();
            foreach (var item in body)
            {
                this.window.Board.Children.Add(item);
            }
        }

        internal void Eat(Food food)
        {
            double x1 = Canvas.GetLeft(body[0]);
            double y1 = Canvas.GetTop(body[0]);

            double x2 = Canvas.GetLeft(food.rect);
            double y2 = Canvas.GetTop(food.rect);


            if (Math.Abs(x1 - x2) < food.w && Math.Abs(y1 - y2) < food.w)
            {
                this.Increase();
                food.Restart();
            }
        }
        public void Increase()
        {
            Rectangle r = new Rectangle()
            {
                Fill = Brushes.Red,
                Width = 20,
                Height = 20,
            };
            double x = Canvas.GetLeft(body[body.Count - 1]);
            double y = Canvas.GetTop(body[body.Count - 1]);
            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);
            body.Add(r);
            this.Paint();
            window.timer.Stop();
            window.v = window.v < 10 ? 10 : window.v - 5;
            window.timer.Interval = new TimeSpan(0, 0, 0, 0, window.v);
            window.timer.Start();
        }

        public void Move()
        {
            for (int i = body.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    if (direction == "Right")
                    {
                        double left = Canvas.GetLeft(body[i]);
                        left += 22;
                        Canvas.SetLeft(body[i], left);
                    }
                    else if (direction == "Left")
                    {
                        double left = Canvas.GetLeft(body[i]);
                        left -= 22;
                        Canvas.SetLeft(body[i], left);
                    }

                    else if (direction == "Top")
                    {
                        double left = Canvas.GetTop(body[i]);
                        left -= 22;
                        Canvas.SetTop(body[i], left);
                    }

                    else if (direction == "Down")
                    {

                        double left = Canvas.GetTop(body[i]);
                        left += 22;
                        Canvas.SetTop(body[i], left);
                    }
                }



                else
                {
                    double l1 = Canvas.GetLeft(body[i - 1]);
                    double t1 = Canvas.GetTop(body[i - 1]);
                    Canvas.SetLeft(body[i], l1);
                    Canvas.SetTop(body[i], t1);
                }


                x = Canvas.GetLeft(body[i]);
                y = Canvas.GetTop(body[i]);

                if (x <= 0)
                {
                    x = window.Width;
                    Canvas.SetLeft(body[i], x);
                }
                else if (x >= window.Height + 330)
                {
                    x = 0;
                    Canvas.SetLeft(body[i], x);
                }
                else if (y <= 0)
                {
                    y = window.Height;
                    Canvas.SetTop(body[i], y);
                }
                else if (y >= window.Height)
                {
                    y = 0;
                    Canvas.SetTop(body[i], y);
                }

                fx = Canvas.GetLeft(body[0]);
                fy = Canvas.GetTop(body[0]);

            }
        }

        public void GameOver()
        {
            if (body.Count >= 6)
            {
                for (int i = 1; i < body.Count; i++)
                {
                    if (fx == Canvas.GetLeft(body[i]) && fy == Canvas.GetTop(body[i]))
                    {
                        Thread.Sleep(100);
                        this.window.timer.Stop();
                        MessageBox.Show("Game over");
                    }
                }
            }

        }
    }
}
