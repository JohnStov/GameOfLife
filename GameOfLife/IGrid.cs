namespace GameOfLife
{
    public interface IGrid
    {
        int Width { get; }
        int Height { get; }
        Cell GetCell(int x, int y);
    }
}