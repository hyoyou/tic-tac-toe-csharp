using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Rules
    {
        private static int _gridSize;

        public Rules(int gridSize)
        {
            _gridSize = gridSize;
        }
        
        public bool IsWon(List<object> board, char playerSymbol)
        {
            if (IsHorizontalWin(board, playerSymbol)) return true;
            if (IsVerticalWin(board, playerSymbol)) return true;
            if (IsLeftDiagonalWin(board, playerSymbol)) return true;
            return IsRightDiagonalWin(board, playerSymbol);
        }

        private bool IsHorizontalWin(List<object> board, char playerSymbol)
        {
            for (var i = 0; i < _gridSize; i++)
            {
                var tempList = new List<object>();
                
                for (var j = 0; j < _gridSize; j++)
                {
                    tempList.Add(board[_gridSize * j + i]);
                }

                if (IsMatch(playerSymbol, tempList)) return true;
            }
            return false;
        }

        private bool IsVerticalWin(List<object> board, char playerSymbol)
        {
            for (var i = 0; i < _gridSize; i++)
            {
                var tempList = new List<object>();
                
                for (var j = 0; j < _gridSize; j++)
                {
                    tempList.Add(board[_gridSize * i + j]);
                }

                if (IsMatch(playerSymbol, tempList)) return true;
            }
            return false;
        }

        private bool IsLeftDiagonalWin(List<object> board, char playerSymbol)
        {
            var tempList = new List<object>();
            
            for (var i = 0; i < _gridSize; i++)
            {
                tempList.Add(board[(_gridSize + 1) * i]);
            }
            
            return IsMatch(playerSymbol, tempList);
        }
        
        private bool IsRightDiagonalWin(List<object> board, char playerSymbol)
        {
            var tempList = new List<object>();
            
            for (var i = 0; i < _gridSize; i++)
            {
                tempList.Add(board[(_gridSize - 1) * (i + 1)]);
            }
            
            return IsMatch(playerSymbol, tempList);
        }
        
        private static bool IsMatch(char playerSymbol, List<object> tempList)
        {
            return tempList.All(o => Equals(playerSymbol, o));
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