using ConsoleSnake.SnakeGame.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame_Console.SnakeGame.Types
{
    class Apple
    {
        public Position position { get; set; }

        public static Apple CreateWithRandomPosition()
        {
            return new Apple { position = Position.GetRandomPosition(WindowLimits.width - 1, WindowLimits.height - 1) };
        }


    }
}
