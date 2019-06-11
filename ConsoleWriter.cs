using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading;

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
            Console.WriteLine(Properties.Strings.Welcome);
        }

        public void LanguageOption()
        {
            Console.WriteLine(Properties.Strings.LanguageOptions);
        }

        public void SetLanguage(string langChoice)
        {
            if (!langChoice.Equals("es") | !langChoice.Equals("ko"))
            {
                langChoice = "en";
            }
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langChoice);
        }

        public void GridOption()
        {
            Console.WriteLine(Properties.Strings.GridOptions);
        }

        public void PrintBoard(List<object> boardList, int gridSize)
        {
            for (var i = 0; i < gridSize * gridSize; i += gridSize)
            {
                if (i == 0) Console.WriteLine(OutlineBuilder(gridSize));

                for (var j = i; j < i + gridSize; j++)
                {
                    if (j == i) Console.Write(Constants.CellSeparator);
                    Console.Write($" {boardList[j]} " + Constants.CellSeparator);
                }

                Console.WriteLine(OutlineBuilder(gridSize));
            }
        }

        private string OutlineBuilder(int gridSize)
        {
            var outline = Constants.Newline;
            for (var i = 0; i < gridSize - 1; i++)
            {
                outline += Constants.BoardOutline;
            }

            outline += Constants.BoardOutlineEnd;
            return outline;
        }

        public void AskForMove(char playerSymbol)
        {
            Console.WriteLine(playerSymbol == Constants.X
                ? Properties.Strings.AskForMoveX
                : Properties.Strings.AskForMoveO);
        }

        public void PromptUser()
        {
            Console.WriteLine(Properties.Strings.InvalidMove);
        }

        public void PrintCongratulations(char playerSymbol)
        {
            Console.WriteLine(playerSymbol == Constants.X
                ? Properties.Strings.CongratulateX
                : Properties.Strings.CongratulateO);
        }

        public void PrintTieGame()
        {
            Console.WriteLine(Properties.Strings.TieGame);
        }
    }
}