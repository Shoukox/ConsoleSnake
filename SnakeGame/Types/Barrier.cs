using SnakeGame_Console.SnakeGame.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake.SnakeGame.Types
{
    internal class Barrier
    {
        public static char name = '@';

        public Position position { get; set; }
        public Barrier(Position position)
        {
            this.position = position;
        }
        //public static int GetCount(int applesEated)
        //{
        //    return Convert.ToInt32((WindowLimits.width * WindowLimits.height) * applesEated * 0.001);
        //}
        //public static List<Barrier> GenerateBarriersWithRandomPosition(int count)
        //{
        //    List<Barrier> barriers = new List<Barrier>();
        //    for (int i = 0; i <= count - 1; i++)
        //    {
        //        barriers.Add(new Barrier(Position.GetRandomPosition(WindowLimits.width, WindowLimits.height)));
        //    }
        //    return barriers;
        //}

        public static int GetCount(int applesEated)
        {
            return applesEated == 0 ? 0 : (int)Math.Pow(2, applesEated);
        }
        public static List<Barrier> GenerateBarriersWithRandomPosition(int count, List<Barrier> barriers)
        {
            for (int i = barriers.Count; i <= count - 1; i++)
            {
                barriers.Add(new Barrier(Position.GetRandomPosition(WindowLimits.width, WindowLimits.height)));
            }
            return barriers;
        }

    }
}
