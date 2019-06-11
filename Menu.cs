namespace TicTacToe
{
    public class Menu
    {
        private static IConsoleWriter _writer;
        private IConsoleReader _reader;
        private HumanPlayer _player1;
        private HumanPlayer _player2;
        private string langChoice;
        private int gridSize;

        public Menu(IConsoleWriter writer, IConsoleReader reader)
        {
            _writer = writer;
            _reader = reader;
            _player1 = new HumanPlayer(Constants.X, _reader, _writer);
            _player2 = new HumanPlayer(Constants.O, _reader, _writer);
        }
        
        public void Welcome()
        {
            _writer.Welcome();
        }

        public void DisplayOptions()
        {
            LanguagePreferenceMenu();
            langChoice = GetLanguagePreference();
            _writer.SetLanguage(langChoice);
            GridSizePreferenceMenu();
            gridSize = GetGridSizePreference();
        }

        public void LanguagePreferenceMenu()
        {
            _writer.LanguageOption();
        }
        
        private string GetLanguagePreference()
        {
            return _reader.GetInput();
        }

        public void GridSizePreferenceMenu()
        {
            _writer.GridOption();
        }
        
        
        private int GetGridSizePreference()
        {
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