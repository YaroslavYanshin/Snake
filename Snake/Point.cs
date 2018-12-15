using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        public int x;
        public int y;
        public char sym;
        ConsoleColor color;
        public Point(int _x,int _y, char _sym, ConsoleColor color = ConsoleColor.Gray)
        {
            x = _x;
            y = _y;
            sym = _sym;
            this.color = color;
        }

        public Point(Point p, ConsoleColor color = ConsoleColor.Gray)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
            this.color = color;
        }

        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }

            else if (direction == Direction.LEFT)
            {
                x = x - offset;
            }

            else if(direction == Direction.UP)
            {
                y = y - offset;
            }

            else if (direction == Direction.DOWN)
            {
                y = y + offset;
            }
        }

        internal void Clear()
        {
            sym = ' ';
            Draw();
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(sym);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }
    }
}
