using System.Collections.Generic;
namespace TicTacToe
{
    public interface IConsoleWriter
    {
        void WriteLine(string s);
        void Welcome();
        void LanguageOption();
        void SetLanguage(string langChoice);
        void GridOption();
        void PrintBoard(List<object> boardList, int boardSize);
        void AskForMove(char playerSymbol);
        void PromptUser();
        void PrintCongratulations(char symbol);
        void PrintTieGame();
    }
}