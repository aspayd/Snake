using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Snake
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Xdir { get; set; }
        public int Ydir { get; set; }
        public List<Point> Tail = new List<Point>();
        public int Total { get; set; }

        private int tile_width = 20;
        private int tile_height = 20;
        private int height = 500;
        private int width = 500;

        public Snake()
        {
            X = 0;
            Y = 0;
            Xdir = 1;
            Ydir = 0;
            Total = 0;
        }

        public bool GameOver()
        {
            for(int p = 0; p < Tail.Count - 1; p++)
            {
                if (Tail[p].X == X && Tail[p].Y == Y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Eat(Food pos)
        {
            if (X == pos.X && Y == pos.Y)
            {
                Tail.Add(new Point(X - (Xdir * tile_width), Y - (Ydir * tile_height)));
                Total++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Move()
        {
            if (Tail != null)
            {
                if (Tail.Count == Total) {
                for (int i = 0; i < Tail.Count - 1; i++)
                {
                        Tail.Insert(i, Tail[i + 1]);
                        Tail.RemoveAt(i);
                    }

                    Tail.Insert(Tail.Count, new Point(X, Y));
                    Tail.RemoveAt(0);
                }
            }
                        
            // move the snake one tile at a time
            X += Xdir * tile_width;
            Y += Ydir * tile_height;

            // set up hitboxes
            if(X <= 0)
            {
                X = 0;
            }else if(X >= width - tile_width)
            {
                X = width - tile_width;
            }

            if(Y <= 0)
            {
                Y = 0;
            }else if(Y >= height - tile_height)
            {
                Y = height - tile_height;
            }
        }
    }
}