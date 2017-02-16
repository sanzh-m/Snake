using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    // 0 - right
    // 1 - up
    // 2 - left
    // 3 - down
    class Snake
    {
        List<int> positionX;
        List<int> positionY;
        int direction;
        int length;

        public Snake ()
        {

        }
        public Snake (int length)
        {
            this.length = length;
            positionX = new List<int>();
            positionY = new List<int>();
            direction = 0;
            for (int i = 0; i < length; i++)
            {
                positionY.Add(0);
                positionX.Add(i);
            }
        }

        public void goRight()
        {
            if (this.direction == 2)
            {
                return;
            }
            this.direction = 0;
            for (int i = 0; i < this.length - 1; i++)
            {
                positionX[i] = positionX[i + 1];
                positionY[i] = positionY[i + 1];
            }
            positionX[this.length - 1]++;
        }

        public void goUp()
        {
            if (this.direction == 3)
            {
                return;
            }
            this.direction = 1;
            for (int i = 0; i < this.length - 1; i++)
            {
                positionX[i] = positionX[i + 1];
                positionY[i] = positionY[i + 1];
            }
            positionY[this.length - 1]--;
        }

        public void goLeft()
        {
            if (this.direction == 0)
            {
                return;
            }
            this.direction = 2;
            for (int i = 0; i < this.length - 1; i++)
            {
                positionX[i] = positionX[i + 1];
                positionY[i] = positionY[i + 1];
            }
            positionX[this.length - 1]--;
        }

        public void goDown()
        {
            if (this.direction == 1)
            {
                return;
            }
            this.direction = 3;
            for (int i = 0; i < this.length - 1; i++)
            {
                positionX[i] = positionX[i + 1];
                positionY[i] = positionY[i + 1];
            }
            positionY[this.length - 1]++;
        }

        public List<int> getX()
        {
            return this.positionX;
        }
        public List<int> getY()
        {
            return this.positionY;
        }
    }

    class Board
    {
        int w, h;
        Snake snake;

        public Board (int w, int h, int snake_length)
        {
            this.w = w;
            this.h = h;
            this.snake = new Snake(snake_length);
        }

        void print()
        {
            Console.Clear();
            List<int> x = snake.getX(), y = snake.getY();
            for (int i = 0; i < x.Count; i++)
            {
                // |
                // _
                // x[i] y[i]
                x[i] = (x[i] + w) % w;
                y[i] = (y[i] + h) % h;
                Console.SetCursorPosition(x[i], y[i]);
                if (i == x.Count - 1)
                {
                    Console.Write("O");
                } else
                {
                    Console.Write("#");
                }
            }
        }

        public void run()
        {
            print();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow)
                {
                    snake.goRight();
                } else if (key.Key == ConsoleKey.LeftArrow)
                {
                    snake.goLeft();
                } else if (key.Key == ConsoleKey.DownArrow)
                {
                    snake.goDown();
                } else if (key.Key == ConsoleKey.UpArrow)
                {
                    snake.goUp();
                }
                print();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(50, 50, 10);
            board.run();
        }
    }
}
