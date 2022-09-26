using ConsoleSnake.SnakeGame.Interfaces;

namespace ConsoleSnake.SnakeGame.GameLogic.GameObjects
{
    internal class BarriersDrawer : IConsoleDrawable
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objects">[0] - barriers, [1] - applesEated</param>
        public void DrawInConsole(params object[] objects)
        {
            List<GameLogic.Objects.Barrier> barriers = ((List<GameLogic.Objects.Barrier>)objects[0]);
            int applesEated = (int)objects[1];

            if (barriers == null)
            {
                barriers = new List<GameLogic.Objects.Barrier>();
            }
            int barriersCount = GameLogic.Objects.Barrier.GetCount(applesEated);

            if (barriers.Count != barriersCount)
            {
                barriers = (GameLogic.Objects.Barrier.GenerateBarriersWithRandomPosition(barriersCount, barriers));
            }
            for (int i = 0; i <= barriers.Count - 1; i++)
            {
                barriers[i].DrawInConsole(barriers[i].position);
            }
        }

        public char GetConsoleSymbol()
        {
            throw new NotImplementedException();
        }
    }
}
