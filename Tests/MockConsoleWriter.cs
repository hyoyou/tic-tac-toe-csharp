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
            LastOutput += $" {boardList[0]} | {boardList[1]} | {boardList[2]} ";
            LastOutput += " ===+===+=== ";
            LastOutput += $" {boardList[3]} | {boardList[4]} | {boardList[5]} ";
            LastOutput += " ===+===+=== ";
            LastOutput += $" {boardList[6]} | {boardList[7]} | {boardList[8]} ";
        }

        public void AskForMove(char playerSymbol)
        {
            LastOutput = $"Player {playerSymbol}, please make your move:";
        }
    }
}