namespace TicTacToe
{
    public interface IConsoleWriter
    {
        void WriteLine(string s);
        void PrintBoard(char[] board);
    }
}