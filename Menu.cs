namespace TicTacToe
{
    public class Menu
    {
        private static IConsoleWriter _writer;

        public Menu(IConsoleWriter IWriter)
        {
            _writer = IWriter;
        }
        
        public void Welcome()
        {
            _writer.WriteLine("Welcome to Tic Tac Toe!");
        }
    }
}