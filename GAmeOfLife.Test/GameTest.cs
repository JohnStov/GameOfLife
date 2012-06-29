using NUnit.Framework;

namespace GameOfLife.Test
{
    using NSubstitute;

    [TestFixture]
    public class GameTest
    {
        [Test]
        public void CanCreateGame()
        {
            var grid = Substitute.For<IGrid>();
            var game = new Game(grid);

            Assert.That(game, Is.Not.Null);
        }

        [Test]
        public void InitialGameHasNoGeneration()
        {
            var grid = Substitute.For<IGrid>();
            var game = new Game(grid);

            Assert.That(game.CurrentGenerationNumber, Is.EqualTo(0));
            Assert.That(game.CurrentGeneration, Is.SameAs(grid));
        }

        [Test]
        public void CanGenerate()
        {
            var grid = Substitute.For<IGrid>();
            var game = new Game(grid);

            game.Generate();

            Assert.That(game.CurrentGenerationNumber, Is.EqualTo(1));
            Assert.That(game.CurrentGeneration, Is.Not.SameAs(grid));

            grid.Received().Generate();
        }

        [Test]
        public void GenerateProducesRightResultInSimpleCase()
        {
            // A 3x3grid with 3 cells at edge generates one cell at centre

            var grid = new Grid(new[,] { { true, true, false }, { true, false, false }, { false, false, false } });
            var game = new Game(grid);
            game.Generate();

            Assert.That(game.CurrentGeneration.GetState(), Is.EqualTo(new [,] {{false, false, false}, {false, true, false}, {false, false, false}}));
        }
    }
}