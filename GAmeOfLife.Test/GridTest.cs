using System;
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
                    Assert.That(grid.GetCell(x,y), Is.InstanceOf<Cell>());
        }
    }
}
