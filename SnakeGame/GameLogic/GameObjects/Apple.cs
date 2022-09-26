using ConsoleSnake.SnakeGame.Interfaces;
using ConsoleSnake.SnakeGame.Types;
using SnakeGame_Console.SnakeGame.Interfaces;
using SnakeGame_Console.SnakeGame.Types;

namespace ConsoleSnake.SnakeGame.GameLogic.Objects
{
    class Apple : IConsoleDrawable, IMovable
    {
        public static char consoleSymbol = '2';

        public Position position { get; set; }

        public static Apple CreateWithRandomPosition()
        {
            return new Apple { position = Position.GetRandomPosition(WindowLimits.width - 1, WindowLimits.height - 1) };
        }


        public void DrawInConsole(params object[] objects)
        {
            Console.SetCursorPosition(position.posX, position.posY);
            Console.Write("\b");
            Console.Write(consoleSymbol);
        }

        public char GetConsoleSymbol() => consoleSymbol;
        public Position GetPosition() => position;

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void SetPosition(Position position)
        {
            this.position = position;
        }
    }
}
