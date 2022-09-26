using ConsoleSnake.SnakeGame.GameLogic.Interfaces;
using ConsoleSnake.SnakeGame.Interfaces;
using ConsoleSnake.SnakeGame.Types;
using SnakeGame_Console.SnakeGame.Interfaces;
using SnakeGame_Console.SnakeGame.Types;

namespace ConsoleSnake.SnakeGame.GameLogic.Objects
{
    internal class Barrier : IMovable, IConsoleDrawable, ICanIntersect
    {
        public static char consoleSymbol = '@';

        public Position position { get; set; }
        public Barrier(Position position)
        {
            this.position = position;
        }

        public static int GetCount(int applesEated)
        {
            return applesEated == 0 ? 0 : (int)Math.Pow(2, applesEated);
        }
        public static List<Barrier> GenerateBarriersWithRandomPosition(int count, List<Barrier> barriers)
        {
            for (int i = barriers.Count; i <= count - 1; i++)
            {
                barriers.Add(new Barrier(Position.GetRandomPosition(WindowLimits.width, WindowLimits.height)));
            }
            return barriers;
        }

        public char GetConsoleSymbol() => consoleSymbol;

        public Position GetPosition() => position;

        public void SetPosition(Position position)
        {
            this.position = position;
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void DrawInConsole(params object[] objects)
        {
            Console.SetCursorPosition(position.posX, position.posY);
            Console.Write("\b");
            Console.Write(consoleSymbol);
        }

        public IMovable isIntersected(IMovable position)
        {
            if (position is Snake.Snake snake)
                //for (int i = 0; i <= barriers.Count - 1; i++)
                //{
                //    var barrier = barriers[i];
                if (snake.isIntersected(this) is GameLogic.Objects.Barrier barrier)
                {
                    //gameIsActive = false;
                    return barrier;
                }
            // }

            return null;
        }
    }
}
