using ConsoleSnake.SnakeGame.Interfaces;
using ConsoleSnake.SnakeGame.Types;
using SnakeGame_Console.SnakeGame.Interfaces;
using SnakeGame_Console.SnakeGame.Types;

namespace ConsoleSnake.SnakeGame.GameLogic.Snake
{
    class SnakeHead : IMovable, IConsoleDrawable
    {
        public static char consoleSymbol = '1';

        public Position position { get; set; }

        public bool IsIntersectedByTails(IEnumerable<SnakeTail> tails)
        {
            bool answer = false;
            foreach (SnakeTail tail in tails)
            {
                if (tail.position == position)
                {
                    answer = true;
                    break;
                }
            }
            return answer;
        }

        public void Move(Position position)
        {
            if (position.posX >= WindowLimits.width)
                position.posX = 1;
            else if (position.posX <= 1)
                position.posX = WindowLimits.width - 1;

            if (position.posY > WindowLimits.height)
                position.posY = 1;
            else if (position.posY <= 0)
                position.posY = WindowLimits.height - 1;

            this.position = position;
        }
        public Position GetPosition() => position;

        public void SetPosition(Position position)
        {
            Move(position);
        }
        public void Move()
        {
            throw new NotImplementedException();
        }

        public char GetConsoleSymbol() => consoleSymbol;

        public void DrawInConsole(params object[] objects)
        {
            Console.SetCursorPosition(position.posX, position.posY);
            Console.Write("\b");
            Console.Write(GetConsoleSymbol());
            Console.SetCursorPosition(0, 0);
        }
        public SnakeHead()
        {

        }
    }
}
