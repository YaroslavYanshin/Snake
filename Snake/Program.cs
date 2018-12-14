using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snake
{
    class Program
    {
        static int mseconds = 1;
        static void Main(string[] args)
        {
            int a = 0;
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;

            ConsoleKeyInfo key = default(ConsoleKeyInfo);
            bool pressed = false;

            // Console.ForegroundColor = ConsoleColor.Green; // Для цвета 
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(timerFunc);
            timer.Interval = 1;
            timer.Enabled = true;

            Walls walls = new Walls(80, 24);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();


            FoodCreator foodCreator = new FoodCreator(80, 25, '*');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Sec:{0:F2}", mseconds/60.0);
                Console.SetCursorPosition(15, 0);
                Console.WriteLine("Count:{0}", a);

                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey();
                    pressed = true;
                }

                if (mseconds%30 == 0)
                {
                    mseconds++;

                    if (pressed)
                    {
                        snake.HandleKey(key.Key);
                        pressed = false;
                    }                       
                    

                    if (walls.IsHit(snake) || snake.IsHitTail())
                    {
                        Console.SetCursorPosition(35, 11);
                        Console.WriteLine("Game over:{0}", a);

                        break;
                    }
                    if (snake.Eat(food))
                    {
                        food = foodCreator.CreateFood();
                        Console.ForegroundColor = ConsoleColor.Green;
                        food.Draw();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        a++;
                        
                    }
                    else
                    {
                        snake.Move();
                    }
                }
            }
            Console.ReadKey();

        }

        static private void timerFunc(object source, ElapsedEventArgs e)
        {
            mseconds++;
        }

    }
}
