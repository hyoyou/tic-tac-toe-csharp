using NUnit.Framework;
using TicTacToe;

namespace Tests
{
    [TestFixture]
    public class RulesTest
    {
        private Rules _rules3x3;
        private Board _board3x3;
        private MockConsoleWriter _writer;

        [SetUp]
        public void Setup()
        {
            _writer = new MockConsoleWriter();
            _board3x3 = new Board(_writer, 3);
            _rules3x3 = new Rules(3);
        }
        
        [TearDown]
        public void TearDown()
        {
            _writer = null;
            _board3x3 = null;
        }

        [Test]
        public void IsWonReturnsFalseWhenGameIsNotWon()
        {
            _board3x3.MakeMove(1, Constants.X);
            _board3x3.MakeMove(2, Constants.O);
            _board3x3.MakeMove(3, Constants.X);
            _board3x3.MakeMove(4, Constants.O);
            

            Assert.False(_rules3x3.IsWon(_board3x3.Spaces(), Constants.X));
            Assert.False(_rules3x3.IsWon(_board3x3.Spaces(), Constants.O));
        }
        
        [Test]
        public void IsWonReturnsTrueWhenGameHasVerticalWin()
        {
            _board3x3.MakeMove(1, Constants.X);
            _board3x3.MakeMove(2, Constants.O);
            _board3x3.MakeMove(5, Constants.X);
            _board3x3.MakeMove(4, Constants.O);
            _board3x3.MakeMove(9, Constants.X);
            

            Assert.True(_rules3x3.IsWon(_board3x3.Spaces(), Constants.X));
            Assert.False(_rules3x3.IsWon(_board3x3.Spaces(), Constants.O));
        }
        
        [Test]
        public void IsWonReturnsTrueWhenGameHasHorizontalWin()
        {
            _board3x3.MakeMove(1, Constants.X);
            _board3x3.MakeMove(4, Constants.O);
            _board3x3.MakeMove(2, Constants.X);
            _board3x3.MakeMove(5, Constants.O);
            _board3x3.MakeMove(3, Constants.X);
            

            Assert.True(_rules3x3.IsWon(_board3x3.Spaces(), Constants.X));
            Assert.False(_rules3x3.IsWon(_board3x3.Spaces(), Constants.O));
        }
        
        [Test]
        public void IsWonReturnsTrueWhenGameHasDiagonalWin()
        {
            _board3x3.MakeMove(1, Constants.X);
            _board3x3.MakeMove(2, Constants.O);
            _board3x3.MakeMove(5, Constants.X);
            _board3x3.MakeMove(3, Constants.O);
            _board3x3.MakeMove(9, Constants.X);
            

            Assert.True(_rules3x3.IsWon(_board3x3.Spaces(), Constants.X));
            Assert.False(_rules3x3.IsWon(_board3x3.Spaces(), Constants.O));
        }
        
        [Test]
        public void IsTieReturnsFalseWhenGameIsNotATie()
        {
            _board3x3.MakeMove(1, Constants.X);
            _board3x3.MakeMove(2, Constants.O);
            _board3x3.MakeMove(5, Constants.X);
            _board3x3.MakeMove(3, Constants.O);
            _board3x3.MakeMove(9, Constants.X);

            Assert.False(_rules3x3.IsTie(_board3x3));
        }
        
        [Test]
        public void IsTieReturnsTrueWhenGameIsATie()
        {
            _board3x3.MakeMove(5, Constants.X);
            _board3x3.MakeMove(1, Constants.O);
            _board3x3.MakeMove(3, Constants.X);
            _board3x3.MakeMove(7, Constants.O);
            _board3x3.MakeMove(4, Constants.X);
            _board3x3.MakeMove(8, Constants.O);
            _board3x3.MakeMove(9, Constants.X);
            _board3x3.MakeMove(6, Constants.O);
            _board3x3.MakeMove(2, Constants.X);

            Assert.True(_rules3x3.IsTie(_board3x3));
        }
        
        [Test]
        public void IsGameOverReturnsFalseWhenGameStarts()
        {
            Assert.False(_rules3x3.IsGameOver(_board3x3));
        }
        
        [Test]
        public void IsGameOverReturnsTrueWhenPlayerXWins()
        {
            _board3x3.MakeMove(1, Constants.X);
            _board3x3.MakeMove(2, Constants.O);
            _board3x3.MakeMove(5, Constants.X);
            _board3x3.MakeMove(4, Constants.O);
            _board3x3.MakeMove(9, Constants.X);

            Assert.True(_rules3x3.IsGameOver(_board3x3));
        }
        
