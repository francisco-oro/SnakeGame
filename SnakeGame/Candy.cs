using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Candy
    {
        public Position Position { get; set; }

        public Candy(int x, int y)
        {
            Position = new Position(x, y);
        }

        public void DisplayCandy() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Util.displayPosition(Position.x, Position.y, "0");
            Console.ResetColor();
        }

        public static Candy createCandy(Snake snake, Grid grid)
        {
            int x, y;
            bool isInSnake = false;
            do
            {
                Random random = new Random();
                x = random.Next(1, grid.width - 1);
                y = random.Next(1, grid.height - 1);
                // Make sure the new candy is not inside the snake
                isInSnake = snake.isPositionInQueue(x, y);

            } while (isInSnake);
            return new Candy(x, y); 
        } 
    }
}