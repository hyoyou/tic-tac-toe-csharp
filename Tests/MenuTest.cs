using NUnit.Framework;
using TicTacToe;

namespace Tests
{
    [TestFixture]
    public class MenuTest
    {
        [Test]
        public void DisplaysWelcomeMessage()
        {
            MockConsoleWriter writer = new MockConsoleWriter();
            Menu menu = new Menu(writer);
            
            menu.Welcome();
            Assert.AreEqual("Welcome to Tic Tac Toe!", writer.LastOutput );
        }
    }
}