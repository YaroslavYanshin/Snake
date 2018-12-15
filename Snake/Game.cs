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
        private ValueTuple<int, int> startSnakePosition = (x: 0, y: 0);
        private Option option;
        private Menu menu;
        private Timer timer;
        private Walls walls;

        public Game(int widthGameBoard, int heighGameBoard, int offset = 0)
        {
            this.widthGameBoard = widthGameBoard;
            this.heighGameBoard = heighGameBoard;
            menu = new Menu(widthGameBoard, heighGameBoard, offset);
            walls = new Walls(widthGameBoard, heighGameBoard, 2);
            timer = new Timer();
            timer.Start();
            configureConsole();
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
            while (option == Option.StartGame)
            {
                timer.Show(0, 0);
            }
        }


    }
}
