using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SnakeGame
{
    public class Grid
    {
        public readonly int width, height;
        public bool containsCandy;
        
        public Grid (int _width, int _height)
        {
            width = _width;
            height = _height;
            containsCandy = false; 
        }

        
        public void displayGrid()
        {
            for (int i = 0; i < height; i++)
            {
                // right
                Util.displayPosition(height, i, "#");

                // left
                Util.displayPosition(0, i, "#");

                // Down
                Util.displayPosition(i, width, "#");

                // Up
                Util.displayPosition(i, 0, "#");

            }
        }
    }
}
