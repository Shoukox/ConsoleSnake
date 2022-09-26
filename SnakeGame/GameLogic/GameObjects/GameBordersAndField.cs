using ConsoleSnake.SnakeGame.Interfaces;
using ConsoleSnake.SnakeGame.Types;
using SnakeGame_Console.SnakeGame.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake.SnakeGame.GameLogic.Objects
{
    internal class GameBordersAndField : IConsoleDrawable
    {
        public char consoleSymbol = '#';

        public void DrawInConsole(params object[] objects)
        {
            Console.SetCursorPosition(0, 0);
            string lineOfChars = "";
            for (int i = 1; i <= WindowLimits.width; i++)
                lineOfChars += "#";

            Console.WriteLine(lineOfChars);
            for (int i = 1; i <= WindowLimits.height; i++)
            {
                Console.WriteLine("#" + lineOfChars.Remove(0, 2).Replace("#", ".") + "#");
            }
            Console.WriteLine(lineOfChars);
        }

        public char GetConsoleSymbol() => consoleSymbol;
    }
}
