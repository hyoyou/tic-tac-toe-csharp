using System.Collections.Generic;

namespace TicTacToe
{
    public class Rules
    {
        public bool IsWon(List<object> board, char playerSymbol)
        {
            if (IsHorizontalWin(board, playerSymbol)) return true;
            if (IsVerticalWin(board, playerSymbol)) return true;
            if (IsLeftDiagonalWin(board, playerSymbol)) return true;
            if (IsRightDiagonalWin(board, playerSymbol)) return true;
            return false;
        }

        private bool IsHorizontalWin(List<object> board, char playerSymbol)
        {
            for (var i = 0; i < 3; i++)
            {
                var tempArr = new List<object>();
                
                for (var j = 0; j < 3; j++)
                {
                    tempArr.Add(board[3*j+i]);
                }

                if (tempArr[0].Equals(playerSymbol) && tempArr[1].Equals(playerSymbol) &&
                    tempArr[2].Equals(playerSymbol)) return true;
            }
            return false;
        }
        
        private bool IsVerticalWin(List<object> board, char playerSymbol)
        {
            for (var i = 0; i < 3; i++)
            {
                var tempArr = new List<object>();
                
                for (var j = 0; j < 3; j++)
                {
                    tempArr.Add(board[3*i+j]);
                }

                if (tempArr[0].Equals(playerSymbol) && tempArr[1].Equals(playerSymbol) &&
                    tempArr[2].Equals(playerSymbol)) return true;
            }
            return false;
        }
        
        private bool IsLeftDiagonalWin(List<object> board, char playerSymbol)
        {
            return board[0].Equals(playerSymbol) && board[4].Equals(playerSymbol) && board[8].Equals(playerSymbol);
        }
        
        private bool IsRightDiagonalWin(List<object> board, char playerSymbol)
        {
            return board[2].Equals(playerSymbol) && board[4].Equals(playerSymbol) && board[6].Equals(playerSymbol);
        }
        
        public bool IsTie(Board board) 
        {
            return board.AvailableMoves().Count == 0; 
        }

        public bool IsGameOver(Board board)
        {
            return IsWon(board.Spaces(), Constants.X) | IsWon(board.Spaces(), Constants.O) | IsTie(board);
        }
    }
}