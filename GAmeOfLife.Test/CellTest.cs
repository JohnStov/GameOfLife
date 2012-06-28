using FakeItEasy;
using NUnit.Framework;

namespace GameOfLife.Test
{
    [TestFixture]
    public class CellTest
    {
        [Test]
        public void CanCreateCell()
        {
            var cell = new Cell();
            Assert.That(cell, Is.Not.Null);
            Assert.That(cell.Grid, Is.Null); 
        }

        [Test]
        public void CellKnowsItsContainer()
        {
            var grid = A.Fake<IGrid>();

            var cell = new Cell(grid);
            Assert.That(cell.Grid, Is.SameAs(grid));
        }
    }
}
