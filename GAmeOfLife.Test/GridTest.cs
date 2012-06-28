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
    }
}
