using System.Diagnostics;

namespace SnakeGame;

internal class Program
{

    static void Main(string[] args)
    {
        bool hasEaten = false;
        Grid defaultGrid = new Grid( 20, 20);
        Snake snake = new Snake(10, 10);
        Candy candy = new Candy(0,0);

        do
        {
            Console.Clear();
            defaultGrid.displayGrid();
            snake.Move(hasEaten);

            hasEaten = snake.eatCandy(candy, defaultGrid);
            snake.displaySnake();

            if (!defaultGrid.containsCandy)
            {
                candy = Candy.createCandy(snake, defaultGrid);
                defaultGrid.containsCandy = true;
            }

            candy.DisplayCandy();

            

            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds <= 250)
            {
                snake.Direction = readMovement(snake.Direction);
            }
            snake.isAlive = snake.Die(snake, defaultGrid);
            Console.WriteLine(snake.isAlive);

        } while (snake.isAlive );

        Console.ReadKey();
    }

    static Direction readMovement(Direction currentMovement)
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.DownArrow && currentMovement != Direction.Up)
            {
                return Direction.Down;
            } 
            else if (key == ConsoleKey.UpArrow && currentMovement != Direction.Down)
            {
                return Direction.Up;
            }
            else if (key == ConsoleKey.RightArrow && currentMovement != Direction.Left)
            {
                return Direction.Right;
            }
            else if (key == ConsoleKey.LeftArrow && currentMovement != Direction.Right)
            {
                return Direction.Left;
            }
        }
        return currentMovement;
    }
}