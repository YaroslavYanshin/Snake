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
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            snake.SetDirection(Direction.RIGHT);
            while (option == Option.StartGame)
            {
                timer.Show(0, 0);

                //snake moved
                if (timer.GetSec() % 20 == 0)
                {
                    timer.SyncTimer();
                    snake.Move();
                }
                
            }
        }


    }
}
