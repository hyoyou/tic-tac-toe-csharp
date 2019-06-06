using System.Collections.Generic;
using NUnit.Framework;
using TicTacToe;

namespace Tests
{
    [TestFixture]
    public class GameTest
    {
        private MockConsoleReader _reader;
        private MockConsoleWriter _writer;
        private Board _board;
        private HumanPlayer _player1;
        private HumanPlayer _player2;
        private Rules _rules;
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _reader = new MockConsoleReader();
            _writer = new MockConsoleWriter();
            _board = new Board(_writer);
            _player1 = new HumanPlayer('X', _reader, _writer);
            _player2 = new HumanPlayer('O', _reader, _writer);
            _rules = new Rules();
            _game = new Game(_writer, _board, _player1, _player2, _rules);
        }
        
        [Test]
        public void CurrentPlayerReturnsPlayer1AtGameStart()
        {
            Assert.AreEqual(_player1, _game.CurrentPlayer());
        }
        
        [Test]
        public void CurrentPlayerReturnsPlayer2After1Move()
        {
            _board.MakeMove(1, _player1.Symbol());
            
            Assert.AreEqual(_player2, _game.CurrentPlayer());
        }
        
        [Test]
        public void CurrentPlayerReturnsPlayer1After6Moves()
        {
            _board.MakeMove(1, _player1.Symbol());
            _board.MakeMove(2, _player2.Symbol());
            _board.MakeMove(3, _player1.Symbol());
            _board.MakeMove(4, _player2.Symbol());
            _board.MakeMove(5, _player1.Symbol());
            _board.MakeMove(6, _player2.Symbol());
            
            Assert.AreEqual(_player1, _game.CurrentPlayer());
        }
        
        [Test]
        public void InvokesPlayerLoopThatMakesPlayersMoveOnBoard()
        {
            _game.PlayerLoop();
            
            List<object> expected = new List<object>{ 'X', 2, 3, 4, 5, 6, 7, 8, 9 };
            
            Assert.AreEqual("Player X, please make your move:", _writer.LastOutput);
            Assert.AreEqual("1", _reader.LastInput);
            Assert.AreEqual(expected, _board.Spaces());
        }
        
        [Test]
        public void InvokesGameLoopUntilGameOverWhenPlayerXWins()
        {
            _board.MakeMove(1, 'X');
            _board.MakeMove(2, 'O');
            _board.MakeMove(5, 'X');
            _board.MakeMove(4, 'O');
            _board.MakeMove(9, 'X');
            Game playerXWinGame = new Game(_writer, _board, _player1, _player2, _rules);
            
            playerXWinGame.GameLoop();
            
            Assert.AreEqual("Congratulations player X, you won!!", _writer.LastOutput);
            Assert.True(_rules.IsWon(_board.Spaces(), 'X'));
            Assert.False(_rules.IsWon(_board.Spaces(), 'O'));
            Assert.True(_rules.IsGameOver(_board));
        }
        
        [Test]
        public void InvokesGameLoopUntilGameOverWhenPlayerOWins()
        {
            _board.MakeMove(1, 'X');
            _board.MakeMove(2, 'O');
            _board.MakeMove(3, 'X');
            _board.MakeMove(5, 'O');
            _board.MakeMove(4, 'X');
            _board.MakeMove(8, 'O');
            Game playerOWinGame = new Game(_writer, _board, _player1, _player2, _rules);
            
            playerOWinGame.GameLoop();
            
            Assert.AreEqual("Congratulations player O, you won!!", _writer.LastOutput);
            Assert.True(_rules.IsWon(_board.Spaces(), 'O'));
            Assert.False(_rules.IsWon(_board.Spaces(), 'X'));
            Assert.True(_rules.IsGameOver(_board));
        }
        
        [Test]
        public void InvokesGameLoopUntilGameOverWhenTieGame()
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
            Game tieGame = new Game(_writer, _board, _player1, _player2, _rules);
            
            tieGame.GameLoop();
            
            Assert.AreEqual("Cat's game!", _writer.LastOutput);
            Assert.False(_rules.IsWon(_board.Spaces(), 'X'));
            Assert.False(_rules.IsWon(_board.Spaces(), 'O'));
            Assert.True(_rules.IsTie(_board));
            Assert.True(_rules.IsGameOver(_board));
        }
    }
}