using ConsoleSnake.SnakeGame.GameLogic.Interfaces;
using ConsoleSnake.SnakeGame.Interfaces;
using SnakeGame_Console.SnakeGame.Enums;
using SnakeGame_Console.SnakeGame.Interfaces;
using SnakeGame_Console.SnakeGame.Types;

namespace ConsoleSnake.SnakeGame.GameLogic.Snake;

class SnakeTail : IMovable, IConsoleDrawable
{
    public static char consoleSymbol = '0';

    public Position position { get; set; }

    public void Move(Position position)
    {
        this.position = position;
    }
    public Position GetPosition() => position;
    public void SetPosition(Position position)
    {
        this.position = position;
    }
    public SnakeTail()
    {
        position = new Position();
    }
    public char GetConsoleSymbol() => consoleSymbol;

    public void DrawInConsole(params object[] objects)
    {
        Console.SetCursorPosition(position.posX, position.posY);
        Console.Write("\b");
        Console.Write(GetConsoleSymbol());
        Console.SetCursorPosition(0, 0);
    }

    public void Move()
    {
        throw new NotImplementedException();
    }
}
