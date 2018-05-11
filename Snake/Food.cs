using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        public int X { get; set; }
        public int Y { get; set; }

        private int height = 500;
        private int width = 500;
        private int tile_height = 20;
        private int tile_width = 20;

        public Food()
        {
            X = 0;
            Y = 0;
        }

        public void PickSpot()
        {
            Random random = new Random();

            this.X = random.Next(0, width / tile_width) * tile_width;
            this.Y = random.Next(0, height / tile_height) * tile_height;

        }
    }
}
