using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake.SnakeGame.Types
{
    internal abstract class WindowLimits
    {
        public static int height = Console.WindowHeight - 10;
        public static int width = Console.WindowWidth;
    }
}
