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

        public void Welcome()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
        }

        public void GridOption()
        {
            Console.WriteLine("Grid Size Menu: Please type '3' for 3 x 3, '4' for 4 x 4, '5' for 5 x 5");
        }

        public void PrintBoard(List<object> boardList, int gridSize)
        {
            for (var i = 0; i < gridSize * gridSize; i += gridSize)
            {
                if (i == 0) Console.WriteLine(OutlineBuilder(gridSize));

                for (var j = i; j < i + gridSize; j++)
                {
                    if (j == i) Console.Write("|");
                    Console.Write($" {boardList[j]} |");
                }

                Console.WriteLine(OutlineBuilder(gridSize));
            }
        }

        private string OutlineBuilder(int gridSize)
        {
            var outline = "\n";
            for (var i = 0; i < gridSize - 1; i++)
            {
                outline += Constants.BoardOutline;
            }

            outline += Constants.BoardOutlineEnd;
            return outline;
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