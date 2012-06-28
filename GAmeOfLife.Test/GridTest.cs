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
    }
}
