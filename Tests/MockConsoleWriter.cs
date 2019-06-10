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
        
        public void PrintBoard(List<object> boardList)
        {
            for (var i = 0; i < Constants.GridDimension * Constants.GridDimension; i += Constants.GridDimension)
            {
                if (i == 0) LastOutput += $"----+---+----";

                for (var j = i; j < i + Constants.GridDimension; j++)
                {
                    if (j == i) LastOutput += "|";
                    LastOutput += $" {boardList[j]} |";
                }
                
                LastOutput += "----+---+----";
            }
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