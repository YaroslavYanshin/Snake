using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;
        int speed;
        int maxSpeed = 40;
        ConsoleColor color;
        public Snake(Point tall, int length, Direction _direction, ConsoleColor color = ConsoleColor.Gray)
        {
            direction = _direction;
            pList = new List<Point>();
            speed = 0;
            this.color = color;
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tall, color);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                HandleKey(key.Key);
            }

            MoveStraight();
        }

        void MoveStraight()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head, color);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

        public int GetSpeed()
        {
            return maxSpeed - speed;
        }

        public void HandleKey(ConsoleKey key)
        {

            switch (key)
            {
                case ConsoleKey.DownArrow:
                    if (direction != Direction.UP)
                        direction = Direction.DOWN;
                    break;
                case ConsoleKey.UpArrow:
                    if (direction != Direction.DOWN)
                        direction = Direction.UP;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direction != Direction.RIGHT)
                        direction = Direction.LEFT;
                    break;
                case ConsoleKey.RightArrow:
                    if (direction != Direction.LEFT)
                        direction = Direction.RIGHT;
                    break;
            }

        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                //a++;
                //Console.SetCursorPosition(0, 0);
                //Console.WriteLine("Count:{0}", a);
                return true;
            }
            else
                return false;
        }

        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        public void SetDirection(Direction direction)
        {
            this.direction = direction;
        }
    }
}
