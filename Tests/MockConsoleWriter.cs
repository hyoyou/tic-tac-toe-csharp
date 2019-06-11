using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using TicTacToe;

namespace Tests
{
    public class MockConsoleWriter : IConsoleWriter
    {
        public string LastOutput;
        
        public MockConsoleWriter()
        {
            LastOutput = Constants.Empty;
        }

        public void Welcome()
        {
            LastOutput += TicTacToe.Properties.Strings.Welcome;
        }

        public void LanguageOption()
        {
            LastOutput += TicTacToe.Properties.Strings.LanguageOptions;
        }

        public void SetLanguage(string langChoice)
        {
            if (langChoice.Equals(Constants.Spanish) | langChoice.Equals(Constants.Korean))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(langChoice);
            }
        }

        public void GridOption()
        {
            LastOutput += TicTacToe.Properties.Strings.GridOptions;
        }

        public void PrintBoard(List<object> boardList, int gridSize)
        {
            for (var i = 0; i < gridSize * gridSize; i += gridSize)
            {
                if (i == 0) LastOutput += OutlineBuilder(gridSize);

                for (var j = i; j < i + gridSize; j++)
                {
                    if (j == i) LastOutput += Constants.CellSeparator;
                    LastOutput += $" {boardList[j]} " + Constants.CellSeparator;
                }

                LastOutput += OutlineBuilder(gridSize);
            }
        }

        private string OutlineBuilder(int gridSize)
        {
            var outline = Constants.Empty;
            for (var i = 0; i < gridSize - 1; i++)
            {
                outline += Constants.BoardOutline;
            }

            outline += Constants.BoardOutlineEnd;
            return outline;
        }

        public void AskForMove(char playerSymbol)
        {
            LastOutput = (playerSymbol == Constants.X
                ? TicTacToe.Properties.Strings.AskForMoveX
                : TicTacToe.Properties.Strings.AskForMoveO);
        }

        public void PromptUser()
        {
            LastOutput = TicTacToe.Properties.Strings.InvalidMove;
        }

        public void PrintCongratulations(char playerSymbol)
        {
            LastOutput = playerSymbol == Constants.X
                ? TicTacToe.Properties.Strings.CongratulateX
                : TicTacToe.Properties.Strings.CongratulateO;
        }

        public void PrintTieGame()
        {
            LastOutput = TicTacToe.Properties.Strings.TieGame;
        }
    }
}