using SnakeGame_Console.SnakeGame.Interfaces;

namespace ConsoleSnake.SnakeGame.GameLogic.Interfaces
{
    internal interface ICanIntersect
    {
        public IMovable isIntersected(IMovable position);
    }
}
