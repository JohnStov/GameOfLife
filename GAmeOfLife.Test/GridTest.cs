using System;
using System.Linq;
using NUnit.Framework;

namespace GameOfLife.Test
{
    [TestFixture]
    public class GridTest
    {
        [Test]
        public void CanCreateGrid()
        {
            var grid = new Grid();
            Assert.That(grid, Is.Not.Null);
        }

        [Test]
        public void DefaultGridIsTenByTen()
        {
            var grid = new Grid();
            Assert.That(grid.Width, Is.EqualTo(10));
            Assert.That(grid.Height, Is.EqualTo(10));
        }

        [Test]
        public void CanSetNonDefaultSize()
        {
            var grid = new Grid(20, 20);
            Assert.That(grid.Width, Is.EqualTo(20));
            Assert.That(grid.Height, Is.EqualTo(20));
        }

        [Test]
        public void CannotCreateGridWithNegativeWidth()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(-20, 20));
        }

        [Test]
        public void CannotCreateGridWithNegativeHeight()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(20, -20));
        }
        
        [Test]
        public void CannotCreateGridWithZeroWidth()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(0, 20));
        }

        [Test]
        public void CannotCreateGridWithZeroHeight()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(20, 0));
        }

        [Test]
        public void GridHasCells()
        {
            var grid = new Grid();
            for (int x = 0; x < grid.Width; ++x)
                for (int y = 0; y < grid.Height; ++y)
                    Assert.That(grid[x,y], Is.InstanceOf<Cell>());
        }

        [Test]
        public void CanGetNeighboursOfCell()
        {
            var grid = new Grid();

            var neighbours = grid.GetCellNeighbours(5, 5);

            Assert.That(neighbours.Count(), Is.EqualTo(8));
        }

        [Test]
        public void CornerHas3Neigbours()
        {
            var grid = new Grid();

            var neighbours = grid.GetCellNeighbours(0, 0);

            Assert.That(neighbours.Count(), Is.EqualTo(3));
        }

        [Test]
        public void EdgeHas5Neigbours()
        {
            var grid = new Grid();

            var neighbours = grid.GetCellNeighbours(0, 1);

            Assert.That(neighbours.Count(), Is.EqualTo(5));
        }

        [Test]
        public void CanGetNeighboursByCell()
        {
            var grid = new Grid();
            var cell = grid[5, 5];

            var neighbours = grid.GetCellNeighbours(cell);

            Assert.That(neighbours.Count(), Is.EqualTo(8));
        }

        [Test]
        public void CellNotInGridHasNoNeighbours()
        {
            var grid = new Grid();
            var cell = new Cell();

            var neighbours = grid.GetCellNeighbours(cell);

            Assert.That(neighbours.Count(), Is.EqualTo(0));
        }

        [Test]
        public void CanCreateGridFromArray()
        {
            var setup = new[,] { { true, true, true }, { false, false, false }, { true, false, true } };

            var grid = new Grid(setup);

            Assert.That(grid.Width, Is.EqualTo(3));
            Assert.That(grid.Height, Is.EqualTo(3));
            Assert.That(grid[0, 0].IsAlive, Is.True);
            Assert.That(grid[0, 1].IsAlive, Is.True);
            Assert.That(grid[0, 2].IsAlive, Is.True);
            Assert.That(grid[1, 0].IsAlive, Is.False);
            Assert.That(grid[1, 1].IsAlive, Is.False);
            Assert.That(grid[1, 2].IsAlive, Is.False);
            Assert.That(grid[2, 0].IsAlive, Is.True);
            Assert.That(grid[2, 1].IsAlive, Is.False);
            Assert.That(grid[2, 2].IsAlive, Is.True);
        }

        [Test]
        public void CanSaveGridToArray()
        {
            var setup = new[,] { { true, true, true }, { false, false, false }, { true, false, true } };

            var grid = new Grid(setup);
            Assert.That(grid.GetState(), Is.EqualTo(setup));
        }

        [Test]
        public void CanGenerate()
        {
            var grid = new Grid();
            var nextGen = grid.Generate();
            
            Assert.That(nextGen, Is.Not.SameAs(grid));
        }

    }
}
