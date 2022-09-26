using ConsoleSnake.SnakeGame.GameLogic.GameObjects;
using ConsoleSnake.SnakeGame.GameLogic.Objects;
using ConsoleSnake.SnakeGame.GameLogic.Snake;
using ConsoleSnake.SnakeGame.Types;
using SnakeGame_Console.SnakeGame.Enums;
using SnakeGame_Console.SnakeGame.Interfaces;
using SnakeGame_Console.SnakeGame.Types;

namespace ConsoleSnake.SnakeGame
{
    class SnakeGameClass
    {
        public Snake snake;
        public List<GameLogic.Objects.Barrier> barriers;
        public Apple apple { get; set; }
        public int UpdateSpeed = 50; //1000ms = 1s

        public static bool gameIsActive = true;

        public BarriersDrawer barriersDrawer;
        public EndGameScreen endGameScreen;
        public GameBordersAndField gameBorders;
        public GameInterface gameInterface;

        /// <summary>
        /// This will block the thread.
        /// </summary>
        public void StartGame()
        {
            while (true)
            {
                if (!gameIsActive)
                {
                    endGameScreen.DrawInConsole();
                    char key = Console.ReadKey().KeyChar;
                    if (key == 'y')
                    {
                        gameIsActive = true;
                        snake.applesEated = 0;

                        snake = new Snake();

                        apple = Apple.CreateWithRandomPosition();

                        this.barriers.Clear();
                    }
                    continue;
                }
                gameBorders.DrawInConsole();

                snake.Move();
                snake.DrawSnake();

                if (snake.isIntersected(apple) != null)
                {
                    apple = Apple.CreateWithRandomPosition();
                }
                else
                {
                    foreach (var barrier in barriers)
                    {
                        if (snake.isIntersected(barrier) != null)
                        {
                            gameIsActive = false;
                        }
                    }
                }

                apple.DrawInConsole(apple.position);

                barriersDrawer.DrawInConsole(barriers, snake.applesEated);
                foreach (var barrier in barriers)
                {
                    if (barrier.isIntersected(snake) is GameLogic.Objects.Barrier)
                    {
                        gameIsActive = false;
                    }
                }

                gameInterface.DrawInConsole(snake.snakeDirection.direction, snake.applesEated);

                Thread.Sleep(UpdateSpeed);
            }
        }

        public SnakeGameClass()
        {
            snake = new Snake();
            apple = Apple.CreateWithRandomPosition();

            barriers = new List<GameLogic.Objects.Barrier>();

            barriersDrawer = new BarriersDrawer();
            endGameScreen = new EndGameScreen();
            gameBorders = new GameBordersAndField();
            gameInterface = new GameInterface();
        }
    }
}
