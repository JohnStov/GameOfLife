namespace GameOfLife
{
    public class Cell
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
    }
}
