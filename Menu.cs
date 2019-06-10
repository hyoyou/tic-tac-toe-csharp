namespace TicTacToe
{
    public class Menu
    {
        private static IConsoleWriter _writer;
        private IConsoleReader _reader;
        private Board _board;
        private HumanPlayer _player1;
        private HumanPlayer _player2;
        private Rules _rules;
        private Game _game;
        private int gridSize;

        public Menu(IConsoleWriter writer)
        {
            _writer = writer;
            _reader = new ConsoleReader();
            _player1 = new HumanPlayer(Constants.X, _reader, _writer);
            _player2 = new HumanPlayer(Constants.O, _reader, _writer);
        }
        
        public void Welcome()
        {
            _writer.Welcome();
        }

        public void DisplayOptions()
        {
            throw new System.NotImplementedException();
        }

        public Game CreateGame()
        {
            throw new System.NotImplementedException();
        }
    }
}