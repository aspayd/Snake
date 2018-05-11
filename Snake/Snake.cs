using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Xdir { get; set; }
        public int Ydir { get; set; }
        public int Speed { get; set; }

        private int total = 0;
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
            Speed = 3;
        }

        public bool Eat(Food pos)
        {
            if(X == pos.X && Y == pos.Y)
            {
                total++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Move()
        {


            X += Xdir * tile_width;
            Y += Ydir * tile_height;

            if(X < 0)
            {
                X = 0;
            }else if(X > width - tile_width)
            {
                X = width - tile_width;
            }

            if(Y < 0)
            {
                Y = 0;
            }else if(Y > height - tile_height)
            {
                Y = height - tile_height;
            }
        }
    }
}