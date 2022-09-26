namespace ConsoleSnake.SnakeGame.Interfaces
{
    internal interface IConsoleDrawable
    {
        public char GetConsoleSymbol();

        /// <summary>
        /// Draw object in console
        /// </summary>
        /// <param name="position">set null if useless</param>
        public void DrawInConsole(params object[] objects);
    }
}
