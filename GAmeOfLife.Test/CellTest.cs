using NSubstitute;
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
            var grid = Substitute.For<IGrid>();

            var cell = new Cell(grid);
            Assert.That(cell.Grid, Is.SameAs(grid));
        }

        [Test]
        public void CellDefaultsDead()
        {
            var cell = new Cell();
            Assert.That(cell.IsAlive, Is.False);
        }

        [Test]
        public void CanSetCellAlive()
        {
            var cell = new Cell();
            cell.IsAlive = true;
            Assert.That(cell.IsAlive, Is.True);
        }
    }
}
