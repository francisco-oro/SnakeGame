using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        List<Position> Queue { get; set; }
        public Direction Direction { get; set; }
        public int Points { get; set; }
        public bool isAlive { get; set; }

        public Snake(int x, int y) {
            Position initialPosition = new Position(x, y);
            Queue = new List<Position>() { initialPosition };
            Direction = Direction.Down;
            Points = 0; 
            isAlive = true;
        }

        public void displaySnake()
        {
            foreach (Position position in Queue)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Util.displayPosition(position.x , position.y, "x");
                Console.ResetColor();
            }
        }

        public bool Die(Snake snake, Grid grid)
        {
            
            Position headPosition = snake.Queue.First();
            return snake.isPositionInQueue(headPosition.x, headPosition.y) || isHeadInGround(grid, headPosition);
        }

        public bool isHeadInGround(Grid grid, Position headPosition)
        {
            return headPosition.x == 0 || headPosition.x == grid.width ||
                headPosition.y == 0 || headPosition.y == grid.height;
        }

        public void Move(bool hasEaten)
        {
            List<Position> newQueue = new List<Position>();
            newQueue.Add(getNewPosition());
            newQueue.AddRange(Queue);

            if(!hasEaten)
            {
                newQueue.Remove(newQueue.Last());
            }
            Queue = newQueue;
        }

        public Position getNewPosition()
        {
            int x = Queue.First().x;
            int y = Queue.First().y;

            switch(Direction)
            {
                case Direction.Up:
                    y -= 1;
                    break;
                case Direction.Down:
                    y += 1;
                    break;
                case Direction.Left:
                    x -= 1;
                    break;
                case Direction.Right:
                    x += 1;
                    break;

            }

            return new Position(x, y);
        }

        public bool isPositionInQueue(int x, int y)
        {
            return Queue.Any(a => a.x == x && a.y == y);
        }

        public bool autoCollision(int x, int y)
        {
            List<Position> truncatedQueue = Queue;
            truncatedQueue.Remove(truncatedQueue.First());
            return truncatedQueue.Any(a => a.x == x && a.y == y);
        }

        public bool eatCandy(Candy candy, Grid grid)
        {
            if (isPositionInQueue(candy.Position.x, candy.Position.y))
            {
                Points += 10;
                grid.containsCandy = false;
                return true; 

            }
            return false;
        }
    }
}
