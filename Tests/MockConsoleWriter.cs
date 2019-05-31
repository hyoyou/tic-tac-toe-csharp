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
        
        public void PrintBoard(char[] boardState)
        {
            LastOutput += $" {boardState[0]} | {boardState[1]} | {boardState[2]} ";
            LastOutput += " ===+===+=== ";
            LastOutput += $" {boardState[3]} | {boardState[4]} | {boardState[5]} ";
            LastOutput += " ===+===+=== ";
            LastOutput += $" {boardState[6]} | {boardState[7]} | {boardState[8]} ";
        }
    }
}