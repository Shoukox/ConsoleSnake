using SnakeGame_Console.SnakeGame.Types;

namespace SnakeGame_Console.SnakeGame.Interfaces
{
    interface IMovable
    {
        public Position GetPosition();
        public void Move(Position position);
    }
}
