using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        private static IConsoleWriter _writer;
        private static List<object> _boardList;

        public Board(IConsoleWriter IWriter)
        {
            _boardList = new List<object>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _writer = IWriter;
        }
        
        public void DisplayBoard()
        {
            _writer.PrintBoard(_boardList);
        }

        public void MakeMove(int cell, char playerSymbol)
        {
            _boardList[cell - 1] = playerSymbol;
        }

        public bool IsValidMove(int cell)
        {
            var validMoves = AvailableMoves();
            var playerMove = _boardList[cell - 1];
            return validMoves.Contains(playerMove);
        }

        public List<object> Spaces()
        {
            return _boardList;
        }
        
        public List<object> AvailableMoves()
        {
            var availableList = new List<object>();

            foreach (object cell in _boardList)
            {
                if (cell is int)
                {
                    availableList.Add(cell);
                }
            }

            return availableList;
        }

        public int TurnCount()
        {
            return 9 - AvailableMoves().Count;
        }
    }
}