using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodCreator
    {
        int mapWidth;
        int mapHeight;
        char sym;
        int offset;
        ConsoleColor color;
        Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym, ConsoleColor color ,int offset = 0)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
            this.offset = offset;
            this.color = color;
        }

        public Point CreateFood()
        {
            int x = random.Next(offset, mapWidth - offset);
            int y = random.Next(offset, mapHeight - offset);
            return new Point(x, y, sym, color);

        }
    }
}
