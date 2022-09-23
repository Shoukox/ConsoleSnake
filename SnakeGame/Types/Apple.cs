using ConsoleSnake.SnakeGame.Types;

namespace SnakeGame_Console.SnakeGame.Types
{
    class Apple
    {
        public static char name = '2';

        public Position position { get; set; }

        public static Apple CreateWithRandomPosition()
        {
            return new Apple { position = Position.GetRandomPosition(WindowLimits.width - 1, WindowLimits.height - 1) };
        }


    }
}
