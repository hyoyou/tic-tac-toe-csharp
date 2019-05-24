using System;

namespace TicTacToe
{
    
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }
        
        public void PrintBoard(char[] boardState)
        {
            Console.WriteLine(" {0} | {1} | {2} ", boardState[0], boardState[1], boardState[2]);
            Console.WriteLine(" ===+===+===");
            Console.WriteLine(" {3} | {4} | {5} ", boardState[3], boardState[4], boardState[5]);
            Console.WriteLine(" ===+===+===");
            Console.WriteLine(" {6} | {7} | {8} ", boardState[6], boardState[7], boardState[8]);
        }
    }
}