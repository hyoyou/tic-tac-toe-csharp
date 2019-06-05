using System;
using System.Collections.Generic;

namespace TicTacToe
{
    
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }
        
        public void PrintBoard(List<object> boardList)
        {
            Console.WriteLine(" {0} | {1} | {2} ", boardList[0], boardList[1], boardList[2]);
            Console.WriteLine(" ===+===+===");
            Console.WriteLine(" {3} | {4} | {5} ", boardList[3], boardList[4], boardList[5]);
            Console.WriteLine(" ===+===+===");
            Console.WriteLine(" {6} | {7} | {8} ", boardList[6], boardList[7], boardList[8]);
        }

        public void AskForMove(char playerSymbol)
        {
            Console.WriteLine($"Player {playerSymbol}, please make your move:");
        }
    }
}