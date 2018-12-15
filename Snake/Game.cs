using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Game
    {
        private int points;
        private int widthGameBoard;
        private int heighGameBoard;
        

        public Game(int widthGameBoard, int heighGameBoard)
        {
            this.widthGameBoard = widthGameBoard;
            this.heighGameBoard = heighGameBoard;
            points = 0;
            var startSnakePosition = (x: 0, y: 0);
        }

        void configureConsole()
        {
            Console.SetWindowSize(widthGameBoard, heighGameBoard);
            Console.SetBufferSize(widthGameBoard, heighGameBoard);
            Console.CursorVisible = false;
        }
    }
}
