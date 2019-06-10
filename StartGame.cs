namespace TicTacToe
{
    public class StartGame
    {
        private IConsoleWriter _writer;
        private Menu _menu;
        
        public StartGame()
        {
            _writer = new ConsoleWriter();
            _menu = new Menu(_writer);
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