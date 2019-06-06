namespace TicTacToe
{
    public class Menu
    {
        private static IConsoleWriter _writer;

        public Menu(IConsoleWriter writer)
        {
            _writer = writer;
        }
        
        public void Welcome()
        {
            _writer.WriteLine("Welcome to Tic Tac Toe!");
        }
    }
}