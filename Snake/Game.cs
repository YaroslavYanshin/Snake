using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Game
    {
        private int points = 0;
        private int widthGameBoard;
        private int heighGameBoard;
        private ValueTuple<int, int> startSnakePosition;
        private Option option;
        private Menu menu;
        private Timer timer;
        private Walls walls;
        private int offset;
        private Snake snake;
        private FoodCreator foodCreator;

        public Game(int widthGameBoard, int heighGameBoard, int offset = 0)
        {
            this.widthGameBoard = widthGameBoard;
            this.heighGameBoard = heighGameBoard;
            this.offset = offset + 1;
            menu = new Menu(widthGameBoard, heighGameBoard, offset);
            walls = new Walls(widthGameBoard, heighGameBoard, offset);
            timer = new Timer();
            timer.Start();
            configureConsole();
            startSnakePosition = (X: 0, Y: 0);
            foodCreator = new FoodCreator(widthGameBoard, heighGameBoard, '*', ConsoleColor.Green, this.offset);

        }

        void configureConsole()
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;
        }

        public void gameProcess()
        {
            option = menu.Show();
            walls.Draw();
            Point p = new Point(startSnakePosition.Item1 + offset, startSnakePosition.Item2 + offset, '*');
            snake = new Snake(p, 4, Direction.RIGHT, ConsoleColor.Red);
            snake.Draw();
            snake.SetDirection(Direction.RIGHT);
            snake.SetSpeed(10);
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (option == Option.StartGame)
            {
                timer.Show(0, 0);

                if (timer.GetSec() % snake.GetSpeed() == 0)
                {
                    timer.SyncTimer();

                    if (snake.Eat(food))
                    {
                        food = foodCreator.CreateFood();
                        food.Draw();
                        points++;

                    }
                    else if (walls.IsHit(snake) || snake.IsHitTail())
                    {
                        Console.SetCursorPosition(35, 11);
                        Console.WriteLine("Game over:{0}", points);

                        break;
                    }
                    else
                    {
                        snake.Move();
                    }
                }

            }
        }

        void printCount(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("Points: {0}", points);
        }

    }
}
