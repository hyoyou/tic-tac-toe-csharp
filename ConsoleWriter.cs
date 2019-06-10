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
            for (var i = 0; i < Constants.GridDimension * Constants.GridDimension; i += Constants.GridDimension)
            {
                if (i == 0) Console.WriteLine("----+---+----");
                
                for (var j = i; j < i + Constants.GridDimension; j++)
                {
                    if (j == i) Console.Write("|");
                    Console.Write($" {boardList[j]} |");
                }
                Console.WriteLine("\n----+---+----");
            }
        }

        public void AskForMove(char playerSymbol)
        {
            Console.WriteLine($"Player {playerSymbol}, please make your move:");
        }

        public void PromptUser()
        {
            Console.WriteLine("Invalid move, please enter a different move:");
        }

        public void PrintCongratulations(char playerSymbol)
        {
            Console.WriteLine($"Congratulations player {playerSymbol}, you won!!");
        }

        public void PrintTieGame()
        {
            Console.WriteLine("Cat's game!");
        }
    }
}