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
            _board = new Board(_writer, 3);
            _player1 = new HumanPlayer(Constants.X, _reader, _writer);
            _player2 = new HumanPlayer(Constants.O, _reader, _writer);
            _rules = new Rules(3);
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
            
            var expected = new List<object>{ Constants.X, 2, 3, 4, 5, 6, 7, 8, 9 };
            
            Assert.AreEqual("Player X, please make your move:", _writer.LastOutput);
            Assert.AreEqual("1", _reader.LastInput);
            Assert.AreEqual(expected, _board.Spaces());
        }
        
        [Test]
        public void PlayerLoopAsksForPlayersMoveInSpanish()
        {
            _writer.SetLanguage(Constants.Spanish);
            _game.PlayerLoop();

            Assert.AreEqual("Jugador X, por favor haz tu movimiento:", _writer.LastOutput);
        }

        [Test]
        public void PlayerLoopAsksForPlayersMoveInKorean()
        {
            _writer.SetLanguage(Constants.Korean);
            _game.PlayerLoop();

            Assert.AreEqual("플레이어 X, 원하시는 칸을 선택해주세요:", _writer.LastOutput);
        }
        
        [Test]
        public void InvokesGameLoopUntilGameOverWhenPlayerXWins()
        {
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(4, Constants.O);
            _board.MakeMove(9, Constants.X);
            var playerXWinGame = new Game(_writer, _board, _player1, _player2, _rules);
            
            playerXWinGame.GameLoop();
            
            Assert.AreEqual("Congratulations Player X, you won!!", _writer.LastOutput);
            Assert.True(_rules.IsWon(_board.Spaces(), Constants.X));
            Assert.False(_rules.IsWon(_board.Spaces(), Constants.O));
            Assert.True(_rules.IsGameOver(_board));
        }
        
        [Test]
        public void CongratulatesPlayerXWinInSpanish()
        {
            _writer.SetLanguage(Constants.Spanish);
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(4, Constants.O);
            _board.MakeMove(9, Constants.X);
            var playerXWinGame = new Game(_writer, _board, _player1, _player2, _rules);
            
            playerXWinGame.GameLoop();

            Assert.AreEqual("¡Felicidades Jugador X, ganaste!", _writer.LastOutput);
        }

        [Test]
        public void CongratulatesPlayerXWinInKorean()
        {
            _writer.SetLanguage(Constants.Korean);
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(4, Constants.O);
            _board.MakeMove(9, Constants.X);
            var playerXWinGame = new Game(_writer, _board, _player1, _player2, _rules);
            
            playerXWinGame.GameLoop();

            Assert.AreEqual("축하합니다 플레이어 X, 당신이 이겼습니다!", _writer.LastOutput);
        }
        
        [Test]
        public void InvokesGameLoopUntilGameOverWhenPlayerOWins()
        {
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(3, Constants.X);
            _board.MakeMove(5, Constants.O);
            _board.MakeMove(4, Constants.X);
            _board.MakeMove(8, Constants.O);
            var playerOWinGame = new Game(_writer, _board, _player1, _player2, _rules);
            
            playerOWinGame.GameLoop();
            
            Assert.AreEqual("Congratulations Player O, you won!!", _writer.LastOutput);
            Assert.True(_rules.IsWon(_board.Spaces(), Constants.O));
            Assert.False(_rules.IsWon(_board.Spaces(), Constants.X));
            Assert.True(_rules.IsGameOver(_board));
        }
        
        [Test]
        public void CongratulatesPlayerOWinInSpanish()
        {
            _writer.SetLanguage(Constants.Spanish);
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(3, Constants.X);
            _board.MakeMove(5, Constants.O);
            _board.MakeMove(4, Constants.X);
            _board.MakeMove(8, Constants.O);
            var playerXWinGame = new Game(_writer, _board, _player1, _player2, _rules);
            
            playerXWinGame.GameLoop();

            Assert.AreEqual("¡Felicidades Jugador O, ganaste!", _writer.LastOutput);
        }

        [Test]
        public void CongratulatesPlayerOWinInKorean()
        {
            _writer.SetLanguage(Constants.Korean);
            _board.MakeMove(1, Constants.X);
            _board.MakeMove(2, Constants.O);
            _board.MakeMove(3, Constants.X);
            _board.MakeMove(5, Constants.O);
            _board.MakeMove(4, Constants.X);
            _board.MakeMove(8, Constants.O);
            var playerXWinGame = new Game(_writer, _board, _player1, _player2, _rules);
            
            playerXWinGame.GameLoop();

            Assert.AreEqual("축하합니다 플레이어 O, 당신이 이겼습니다!", _writer.LastOutput);
        }
        
        [Test]
        public void InvokesGameLoopUntilGameOverWhenTieGame()
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
            var tieGame = new Game(_writer, _board, _player1, _player2, _rules);
            
            tieGame.GameLoop();
            
            Assert.AreEqual("Cat's game!", _writer.LastOutput);
            Assert.False(_rules.IsWon(_board.Spaces(), Constants.X));
            Assert.False(_rules.IsWon(_board.Spaces(), Constants.O));
            Assert.True(_rules.IsTie(_board));
            Assert.True(_rules.IsGameOver(_board));
        }
        
        [Test]
        public void DisplaysTieGameMessageInSpanish()
        {
            _writer.SetLanguage(Constants.Spanish);
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(1, Constants.O);
            _board.MakeMove(3, Constants.X);
            _board.MakeMove(7, Constants.O);
            _board.MakeMove(4, Constants.X);
            _board.MakeMove(8, Constants.O);
            _board.MakeMove(9, Constants.X);
            _board.MakeMove(6, Constants.O);
            _board.MakeMove(2, Constants.X);
            var tieGame = new Game(_writer, _board, _player1, _player2, _rules);
            
            tieGame.GameLoop();

            Assert.AreEqual("El juego es un empate.", _writer.LastOutput);
        }

        [Test]
        public void DisplaysTieGameMessageInKorean()
        {
            _writer.SetLanguage(Constants.Korean);
            _board.MakeMove(5, Constants.X);
            _board.MakeMove(1, Constants.O);
            _board.MakeMove(3, Constants.X);
            _board.MakeMove(7, Constants.O);
            _board.MakeMove(4, Constants.X);
            _board.MakeMove(8, Constants.O);
            _board.MakeMove(9, Constants.X);
            _board.MakeMove(6, Constants.O);
            _board.MakeMove(2, Constants.X);
            var tieGame = new Game(_writer, _board, _player1, _player2, _rules);
            
            tieGame.GameLoop();

            Assert.AreEqual("동점 게임입니다.", _writer.LastOutput);
        }
    }
}