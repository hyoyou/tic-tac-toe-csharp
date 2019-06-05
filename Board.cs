using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        private static IConsoleWriter _writer;
        private static List<object> BoardList;

        public Board(IConsoleWriter IWriter)
        {
            BoardList = new List<object>(){ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            _writer = IWriter;
        }
        
        public void DisplayBoard()
        {
            _writer.PrintBoard(BoardList);
        }

        public List<object> MakeMove(int cell, char playerSymbol)
        {
            BoardList[cell - 1] = playerSymbol;
            return BoardList;
        }
        
        public List<object> Spaces()
        {
            return BoardList;
        }
        
        public object Space(int cell)
        {
            return BoardList[cell - 1];
        }

        public List<object> AvailableMoves()
        {
            List<object> AvailableList = new List<object>();

            foreach (object cell in BoardList)
            {
                if (cell is int)
                {
                    AvailableList.Add(cell);
                }
            }

            return AvailableList;
        }

        public int TurnCount()
        {
            return 9 - AvailableMoves().Count;
        }
    }
}