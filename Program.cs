using System;

namespace TicTacToe
{
    class MainClass
    {
        public MainClass()
        {
        }
        public static void Main(string[] args)
        {
            IConsoleWriter writer = new ConsoleWriter();
            Menu menu = new Menu(writer);
            menu.Welcome();
        }
    }
}
