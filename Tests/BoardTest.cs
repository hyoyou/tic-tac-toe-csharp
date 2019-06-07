using System.Collections.Generic;
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
            var expected = "----+---+----| 1 | 2 | 3 |----+---+----| 4 | 5 | 6 |----+---+----| 7 | 8 | 9 |----+---+----";

            Assert.AreEqual(expected, _writer.LastOutput);
        }

        [Test]
        public void ReturnsAnEmptyBoardAsAnArray()
        {
            var expected = new List<object>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(expected, _board.Spaces());
        }

        [Test]
        public void ReturnsAnArrayWithMoves()
        {
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(1, Constants.O);
            
            var expected = new List<object>{ Constants.O, 2, 3, 4, Constants.X, 6, 7, 8, 9 };

            Assert.AreEqual(expected, _board.Spaces());
        }
        
        [Test]
        public void MakesPlayerMoveOnBoard()
        {
            _board.MakeMove(5, Constants.X);
            
            var expected = new List<object>{ 1, 2, 3, 4, Constants.X, 6, 7, 8, 9 };

            Assert.AreEqual(expected, _board.Spaces());
        }
        
        [Test]
        public void ReturnsValidityOfPlayersMove()
        {
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(1, Constants.O);
            
            Assert.False(_board.IsValidMove(5));
            Assert.False(_board.IsValidMove(1));
            Assert.True(_board.IsValidMove(3));
            Assert.False(_board.IsValidMove(-1));
        }

        [Test]
        public void Returns9AvailableMovesWhenThereAreNoMovesMade()
        {
            var expected = new List<object>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual(expected, _board.AvailableMoves());
        }
        
        [Test]
        public void Returns5AvailableMovesWhenThereAre4MovesMade()
        {
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(3, Constants.X);
            _board.MakeMove(4, Constants.O);
            
            var expected = new List<object>{ 5, 6, 7, 8, 9 };

            Assert.AreEqual(expected, _board.AvailableMoves());
        }
        
        [Test]
        public void ReturnsTurnCount0WhenThereAreNoMoves()
        {
            Assert.AreEqual(0, _board.TurnCount());
        }
        
        [Test]
        public void ReturnsTurnCount1WhenThereIs1Move()
        {
            _board.MakeMove(5, Constants.X);

            Assert.AreEqual(1, _board.TurnCount());
        }
        
        [Test]
        public void ReturnsTurnCount5WhenThereAre5Moves()
        {
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(3, Constants.X);
            _board.MakeMove(4, Constants.O);
            _board.MakeMove(5, Constants.X);

            Assert.AreEqual(5, _board.TurnCount());
        }
    }
}