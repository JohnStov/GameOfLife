using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Grid : IGrid
    {
        private readonly ICell[,] cells;

        public Grid()
            : this(10, 10)
        {
        }

        public Grid(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException("width");

            if (height <= 0)
                throw new ArgumentOutOfRangeException("height");

            cells = new ICell[width, height];
            for(int x = 0; x < width; ++x)
                for(int y = 0; y < height; ++y)
                    cells[x,y] = new Cell(this);
        }

        public Grid(bool[,] grid)
        {
            cells = new ICell[grid.GetLength(0), grid.GetLength(1)];
            
            for (int x = 0; x < grid.GetLength(0); ++x)
                for (int y = 0; y < grid.GetLength(1); ++y)
                    cells[x, y] = new Cell(this) { IsAlive = grid[x,y] };
        }

        public bool[,] GetState()
        {
            var result = new bool[Width, Height];

            for (int x = 0; x < Width; ++x)
                for (int y = 0; y < Height; ++y)
                    result[x, y] = this[x, y].IsAlive;

            return result;
        }

        public int Width { get { return cells.GetLength(0); } }
        public int Height { get { return cells.GetLength(1); } }

        public ICell this[int x, int y] { get { return cells[x, y]; } }

        public IGrid Generate()
        {
            var nextGen = new Grid(Width, Height);
            for (int x = 0; x < Width; ++x)
                for (int y = 0; y < Height; ++y)
                    nextGen[x, y].SetState(GetCellNeighbours(x, y));

            return nextGen;
        }

        public IEnumerable<ICell> GetCellNeighbours(int x, int y)
        {
            for (int xPos = x - 1; xPos <= x + 1; ++xPos)
                for (int yPos = y - 1; yPos <= y + 1; ++yPos)
                {
                    if (xPos >= 0 && xPos < Width 
                        && yPos >= 0 && yPos < Height 
                        && (xPos != x || yPos != y))
                            yield return this[xPos, yPos];
                }
        }

        public IEnumerable<ICell> GetCellNeighbours(ICell cell)
        {
            int x;
            int y;

            if (!TryGetCellLocation(cell, out x, out y))
                return new ICell[0];

            return GetCellNeighbours(x, y);
        }

        private bool TryGetCellLocation(ICell cell, out int x, out int y)
        {
            for (x = 0; x < cells.GetLength(0); ++x)
                for (y = 0; y < cells.GetLength(1); ++y)
                    if (cell == cells[x, y])
                        return true;

            x = y = 0;
            return false;
        }
    }
}
