using NSubstitute;
using NUnit.Framework;

namespace GameOfLife.Test
{
    using System;

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
            var cell = new Cell { IsAlive = true };
            Assert.That(cell.IsAlive, Is.True);
        }

        [Test]
        public void NoNeighboursKillsCell()
        {
            var cell = new Cell { IsAlive = true };

            cell.SetState(new ICell[0]);
            Assert.That(cell.IsAlive, Is.False);
        }

        [Test]
        public void OneNeighboursKillsCell()
        {
            var cell = new Cell { IsAlive = true };

            cell.SetState(new [] { LiveCell });
            Assert.That(cell.IsAlive, Is.False);
        }

        [Test]
        public void TwoNeighboursKeepsCellAlive()
        {
            var cell = new Cell { IsAlive = true };

            cell.SetState(new [] { LiveCell, LiveCell });
            Assert.That(cell.IsAlive, Is.True);
        }

        [Test]
        public void TwoNeighboursKeepsCellDead()
        {
            var cell = new Cell();

            cell.SetState(new[] { LiveCell, LiveCell });
            Assert.That(cell.IsAlive, Is.False);
        }

        [Test]
        public void ThreeNeighboursKeepsCellAlive()
        {
            var cell = new Cell { IsAlive = true };

            cell.SetState(new[] { LiveCell, LiveCell, LiveCell });
            Assert.That(cell.IsAlive, Is.True);
        }

        [Test]
        public void ThreeNeighboursCreatesCell()
        {
            var cell = new Cell();

            cell.SetState(new[] { LiveCell, LiveCell, LiveCell });
            Assert.That(cell.IsAlive, Is.True);
        }

        [Test]
        public void FourNeighboursKillsCell()
        {
            var cell = new Cell { IsAlive = true };

            cell.SetState(new[] { LiveCell, LiveCell, LiveCell, LiveCell });
            Assert.That(cell.IsAlive, Is.False);
        }

        [Test]
        public void DeadCellsHaveNoEffect()
        {
            var cell = new Cell { IsAlive = true };

            cell.SetState(new [] {DeadCell, DeadCell, DeadCell, DeadCell
            });
            Assert.That(cell.IsAlive, Is.False);
        }

        private ICell CreateSubstituteCell(bool alive)
        {
            var cell = Substitute.For<ICell>();
            cell.IsAlive.Returns(alive);
            return cell;
        }

        private ICell LiveCell { get { return CreateSubstituteCell(true); } }
        private ICell DeadCell { get { return CreateSubstituteCell(false); } }
    }
}
