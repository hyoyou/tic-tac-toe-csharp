using NUnit.Framework;
using TicTacToe;

namespace Tests
{
    [TestFixture]
    public class HumanPlayerTest
    {
        private MockConsoleReader _reader;
        private MockConsoleWriter _writer;
        private HumanPlayer _player1;
        private HumanPlayer _player2;

        [SetUp]
        public void Setup()
        {
            _reader = new MockConsoleReader();
            _writer = new MockConsoleWriter();
            _player1 = new HumanPlayer('X', _reader, _writer);
            _player2 = new HumanPlayer('O', _reader, _writer);
        }
        
        [Test]
        public void Player1IsInitializedWithSymbolX()
        {
            Assert.AreEqual('X', _player1.Symbol());
        }
        
        [Test]
        public void Player2IsInitializedWithSymbolO()
        {
            Assert.AreEqual('O', _player2.Symbol());
        }

        [Test]
        public void GameAsksCorrectPlayerXToInputTheirMove()
        {
            _player1.Move();
            Assert.AreEqual("Player X, please make your move:", _writer.LastOutput);
        }
        
        [Test]
        public void GameAsksCorrectPlayerOToInputTheirMove()
        {
            _player2.Move();
            Assert.AreEqual("Player O, please make your move:", _writer.LastOutput);
        }
        
        [Test]
        public void PlayerCanInputTheirMove()
        {
            _reader.SetInput("2");
            _player1.Move();
            Assert.AreEqual("2", _reader.GetInput());
        }
    }
}