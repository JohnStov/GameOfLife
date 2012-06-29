namespace GameOfLife
{
    public interface IGrid
    {
        int Width { get; }
        int Height { get; }

        Cell this[int x, int y] { get; }
    }
}