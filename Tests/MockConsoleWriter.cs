using System.Collections.Generic;
using TicTacToe;

namespace Tests
{
    public class MockConsoleWriter : IConsoleWriter
    {
        public string LastOutput;
        
        public MockConsoleWriter()
        {
            LastOutput = "";
        }

        public void WriteLine(string s)
        {
            LastOutput += s;
        }

        public void Welcome()
        {
            LastOutput += "Welcome to Tic Tac Toe!";
        }

        public void GridOption()
        {
            LastOutput += "Grid Size Menu: Please type '3' for 3 x 3, '4' for 4 x 4, '5' for 5 x 5";
        }

        public void PrintBoard(List<object> boardList, int gridSize)
        {
            for (var i = 0; i < gridSize * gridSize; i += gridSize)
            {
                if (i == 0) LastOutput += OutlineBuilder(gridSize);

                for (var j = i; j < i + gridSize; j++)
                {
                    if (j == i) LastOutput += "|";
                    LastOutput += $" {boardList[j]} |";
                }

                LastOutput += OutlineBuilder(gridSize);
            }
        }

        private string OutlineBuilder(int gridSize)
        {
            var outline = "";
            for (var i = 0; i < gridSize - 1; i++)
            {
                outline += Constants.BoardOutline;
            }

            outline += Constants.BoardOutlineEnd;
            return outline;
        }

        public void AskForMove(char playerSymbol)
        {
            LastOutput = $"Player {playerSymbol}, please make your move:";
        }

        public void PromptUser()
        {
            LastOutput = "Invalid move, please enter a different move:";
        }

        public void PrintCongratulations(char playerSymbol)
        {
            LastOutput = $"Congratulations player {playerSymbol}, you won!!";
        }

        public void PrintTieGame()
        {
            LastOutput = "Cat's game!";
        }
    }
}