using System.Collections.Generic;

namespace TicTacToe
{
    public class Rules
    {
        public static bool? IsWon(List<object> board, char playerSymbol)
        {
            if (board[0].Equals(playerSymbol) && board[1].Equals(playerSymbol) && board[2].Equals(playerSymbol)) { return true; }
            if (board[3].Equals(playerSymbol) && board[4].Equals(playerSymbol) && board[5].Equals(playerSymbol)) { return true; }
            if (board[6].Equals(playerSymbol) && board[7].Equals(playerSymbol) && board[8].Equals(playerSymbol)) { return true; }

            if (board[0].Equals(playerSymbol) && board[3].Equals(playerSymbol) && board[6].Equals(playerSymbol)) { return true; }
            if (board[1].Equals(playerSymbol) && board[4].Equals(playerSymbol) && board[7].Equals(playerSymbol)) { return true; }
            if (board[2].Equals(playerSymbol) && board[5].Equals(playerSymbol) && board[8].Equals(playerSymbol)) { return true; }

            if (board[0].Equals(playerSymbol) && board[4].Equals(playerSymbol) && board[8].Equals(playerSymbol)) { return true; }
            if (board[2].Equals(playerSymbol) && board[4].Equals(playerSymbol) && board[6].Equals(playerSymbol)) { return true; }

            return false;
        }
        
        public static bool? IsTie(Board board) 
        {
            return board.AvailableMoves().Count == 0; 
        }

        public static bool? IsGameOver(Board board)
        {
            return IsWon(board.Spaces(), 'X') | IsWon(board.Spaces(), 'O') | IsTie(board);
        }
    }
}