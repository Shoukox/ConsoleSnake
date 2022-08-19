using System;
using System.Collections.Generic;
using System.Text;
using SnakeGame_Console.SnakeGame.Enums;
using SnakeGame_Console.SnakeGame.Interfaces;

namespace SnakeGame_Console.SnakeGame.Types
{
    class SnakeTail : IMovable
    {
        public Position position { get; set; }

        public void Move(Position position)
        {
            this.position = position;
        }
        public SnakeTail(Position lastSnakeTailsPosition, Position secondLastSnakeTailsPosition)
        {
            position = new Position();


        }
        public SnakeTail(DirectionEnum direction)
        {
            position = new Position();
        }
        public Position GetPosition() => position;
    }
}
