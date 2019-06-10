using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        private static IConsoleWriter _writer;
        private static List<object> _boardList;

        public Board(IConsoleWriter writer)
        {
            _boardList = CreateGridList(Constants.GridDimension * Constants.GridDimension);
            _writer = writer;
        }

        private static List<object> CreateGridList(int count)
        {
            var gridList = new List<object>(count);
            gridList.AddRange(Enumerable.Repeat(Constants.Empty, count));
            return gridList;
        }
        
        public void DisplayBoard()
        {
            var populatedBoard = PopulateBoard(_boardList);
            _writer.PrintBoard(populatedBoard);
        }

        private List<object> PopulateBoard(List<object> boardList)
        {
            var boardListWithCell = new List<object>();
            boardListWithCell.AddRange(Enumerable.Repeat(Constants.Empty, Constants.GridDimension * Constants.GridDimension));

            for (var i = 0; i < boardList.Count; i++)
            {
                if (boardList[i].Equals(" "))
                {
                    boardListWithCell[i] = i + 1;
                }
                else
                {
                    boardListWithCell[i] = boardList[i];
                }
            }

            return boardListWithCell;
        }

        public void MakeMove(int cell, char playerSymbol)
        {
            _boardList[cell - 1] = playerSymbol;
        }

        public bool IsValidMove(int cell)
        {
            if (Enumerable.Range(1, Constants.GridDimension * Constants.GridDimension).Contains(cell))
            {
                var validMoves = AvailableMoves();
                var playerMove = Spaces()[cell - 1];
                return validMoves.Contains(playerMove);
            }

            return false;
        }

        public List<object> Spaces()
        {
            return PopulateBoard(_boardList);
        }
        
        public List<object> AvailableMoves()
        {
            var availableList = new List<object>();

            for (var i = 0; i < _boardList.Count; i++)
            {
                if (_boardList[i].Equals(Constants.Empty))
                {
                    availableList.Add(i + 1);
                }
            }

            return availableList;
        }

        public int TurnCount()
        {
            return Constants.GridDimension * Constants.GridDimension - AvailableMoves().Count;
        }
    }
}