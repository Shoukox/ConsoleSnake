using System;
using System.Collections.Generic;
using System.Text;
using SnakeGame_Console.SnakeGame.Interfaces;
using SnakeGame_Console.SnakeGame.Types;
using SnakeGame_Console.SnakeGame.Enums;
using System.Threading;
using System.Linq;
using ConsoleSnake.SnakeGame.Types;

namespace ConsoleSnake.SnakeGame
{
    class SnakeGameClass
    {
        public List<IMovable> Snake { get; set; }
        public List<Types.Barrier> barriers;
        public Apple apple { get; set; }
        public int UpdateSpeed = 100; //1000ms = 1s
        public DirectionEnum direction;

        public bool active = true;

        public int applesEated = 0;

        /// <summary>
        /// This will block the thread.
        /// </summary>

        public void StartGame()
        {
            while (true)
            {
                if (!active)
                {
                    EndGame();
                    continue;
                }
                DrawBorders();
                UpdateDirection();
                DrawAndMoveSnake();
                DrawOrCreateApple();
                DrawOrCreateBarriers();
                DrawInterface();

                Thread.Sleep(Convert.ToInt32(UpdateSpeed - (UpdateSpeed * (applesEated * 0.1))));
            }
        }
        public async void UpdateDirection()
        {
            await Task.Run(() =>
            {
                char key = Console.ReadKey().KeyChar;
                Console.Write("\b");
                direction = key switch
                {
                    'a' => DirectionEnum.Left,
                    'd' => DirectionEnum.Right,
                    'w' => DirectionEnum.Up,
                    's' => DirectionEnum.Down,
                    _ => DirectionEnum.Other
                };
            });
        }
        public void DrawBorders()
        {
            Console.SetCursorPosition(0, 0);
            string lineOfChars = "";
            for (int i = 1; i <= WindowLimits.width; i++)
                lineOfChars += "#";

            Console.WriteLine(lineOfChars);
            for (int i = 1; i <= WindowLimits.height; i++)
            {
                Console.WriteLine("#" + lineOfChars.Remove(0, 2).Replace("#", ".") + "#");
            }
            Console.WriteLine(lineOfChars);
        }
        public void DrawInterface()
        {
            Console.SetCursorPosition(WindowLimits.width / 2 - 10, WindowLimits.height + 5);
            Console.Write($"Current direction: {direction}          ");
            Console.SetCursorPosition(WindowLimits.width / 2 - 10, WindowLimits.height + 6);
            Console.Write($"Apples Eated: {applesEated}      ");
        }
        public void DrawAndMoveSnake()
        {
            Position position = null;
            for (int i = Snake.Count - 1; i >= 1; i--)
            {
                position = Snake[i - 1].GetPosition();
                ((SnakeTail)Snake[i]).position = new Position(position);
                Console.SetCursorPosition(position.posX, position.posY);
                Console.Write("\b");
                Console.Write(SnakeTail.name);
            }
            var movableSnakeHead = Snake[0];
            position = movableSnakeHead.GetPosition();
            switch (direction)
            {
                case DirectionEnum.Left:
                    position.posX -= 1;
                    movableSnakeHead.Move(position);
                    break;
                case DirectionEnum.Right:
                    position.posX += 1;
                    movableSnakeHead.Move(position);
                    break;
                case DirectionEnum.Up:
                    position.posY -= 1;
                    movableSnakeHead.Move(position);
                    break;
                case DirectionEnum.Down:
                    position.posY += 1;
                    movableSnakeHead.Move(position);
                    break;
            }
            Console.SetCursorPosition(position.posX, position.posY);
            Console.Write("\b");
            Console.Write(SnakeHead.name);


        }
        public void DrawOrCreateApple()
        {
            if (((SnakeHead)Snake[0]).IsIntersectedApple(apple))
            {
                applesEated += 1;
                if (Snake.Count == 1)
                    Snake.Add(new SnakeTail(direction));
                else
                    Snake.Add(new SnakeTail(Snake[Snake.Count - 1].GetPosition(), Snake[Snake.Count - 2].GetPosition()));
                apple = Apple.CreateWithRandomPosition();
            }
            Console.SetCursorPosition(apple.position.posX, apple.position.posY);
            Console.Write("\b");
            Console.Write(Apple.name);
        }
        public void DrawOrCreateBarriers()
        {
            if (barriers == null)
            {
                barriers = new List<Types.Barrier>();
            }
            int barriersCount = Types.Barrier.GetCount(applesEated);

            if (barriers.Count != barriersCount)
            {
                barriers.Clear();
                barriers.AddRange(Types.Barrier.GenerateBarriersWithRandomPosition(barriersCount));
            }
            for (int i = 0; i <= barriers.Count - 1; i++)
            {
                var barrier = barriers[i];
                if (((SnakeHead)Snake[0]).IsIntersectedBarrier(barrier))
                {
                    active = false;
                    return;
                }
            }
            for (int i = 0; i <= barriers.Count - 1; i++)
            {
                Console.SetCursorPosition(barriers[i].position.posX, barriers[i].position.posY);
                Console.Write("\b");
                Console.Write(Types.Barrier.name);
            }

        }
        private void EndGame()
        {
            Console.Clear();
            string message = "G a m e   O v e r!";
            Console.SetCursorPosition(WindowLimits.width / 2 - (message.Length / 2), WindowLimits.height - 15);
            Console.Write(message);
            message = "You are dead!";
            Console.SetCursorPosition(WindowLimits.width / 2 - (message.Length / 2), WindowLimits.height - 13);
            Console.Write(message);
            message = "Press y to restart the game";
            Console.SetCursorPosition(WindowLimits.width / 2 - (message.Length/2), WindowLimits.height - 10);
            Console.Write(message);
            Console.SetCursorPosition(WindowLimits.width / 2, WindowLimits.height - 8);
            char key = Console.ReadKey().KeyChar;
            if (key == 'y')
            {
                active = true;
                applesEated = 0;

                Snake = new List<IMovable>();

                SnakeHead snakeHead = new SnakeHead();
                snakeHead.position = Position.GetRandomPosition(Console.WindowWidth, Console.WindowHeight - 1);
                Snake.Add(snakeHead);

                apple = Apple.CreateWithRandomPosition();

                this.barriers.Clear();
            }

        }
        public SnakeGameClass()
        {
            Snake = new List<IMovable>();

            SnakeHead snakeHead = new SnakeHead();
            snakeHead.position = Position.GetRandomPosition(Console.WindowWidth, Console.WindowHeight - 1);
            Snake.Add(snakeHead);

            apple = Apple.CreateWithRandomPosition();
        }
    }
}
