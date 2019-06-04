using System;
using NUnit.Framework;
using TicTacToe;

namespace Tests
{
    [TestFixture]
    public class BoardTest
    {
        private Board _board;
        private MockConsoleWriter _writer;

        [SetUp]
        public void Setup()
        {
            _writer = new MockConsoleWriter();
            _board = new Board(_writer);
        }
        
        [TearDown]
        public void TearDown()
        {
            _writer = null;
            _board = null;
        }

        [Test]
        public void DisplaysAnEmptyBoard()
        {
            _board.DisplayBoard();
            var expected = @" 1 | 2 | 3  ===+===+===  4 | 5 | 6  ===+===+===  7 | 8 | 9 ";

            Assert.AreEqual(expected, _writer.LastOutput );
        }

        [Test]
        public void ReturnsAnEmptyBoardAsAnArray()
        {
            var actual = _board.Spaces();
            object[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnsAnArrayWithAMove()
        {
            _board.MakeMove(5, 'X');
            var actual = _board.Spaces();
            object[] expected = { 1, 2, 3, 4, 'X', 6, 7, 8, 9 };

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ReturnsAnArrayWithMoves()
        {
            _board.MakeMove(5, 'X');
            _board.MakeMove(1, 'O');
            var actual = _board.Spaces();
            object[] expected = { 'O', 2, 3, 4, 'X', 6, 7, 8, 9 };

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ReturnsContentOfCellThatIsEmpty()
        {
            var actual = _board.Space(5);
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ReturnsContentOfCellWithMove()
        {
            _board.MakeMove(5, 'X');
            var actual = _board.Space(5);
            char expected = 'X';

            Assert.AreEqual(expected, actual);
        }
    }
}