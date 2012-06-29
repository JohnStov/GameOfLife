namespace GameOfLife
{
    using System.Collections.Generic;

    public class Game
    {
        private readonly List<IGrid> generations = new List<IGrid>();

        public Game(IGrid grid)
        {
            generations.Add(grid);
        }

        public int CurrentGenerationNumber { get { return generations.Count - 1; } }

        public IList<IGrid> Generation { get { return generations; } }

        public IGrid CurrentGeneration { get { return generations[CurrentGenerationNumber]; } }


        public void Generate()
        {
            var nextGeneration = CurrentGeneration.Generate();
            generations.Add(nextGeneration);
        }
    }
}
