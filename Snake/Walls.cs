using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight, int offset = 0)
        {
            wallList = new List<Figure>();

            HorizontalLine upLine = new HorizontalLine(offset, mapWidth - offset * 2, offset, '+');
            HorizontalLine downLine = new HorizontalLine(offset, mapWidth - offset * 2, mapHeight - offset * 2, '+');
            VerticalLine leftLine = new VerticalLine(offset, mapHeight - offset * 2, offset, '+');
            VerticalLine rightLine = new VerticalLine(offset, mapHeight - offset * 2, mapWidth - offset * 2, '+');

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }

            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
