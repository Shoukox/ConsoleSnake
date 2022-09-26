using ConsoleSnake.SnakeGame.GameLogic.GameObjects;
using SnakeGame_Console.SnakeGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake.SnakeGame.GameLogic.Objects
{
    internal class DirectionUpdater
    {
        private Thread _updaterThread;
        private SnakeDirection sd;

        public void UpdateDirection()
        {
            while (true)
            {
                char key = Console.ReadKey().KeyChar;
                Console.Write("\b");
                sd.direction = key switch
                {
                    'a' => DirectionEnum.Left,
                    'd' => DirectionEnum.Right,
                    'w' => DirectionEnum.Up,
                    's' => DirectionEnum.Down,
                    _ => DirectionEnum.Other
                };
            }
        }
        public DirectionUpdater(SnakeDirection sd)
        {
            _updaterThread = new Thread(new ParameterizedThreadStart(
                    (s) => { UpdateDirection(); }
                ));

            this.sd = sd;
        }
        public void Start()
        {
            _updaterThread.Start();
        }

        [Obsolete]
        public void Suspend()
        {
            _updaterThread.Suspend();
        }
    }
}
