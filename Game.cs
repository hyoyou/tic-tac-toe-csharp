using System;

namespace TicTacToe
{
    public class Game
    {
        private IConsoleWriter _writer;
        private Board _board;
        private HumanPlayer _player1;
        private HumanPlayer _player2;
        private Rules _rules;
        
        public Game(IConsoleWriter writer, Board board, HumanPlayer player1, HumanPlayer player2, Rules rules)
        {
            _writer = writer;
            _board = board;
            _player1 = player1;
            _player2 = player2;
            _rules = rules;
        }
        
        public HumanPlayer CurrentPlayer()
        {
            var turns = _board.TurnCount();
            return turns % 2 == 0 ? _player1 : _player2;
        }
        
        public void PlayerLoop()
        {
            var currentPlayer = CurrentPlayer();
            var userInput = currentPlayer.Move();
            var moveInt = ConvertToInt(userInput);
            TryMove(moveInt, currentPlayer);
        }

        private int ConvertToInt(string userInput)
        {
            int i;
            
            if (!int.TryParse(userInput, out i))
            {
                i = -1;
            }

            return i;
        }
        
        private void TryMove(int moveInt, HumanPlayer currentPlayer)
        {
            if (_board.IsValidMove(moveInt))
            {
                _board.MakeMove(moveInt, currentPlayer.Symbol());
            }
            else
            {
                _writer.PromptUser();
                _writer.PrintBoard(_board.Spaces());
                PlayerLoop();
            }
        }

        public void GameLoop()
        {
            while (!_rules.IsGameOver(_board))
            {
                _board.DisplayBoard();
                PlayerLoop();
            }

            PrintGameStatus();
        }

        private void PrintGameStatus()
        {
            if (_rules.IsWon(_board.Spaces(), 'X'))
            {
                _board.DisplayBoard();
                _writer.PrintCongratulations('X');
            }
            else if (_rules.IsWon(_board.Spaces(), 'O'))
            {
                _board.DisplayBoard();
                _writer.PrintCongratulations('O');
            }
            else
            {
                _board.DisplayBoard();
                _writer.PrintTieGame();
            }
        }
    }
}