using NUnit.Framework;
using TicTacToe;

namespace Tests
{
    [TestFixture]
    public class RulesTest
    {
        private Rules _rules;
        private Board _board;
        private MockConsoleWriter _writer;

        [SetUp]
        public void Setup()
        {
            _writer = new MockConsoleWriter();
            _board = new Board(_writer);
            _rules = new Rules();
        }
        
        [TearDown]
        public void TearDown()
        {
            _writer = null;
            _board = null;
        }

        [Test]
        public void IsWonReturnsFalseWhenGameIsNotWon()
        {
            _board.MakeMove(1, 'X');
            _board.MakeMove(2, 'O');
            _board.MakeMove(3, 'X');
            _board.MakeMove(4, 'O');
            

            Assert.False(_rules.IsWon(_board.Spaces(), 'X'));
        }
        
        [Test]
        public void IsWonReturnsTrueWhenGameHasVerticalWin()
        {
            _board.MakeMove(1, 'X');
            _board.MakeMove(2, 'O');
            _board.MakeMove(5, 'X');
            _board.MakeMove(4, 'O');
            _board.MakeMove(9, 'X');
            

            Assert.True(_rules.IsWon(_board.Spaces(), 'X'));
        }
        
        [Test]
        public void IsWonReturnsTrueWhenGameHasHorizontalWin()
        {
            _board.MakeMove(1, 'X');
            _board.MakeMove(4, 'O');
            _board.MakeMove(2, 'X');
            _board.MakeMove(5, 'O');
            _board.MakeMove(3, 'X');
            

            Assert.True(_rules.IsWon(_board.Spaces(), 'X'));
        }
        
        [Test]
        public void IsWonReturnsTrueWhenGameHasDiagonalWin()
        {
            _board.MakeMove(1, 'X');
            _board.MakeMove(2, 'O');
            _board.MakeMove(5, 'X');
            _board.MakeMove(3, 'O');
            _board.MakeMove(9, 'X');
            

            Assert.True(_rules.IsWon(_board.Spaces(), 'X'));
        }
        
        [Test]
        public void IsTieReturnsFalseWhenGameIsNotATie()
        {
            _board.MakeMove(1, 'X');
            _board.MakeMove(2, 'O');
            _board.MakeMove(5, 'X');
            _board.MakeMove(3, 'O');
            _board.MakeMove(9, 'X');

            Assert.False(_rules.IsTie(_board));
        }
        
        [Test]
        public void IsTieReturnsTrueWhenGameIsATie()
        {
            _board.MakeMove(5, 'X');
            _board.MakeMove(1, 'O');
            _board.MakeMove(3, 'X');
            _board.MakeMove(7, 'O');
            _board.MakeMove(4, 'X');
            _board.MakeMove(8, 'O');
            _board.MakeMove(9, 'X');
            _board.MakeMove(6, 'O');
            _board.MakeMove(2, 'X');

            Assert.True(_rules.IsTie(_board));
        }
        
        [Test]
        public void IsGameOverReturnsFalseWhenGameStarts()
        {
            Assert.False(_rules.IsGameOver(_board));
        }
        
        [Test]
        public void IsGameOverReturnsTrueWhenPlayerXWins()
        {
            _board.MakeMove(1, 'X');
            _board.MakeMove(2, 'O');
            _board.MakeMove(5, 'X');
            _board.MakeMove(4, 'O');
            _board.MakeMove(9, 'X');

            Assert.True(_rules.IsGameOver(_board));
        }
        
        [Test]
        public void IsGameOverReturnsTrueWhenPlayerOWins()
        {
            _board.MakeMove(1, 'X');
            _board.MakeMove(2, 'O');
            _board.MakeMove(3, 'X');
            _board.MakeMove(5, 'O');
            _board.MakeMove(4, 'X');
            _board.MakeMove(8, 'O');

            Assert.True(_rules.IsGameOver(_board));
        }
        
        [Test]
        public void IsGameOverReturnsTrueWhenThereIsATie()
        {
            _board.MakeMove(5, 'X');
            _board.MakeMove(1, 'O');
            _board.MakeMove(3, 'X');
            _board.MakeMove(7, 'O');
            _board.MakeMove(4, 'X');
            _board.MakeMove(8, 'O');
            _board.MakeMove(9, 'X');
            _board.MakeMove(6, 'O');
            _board.MakeMove(2, 'X');

            Assert.True(_rules.IsGameOver(_board));
        }
    }
}