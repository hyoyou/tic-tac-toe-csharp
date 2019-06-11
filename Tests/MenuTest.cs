using NUnit.Framework;
using TicTacToe;

namespace Tests
{
    [TestFixture]
    public class MenuTest
    {
        private Menu _menu;
        private MockConsoleWriter _writer;

        [SetUp]
        public void Setup()
        {
            _writer = new MockConsoleWriter();
            _menu = new Menu(_writer);
        }
        
        [Test]
        public void DisplaysWelcomeMessage()
        {
            _menu.Welcome();
            
            Assert.AreEqual("Welcome to Tic Tac Toe!", _writer.LastOutput );
        }
    }
}