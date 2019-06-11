using TicTacToe;

namespace Tests
{
    public class MockConsoleReader : IConsoleReader
    {
        public string LastInput;

        public MockConsoleReader()
        {
            LastInput = "1";
        }
        
        public string GetInput()
        {
            return LastInput;
        }

        public void SetInput(string s)
        {
            LastInput = s;
        }
    }
}