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
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(3, Constants.X);
            _board.MakeMove(4, Constants.O);
            

            Assert.False(_rules.IsWon(_board.Spaces(), Constants.X));
        }
        
        [Test]
        public void IsWonReturnsTrueWhenGameHasVerticalWin()
        {
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(4, Constants.O);
            _board.MakeMove(9, Constants.X);
            

            Assert.True(_rules.IsWon(_board.Spaces(), Constants.X));
        }
        
        [Test]
        public void IsWonReturnsTrueWhenGameHasHorizontalWin()
        {
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(4, Constants.O);
            _board.MakeMove(2, Constants.X);
            _board.MakeMove(5, Constants.O);
            _board.MakeMove(3, Constants.X);
            

            Assert.True(_rules.IsWon(_board.Spaces(), Constants.X));
        }
        
        [Test]
        public void IsWonReturnsTrueWhenGameHasDiagonalWin()
        {
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(3, Constants.O);
            _board.MakeMove(9, Constants.X);
            

            Assert.True(_rules.IsWon(_board.Spaces(), Constants.X));
        }
        
        [Test]
        public void IsTieReturnsFalseWhenGameIsNotATie()
        {
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(3, Constants.O);
            _board.MakeMove(9, Constants.X);

            Assert.False(_rules.IsTie(_board));
        }
        
        [Test]
        public void IsTieReturnsTrueWhenGameIsATie()
        {
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(1, Constants.O);
            _board.MakeMove(3, Constants.X);
            _board.MakeMove(7, Constants.O);
            _board.MakeMove(4, Constants.X);
            _board.MakeMove(8, Constants.O);
            _board.MakeMove(9, Constants.X);
            _board.MakeMove(6, Constants.O);
            _board.MakeMove(2, Constants.X);

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
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(4, Constants.O);
            _board.MakeMove(9, Constants.X);

            Assert.True(_rules.IsGameOver(_board));
        }
        
        [Test]
        public void IsGameOverReturnsTrueWhenPlayerOWins()
        {
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(3, Constants.X);
            _board.MakeMove(5, Constants.O);
            _board.MakeMove(4, Constants.X);
            _board.MakeMove(8, Constants.O);

            Assert.True(_rules.IsGameOver(_board));
        }
        
        [Test]
        public void IsGameOverReturnsTrueWhenThereIsATie()
        {
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(1, Constants.O);
            _board.MakeMove(3, Constants.X);
            _board.MakeMove(7, Constants.O);
            _board.MakeMove(4, Constants.X);
            _board.MakeMove(8, Constants.O);
            _board.MakeMove(9, Constants.X);
            _board.MakeMove(6, Constants.O);
            _board.MakeMove(2, Constants.X);

            Assert.True(_rules.IsGameOver(_board));
        }
    }
}