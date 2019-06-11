namespace TicTacToe
{
    public class StartGame
    {
        private IConsoleWriter _writer;
        private IConsoleReader _reader;
        private Menu _menu;
        
        public StartGame()
        {
            _writer = new ConsoleWriter();
            _reader = new ConsoleReader();
            _menu = new Menu(_writer, _reader);
        }
        
        public void Run()
        {
            _menu.Welcome();
            _menu.DisplayOptions();
            var game = _menu.CreateGame();
            game.GameLoop();
        }
    }
}