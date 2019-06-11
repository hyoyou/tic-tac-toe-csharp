using NUnit.Framework;
using TicTacToe;

namespace Tests
{
    [TestFixture]
    public class MenuTest
    {
        private Menu _menu;
        private MockConsoleWriter _writer;
        private MockConsoleReader _reader;

        [SetUp]
        public void Setup()
        {
            _writer = new MockConsoleWriter();
            _reader = new MockConsoleReader();
            _menu = new Menu(_writer, _reader);
        }
        
        [Test]
        public void DisplaysWelcomeMessage()
        {
            _menu.Welcome();
            
            Assert.AreEqual("Welcome to Tic Tac Toe!", _writer.LastOutput );
        }
        
        [Test]
        public void DisplaysLanguageOptions()
        {
            _menu.LanguagePreferenceMenu();
            
            Assert.AreEqual("Language Menu: Please type any key for English, 'es' for Spanish, and 'ko' for Korean", _writer.LastOutput );
        }
        
        [Test]
        public void DisplaysGridSizeOptions()
        {
            _menu.GridSizePreferenceMenu();
            
            Assert.AreEqual("Grid Size Menu: Please type '3' for 3 x 3, '4' for 4 x 4, '5' for 5 x 5", _writer.LastOutput );
        }
        
        [Test]
        public void DisplaysGridSizeOptionsInSpanish()
        {
            _writer.SetLanguage(Constants.Spanish);
            _menu.GridSizePreferenceMenu();
            
            Assert.AreEqual("Menú de tamaño de cuadrícula: escriba '3' para 3 x 3, '4' para 4 x 4, '5' para 5 x 5", _writer.LastOutput );
        }
        
        [Test]
        public void DisplaysGridSizeOptionsInKorean()
        {
            _writer.SetLanguage(Constants.Korean);
            _menu.GridSizePreferenceMenu();
            
            Assert.AreEqual("틱택토 보드 크기 메뉴 : 3 x 3 보드를 선택하시려면 '3'을 입력하세요, 4 x 4 보드를 선택하시려면 '4'를 입력하세요, 5 x 5 보드를 선택하시려면 '5'를 입력하세요", _writer.LastOutput );
        }
    }
}