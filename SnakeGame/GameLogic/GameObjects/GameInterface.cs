using ConsoleSnake.SnakeGame.Interfaces;
using ConsoleSnake.SnakeGame.Types;
using SnakeGame_Console.SnakeGame.Enums;
using SnakeGame_Console.SnakeGame.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake.SnakeGame.GameLogic.Objects
{
    internal class GameInterface : IConsoleDrawable
    {
        private DirectionEnum direction;
        private int applesEated;

        public void UpdateInfo(DirectionEnum direction, int applesEated)
        {
            this.direction = direction;
            this.applesEated = applesEated;
        }

        public void DrawInConsole(params object[] objects)
        {
            var direction = (DirectionEnum)objects[0];
            var applesEated = (int)objects[1];

            Console.SetCursorPosition(WindowLimits.width / 2 - 10, WindowLimits.height + 5);
            Console.Write($"Current direction: {direction}          ");
            Console.SetCursorPosition(WindowLimits.width / 2 - 10, WindowLimits.height + 6);
            Console.Write($"Apples Eated: {applesEated}      ");
        }

        public char GetConsoleSymbol()
        {
            throw new Exception("Interface contains a lot of strings");
        }
    }
}