        [Test]
        public void IsGameOverReturnsTrueWhenPlayerOWins()
        {
            _board3x3.MakeMove(1, Constants.X);
            _board3x3.MakeMove(2, Constants.O);
            _board3x3.MakeMove(3, Constants.X);
            _board3x3.MakeMove(5, Constants.O);
            _board3x3.MakeMove(4, Constants.X);
            _board3x3.MakeMove(8, Constants.O);

            Assert.True(_rules3x3.IsGameOver(_board3x3));
        }
        
        [Test]
        public void IsGameOverReturnsTrueWhenThereIsATie()
        {
            _board3x3.MakeMove(5, Constants.X);
            _board3x3.MakeMove(1, Constants.O);
            _board3x3.MakeMove(3, Constants.X);
            _board3x3.MakeMove(7, Constants.O);
            _board3x3.MakeMove(4, Constants.X);
            _board3x3.MakeMove(8, Constants.O);
            _board3x3.MakeMove(9, Constants.X);
            _board3x3.MakeMove(6, Constants.O);
            _board3x3.MakeMove(2, Constants.X);

            Assert.True(_rules3x3.IsGameOver(_board3x3));
        }
        
        [Test]
        public void IsAbleToReturnHorizontalWinInA5x5Board()
        {
            var board5x5 = new Board(_writer, 5);
            var rules5x5 = new Rules(5);
            
            board5x5.MakeMove(1, Constants.X);
            board5x5.MakeMove(6, Constants.O);
            board5x5.MakeMove(2, Constants.X);
            board5x5.MakeMove(7, Constants.O);
            board5x5.MakeMove(3, Constants.X);
            board5x5.MakeMove(8, Constants.O);
            board5x5.MakeMove(4, Constants.X);
            board5x5.MakeMove(9, Constants.O);
            board5x5.MakeMove(5, Constants.X);

            Assert.True(rules5x5.IsWon(board5x5.Spaces(), Constants.X));
            Assert.False(rules5x5.IsWon(board5x5.Spaces(), Constants.O));
        }
        
        [Test]
        public void IsAbleToReturnVerticalWinInA5x5Board()
        {
            var board5x5 = new Board(_writer, 5);
            var rules5x5 = new Rules(5);
            
            board5x5.MakeMove(1, Constants.X);
            board5x5.MakeMove(2, Constants.O);
            board5x5.MakeMove(6, Constants.X);
            board5x5.MakeMove(3, Constants.O);
            board5x5.MakeMove(11, Constants.X);
            board5x5.MakeMove(4, Constants.O);
            board5x5.MakeMove(16, Constants.X);
            board5x5.MakeMove(5, Constants.O);
            board5x5.MakeMove(21, Constants.X);

            Assert.True(rules5x5.IsWon(board5x5.Spaces(), Constants.X));
            Assert.False(rules5x5.IsWon(board5x5.Spaces(), Constants.O));
        }
        
        [Test]
        public void IsAbleToReturnLeftDiagonalWinInA5x5Board()
        {
            var board5x5 = new Board(_writer, 5);
            var rules5x5 = new Rules(5);
            
            board5x5.MakeMove(1, Constants.X);
            board5x5.MakeMove(2, Constants.O);
            board5x5.MakeMove(7, Constants.X);
            board5x5.MakeMove(3, Constants.O);
            board5x5.MakeMove(13, Constants.X);
            board5x5.MakeMove(4, Constants.O);
            board5x5.MakeMove(19, Constants.X);
            board5x5.MakeMove(5, Constants.O);
            board5x5.MakeMove(25, Constants.X);

            Assert.True(rules5x5.IsWon(board5x5.Spaces(), Constants.X));
            Assert.False(rules5x5.IsWon(board5x5.Spaces(), Constants.O));
        }
        
        [Test]
        public void IsAbleToReturnRightDiagonalWinInA5x5Board()
        {
            var board5x5 = new Board(_writer, 5);
            var rules5x5 = new Rules(5);
            
            board5x5.MakeMove(5, Constants.X);
            board5x5.MakeMove(2, Constants.O);
            board5x5.MakeMove(9, Constants.X);
            board5x5.MakeMove(3, Constants.O);
            board5x5.MakeMove(13, Constants.X);
            board5x5.MakeMove(4, Constants.O);
            board5x5.MakeMove(17, Constants.X);
            board5x5.MakeMove(1, Constants.O);
            board5x5.MakeMove(21, Constants.X);

            Assert.True(rules5x5.IsWon(board5x5.Spaces(), Constants.X));
            Assert.False(rules5x5.IsWon(board5x5.Spaces(), Constants.O));
        }
    }
}