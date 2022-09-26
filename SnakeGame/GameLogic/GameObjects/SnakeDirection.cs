using SnakeGame_Console.SnakeGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake.SnakeGame.GameLogic.GameObjects
{
    internal class SnakeDirection
    {
        public DirectionEnum direction;

        public SnakeDirection()
        {
            this.direction = DirectionEnum.Other;
        }
    }
}
