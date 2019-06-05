using System;

namespace TicTacToe
{
    public class ConsoleReader : IConsoleReader
    {
        public string GetInput()
        {
            var input = Console.ReadLine();
            return input;
        }
    }
}