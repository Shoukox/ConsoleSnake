using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame_Console.SnakeGame.Types
{
    class Position
    {
        public int posX { get; set; }
        public int posY { get; set; }

        public static bool operator ==(Position left, Position right) => (left.posX == right.posX) && (left.posY == right.posY);
        public static bool operator !=(Position left, Position right) => !(left == right);

        public static Position GetRandomPosition(int maxWidth, int maxHeight)
        {
            Random rnd = new Random();
            return new Position()
            {
                posX = rnd.Next(1, maxWidth),
                posY = rnd.Next(1, maxHeight)
            };
        }
        public Position()
        {

        }
        public Position(Position position)
        {
            this.posX = position.posX;
            this.posY = position.posY;
        }

    }
}
