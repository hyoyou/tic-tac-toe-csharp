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
            return IsRightDiagonalWin(board, playerSymbol);
        }

        private bool IsHorizontalWin(List<object> board, char playerSymbol)
        {
            for (var i = 0; i < Constants.GridDimension; i++)
            {
                var tempList = new List<object>();
                
                for (var j = 0; j < Constants.GridDimension; j++)
                {
                    tempList.Add(board[Constants.GridDimension * j + i]);
                }

                if (IsMatch(playerSymbol, tempList)) return true;
            }
            return false;
        }

        private bool IsVerticalWin(List<object> board, char playerSymbol)
        {
            for (var i = 0; i < Constants.GridDimension; i++)
            {
                var tempList = new List<object>();
                
                for (var j = 0; j < Constants.GridDimension; j++)
                {
                    tempList.Add(board[Constants.GridDimension * i + j]);
                }

                if (IsMatch(playerSymbol, tempList)) return true;
            }
            return false;
        }

        private bool IsLeftDiagonalWin(List<object> board, char playerSymbol)
        {
            var tempList = new List<object> { board[0], board[4], board[8] };
            return IsMatch(playerSymbol, tempList);
        }
        
        private bool IsRightDiagonalWin(List<object> board, char playerSymbol)
        {
            var tempList = new List<object> { board[2], board[4], board[6] };
            return IsMatch(playerSymbol, tempList);
        }
        
        private static bool IsMatch(char playerSymbol, List<object> tempList)
        {
            return tempList[0].Equals(playerSymbol) && tempList[1].Equals(playerSymbol) &&
                   tempList[2].Equals(playerSymbol);
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