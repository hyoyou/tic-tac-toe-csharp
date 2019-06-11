namespace TicTacToe
{
    public class HumanPlayer
    {
        private char _symbol;
        private static IConsoleReader _reader;
        private static IConsoleWriter _writer;

        public HumanPlayer(char playerSymbol, IConsoleReader reader, IConsoleWriter writer)
        {
            _symbol = playerSymbol;
            _reader = reader;
            _writer = writer;
        }

        public char Symbol()
        {
            return _symbol;
        }

        public string Move()
        {
            _writer.AskForMove(_symbol);
            return _reader.GetInput();
        }
    }
}