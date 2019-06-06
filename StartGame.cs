namespace TicTacToe
{
    public class StartGame
    {
        private IConsoleWriter _writer;
        private IConsoleReader _reader;
        private Menu _menu;
        private Board _board;
        private HumanPlayer _player1;
        private HumanPlayer _player2;
        private Rules _rules;
        private Game _game;
        
        public StartGame()
        {
            _writer = new ConsoleWriter();
            _reader = new ConsoleReader();
            _menu = new Menu(_writer); 
            _board = new Board(_writer);
            _player1 = new HumanPlayer('X', _reader, _writer);
            _player2 = new HumanPlayer('O', _reader, _writer);
            _rules = new Rules();
            _game = new Game(_writer, _board, _player1, _player2, _rules);

        }
        
        public void Run()
        {
            _menu.Welcome();
            _game.GameLoop();
        }
    }
}