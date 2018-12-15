using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Menu
    {
        private bool show;
        private int widthScreen;
        private int heightScreen;
        private int offset;
        private int heightStartToPrint;
        private int startX;
        private int currentOption;
        private int lastOption;
        private List<String> listText;
        private ConsoleKeyInfo key;


        public Menu(int widthScreen, int heightScreen, int offset = 0)
        {
            this.widthScreen = widthScreen;
            this.heightScreen = heightScreen;
            this.offset = offset;
            show = false;
            currentOption = 0;
            lastOption = 0;
            heightStartToPrint = offset + 2;
            listText = new List<string>();
            listText.Add("Start game.");
            listText.Add("Continue.");
            listText.Add("Show leaders.");
            listText.Add("Quit.");
        }



        public Option Show()
        {
            show = true;

            drawBoundaries();
            prtintMenuOptions();
            while (show)
            {
                chooseOption();

                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey();
                    keyHandle(key.Key);
                }
            }
            Console.Clear();
            Option option = (Option)currentOption;
            return option;

        }

        public void Hide()
        {
            show = false;
        }
        void drawBoundaries()
        {
            for (int i = offset; i < heightScreen + offset; i++)
            {
                for (int j = offset; j < widthScreen + offset; j++)
                {
                    if (i == offset || i == heightScreen + offset - 1 ||
                        j == offset || j == widthScreen + offset - 1)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write("*");
                    }
                }
            }
        }

        void prtintMenuOptions()
        {
            startX = (widthScreen + offset) / 2 - 5;
            Console.SetCursorPosition(startX, heightStartToPrint);
            Console.Write("Menu:");
            for (int i = 0; i < listText.Count; i++)
            {
                Console.SetCursorPosition(startX - 3, heightStartToPrint + i + 1);
                Console.Write(listText[i]);
            }
        }

        public void keyHandle(ConsoleKey keyInfo)
        {
            lastOption = currentOption;
            switch (keyInfo)
            {
                case ConsoleKey.DownArrow:
                    currentOption++;
                    if (currentOption >= listText.Count)
                        currentOption = 0;
                    break;
                case ConsoleKey.UpArrow:
                    currentOption--;
                    if (currentOption < 0)
                        currentOption = listText.Count - 1;
                    break;
                case ConsoleKey.Enter:
                    show = false;
                    break;
                case ConsoleKey.Escape:
                    show = false;
                    currentOption = (int)Option.Quit;
                    break;

                default:
                    break;
            }
        }

        public void chooseOption()
        {
            int offsetFromText = 5;
            if (lastOption != currentOption)
            {
                Console.SetCursorPosition(startX - offsetFromText, heightStartToPrint + lastOption + 1);
                Console.Write(" ");
            }

            Console.SetCursorPosition(startX - offsetFromText, heightStartToPrint + currentOption + 1);
            Console.Write("*");

            Console.SetCursorPosition(startX - offsetFromText, heightStartToPrint + 10);
            Console.Write("*\t" + currentOption);
        }


    }
}
