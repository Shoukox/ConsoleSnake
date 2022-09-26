using ConsoleSnake.SnakeGame.GameLogic.GameObjects;
using ConsoleSnake.SnakeGame.GameLogic.Interfaces;
using ConsoleSnake.SnakeGame.GameLogic.Objects;
using ConsoleSnake.SnakeGame.Interfaces;
using ConsoleSnake.SnakeGame.Types;
using SnakeGame_Console.SnakeGame.Interfaces;
using SnakeGame_Console.SnakeGame.Types;

namespace ConsoleSnake.SnakeGame.GameLogic.Snake
{
    internal class Snake : IMovable, ICanIntersect, ISnake
    {
        private DirectionUpdater directionUpdater;

        public List<IMovable> snake { get; set; }
        public SnakeDirection snakeDirection;
        public int applesEated = 0;

        public IMovable GetSnakeHead() => snake.First();
        public void DrawSnake()
        {
            Position position = null;
            for (int i = snake.Count - 1; i >= 1; i--)
            {
                position = snake[i].GetPosition();
                ((IConsoleDrawable)snake[i]).DrawInConsole(position);
            }
            var movableSnakeHead = GetSnakeHead();
            position = movableSnakeHead.GetPosition();

            ((IConsoleDrawable)movableSnakeHead).DrawInConsole(position);
        }

        public void Move()
        {
            Position position = null;
            for (int i = snake.Count - 1; i >= 1; i--)
            {
                position = snake[i - 1].GetPosition();
                snake[i].SetPosition(new Position(position));
            }
            var movableSnakeHead = GetSnakeHead();
            position = movableSnakeHead.GetPosition();

            if (snakeDirection.direction == DirectionEnum.Left)
                position.posX -= 1;
            else if (snakeDirection.direction == DirectionEnum.Right)
                position.posX += 1;
            else if (snakeDirection.direction == DirectionEnum.Up)
                position.posY -= 1;
            else if (snakeDirection.direction == DirectionEnum.Down)
                position.posY += 1;

            movableSnakeHead.SetPosition(position);
        }

        /// <summary>
        /// if intersected smth, then return [obj] else null
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public IMovable isIntersected(IMovable collision)
        {
            if (collision.GetPosition() != GetPosition())
                return null;
            if (collision is Apple apple)
            {
                applesEated += 1;
                snake.Add(new SnakeTail());
                //apple = Apple.CreateWithRandomPosition();

                return apple;
            }
            else if (collision is Objects.Barrier barrier)
            {
                return barrier;
            }
            return null;
        }

        public Position GetPosition() => GetSnakeHead().GetPosition();

        public void SetPosition(Position position) => this.GetSnakeHead().SetPosition(position);

        public Snake()
        {
            snakeDirection = new SnakeDirection();
            directionUpdater = new DirectionUpdater(snakeDirection);
            directionUpdater.Start();

            //creating list with snake tiles and adding snakehead 
            snake = new List<IMovable>();
            SnakeHead snakeHead = new SnakeHead();
            snakeHead.position = Position.GetRandomPosition(WindowLimits.width, WindowLimits.height);
            snake.Add(snakeHead);
        }
    }
}
