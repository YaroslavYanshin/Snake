using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            // Console.ForegroundColor = ConsoleColor.Green; // Для цвета 

            Walls walls = new Walls(80, 24);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    Console.SetCursorPosition(35, 11);
                    Console.WriteLine("Game over:{0}",a);
                  
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                    a++;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Count:{0}", a);
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);  
                }
                Thread.Sleep(200);
                //snake.Move();
            }
            Console.ReadKey();
           
        }

    }
}
