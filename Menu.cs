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
        private int langChoice;
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
            gridSize = AskForGridSize();
        }

        private int AskForGridSize()
        {
            _writer.GridOption();
            return int.Parse(_reader.GetInput());
        }

        public Game CreateGame()
        {
            var board = new Board(_writer, gridSize);
            var rules = new Rules(gridSize);
            return new Game(_writer, board, _player1, _player2, rules);
        }
    }
}