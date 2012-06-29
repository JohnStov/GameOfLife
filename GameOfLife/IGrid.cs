namespace GameOfLife
{
    public interface IGrid
    {
        int Width { get; }
        int Height { get; }

        ICell this[int x, int y] { get; }

        bool[,] GetState();

        IGrid Generate();
    }
}