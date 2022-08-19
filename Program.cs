namespace ConsoleSnake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleSnake.SnakeGame.SnakeGameClass snake = new ConsoleSnake.SnakeGame.SnakeGameClass();
            snake.StartGame();
        }
    }
}