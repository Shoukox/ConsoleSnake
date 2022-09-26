using SnakeGame_Console.SnakeGame.Types;

namespace SnakeGame_Console.SnakeGame.Interfaces
{
    interface IMovable
    {
        public void Move();
        public Position GetPosition();
        public void SetPosition(Position position);
    }
}
