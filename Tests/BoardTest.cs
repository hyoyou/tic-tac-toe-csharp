using NUnit.Framework;
using TicTacToe;

namespace Tests
{
    [TestFixture]
    public class BoardTest
    {
        [Test]
        public void DisplaysAnEmptyBoard()
        {
            MockConsoleWriter writer = new MockConsoleWriter();
            Board board = new Board(writer);

            board.DisplayBoard();
            var expected = @" 1 | 2 | 3  ===+===+===  4 | 5 | 6  ===+===+===  7 | 8 | 9 ";

            Assert.AreEqual(expected, writer.LastOutput );
        }
    }
}