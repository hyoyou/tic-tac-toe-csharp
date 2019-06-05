using System.Collections.Generic;

namespace TicTacToe
{
    public interface IConsoleWriter
    {
        void WriteLine(string s);
        void PrintBoard(List<object> boardList);
    }
}