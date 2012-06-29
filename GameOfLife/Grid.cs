using System;
using System.Collections.Generic;

namespace GameOfLife
{
    using System.Linq;

    public class Grid : IGrid
    {
        private readonly Cell[,] _cells;

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

            _cells = new Cell[width, height];
            for(int x = 0; x < width; ++x)
                for(int y = 0; y < height; ++y)
                    _cells[x,y] = new Cell();
        }

        public int Width { get { return _cells.GetLength(0); }  }
        public int Height { get { return _cells.GetLength(1); } }

        public Cell GetCell(int x, int y)
        {
            return _cells[x, y];
        }

        public IEnumerable<Cell> GetCellNeighbours(int x, int y)
        {
            for (int xPos = x - 1; xPos <= x + 1; ++xPos)
                for (int yPos = y - 1; yPos <= y + 1; ++yPos)
                {
                    if (xPos >= 0 && xPos < Width 
                        && yPos >= 0 && yPos < Height 
                        && (xPos != x || yPos != y))
                            yield return GetCell(xPos, yPos);
                }
        }

        public IEnumerable<Cell> GetCellNeighbours(Cell cell)
        {
            int x;
            int y;

            if (!TryGetCellLocation(cell, out x, out y))
                return new Cell[0];

            return GetCellNeighbours(x, y);
        }

        private bool TryGetCellLocation(Cell cell, out int x, out int y)
        {
            for (x = 0; x < _cells.GetLength(0); ++x)
                for (y = 0; y < _cells.GetLength(1); ++y)
                    if (cell == _cells[x, y])
                        return true;

            x = y = 0;
            return false;
        }
    }
}
