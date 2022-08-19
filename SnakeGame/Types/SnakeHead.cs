using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSnake.SnakeGame.Types;
using SnakeGame_Console.SnakeGame.Interfaces;

namespace SnakeGame_Console.SnakeGame.Types
{
    class SnakeHead : IMovable
    {
        public static char name = '1';

        public Position position { get; set; }

        public bool IsIntersectedByTails(IEnumerable<SnakeTail> tails)
        {
            bool answer = false;
            foreach(SnakeTail tail in tails)
            {
                if(tail.position == position)
                {
                    answer = true;
                    break;
                }
            }
            return answer;
        }
        public bool IsIntersectedApple(Apple apple) => position == apple.position;
        public bool IsIntersectedBarrier(ConsoleSnake.SnakeGame.Types.Barrier barrier) => position == barrier.position;

        public void Move(Position position)
        {
            if (position.posX >= WindowLimits.width)
                position.posX = 1;
            else if (position.posX <= 1)
                position.posX = WindowLimits.width - 1;

            if (position.posY > WindowLimits.height)
                position.posY = 1;
            else if (position.posY <= 0)
                position.posY = WindowLimits.height - 1;

            this.position = position;
        }
        public Position GetPosition() => position;
    }
}
