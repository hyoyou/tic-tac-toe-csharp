namespace TicTacToe
{
    public class Board
    {
        private static IConsoleWriter _writer;
        static char[] boardArr = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public Board(IConsoleWriter IWriter)
        {
            _writer = IWriter;
        }
        
        public void DisplayBoard()
        {
            _writer.PrintBoard(boardArr);
        }
    }
}