using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        Snake snake = new Snake();
        
        const int tile_height = 20;
        const int tile_width = 20;

        Food food = new Food();

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 1000 / 10;
            timer.Tick += new EventHandler(update);
            timer.Start();
            food.PickSpot();
        }

        private void update(object sender, EventArgs e)
        {
            pbCanvas.Invalidate();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

                snake.Move();
                canvas.FillRectangle(Brushes.Green, new Rectangle(snake.X, snake.Y, tile_width, tile_height));

                canvas.FillRectangle(Brushes.Red, new Rectangle(food.X, food.Y, tile_width, tile_height));

                if (snake.Tail != null)
                {
                    foreach (Point p in snake.Tail)
                    {
                        canvas.FillRectangle(Brushes.Green, new Rectangle(p.X, p.Y, tile_width, tile_height));
                    }
                }

                // eat food if over it
                if (snake.Eat(food))
                {
                    food.PickSpot();
                }
            
                if(snake.GameOver())
                {
                //canvas.DrawString("Game Over", Font, Brushes.White, new Point(pbCanvas.Size.Width / 2, pbCanvas.Size.Height / 2), sf);
                //snake.Tail.RemoveRange(0, snake.Tail.Count);
                //snake.Total = 0;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                    snake.Ydir = -1;
                    snake.Xdir = 0;
            }else if(e.KeyCode == Keys.Down)
            {
                snake.Ydir = 1;
                snake.Xdir = 0;
            }
            if(e.KeyCode == Keys.Left)
            {
                snake.Xdir = -1;
                snake.Ydir = 0;
            }
            else if(e.KeyCode == Keys.Right)
            {
                snake.Xdir = 1;
                snake.Ydir = 0;
            }
        }
    }
}