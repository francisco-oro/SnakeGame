using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    static class Util
    {
        public static void displayPosition(int x, int y, string character)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(character);
        } 
    }
}
