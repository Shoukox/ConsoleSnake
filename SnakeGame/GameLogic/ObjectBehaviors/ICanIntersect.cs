using SnakeGame_Console.SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake.SnakeGame.GameLogic.Interfaces
{
    internal interface ICanIntersect
    {
        public IMovable isIntersected(IMovable position);
    }
}
