using ConsoleSnake.SnakeGame.Interfaces;
using ConsoleSnake.SnakeGame.Types;

namespace ConsoleSnake.SnakeGame.GameLogic.GameObjects
{
    internal class EndGameScreen : IConsoleDrawable
    {
        public static char consoleSymbol = '-';

        public void DrawInConsole(params object[] objects)
        {
            Console.Clear();
            string message = "G a m e   O v e r!";
            Console.SetCursorPosition(WindowLimits.width / 2 - (message.Length / 2), WindowLimits.height - 15);
            Console.Write(message);
            message = "You are dead!";
            Console.SetCursorPosition(WindowLimits.width / 2 - (message.Length / 2), WindowLimits.height - 13);
            Console.Write(message);
            message = "Press y to restart the game";
            Console.SetCursorPosition(WindowLimits.width / 2 - (message.Length / 2), WindowLimits.height - 10);
            Console.Write(message);
            Console.SetCursorPosition(WindowLimits.width / 2, WindowLimits.height - 8);
        }

        public char GetConsoleSymbol()
        {
            throw new Exception("EndGameScreen contains a lot of strings");
        }
    }
}
