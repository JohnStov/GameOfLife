namespace GameOfLife
{
    using System.Collections.Generic;
    using System.Linq;

    public class Cell : ICell
    {
        public Cell()
            : this(null)
        {}

        public Cell(IGrid grid)
        {
            Grid = grid;
        }

        public IGrid Grid { get; private set; }

        public bool IsAlive { get; set; }

        public void SetState(IEnumerable<ICell> neighbourStates)
        {
            int liveNeighours = neighbourStates.Count(c => c.IsAlive);

            if (liveNeighours < 2 || liveNeighours > 3)
                IsAlive = false;

            if (!IsAlive && liveNeighours == 3)
                IsAlive = true;
        }
    }
}
