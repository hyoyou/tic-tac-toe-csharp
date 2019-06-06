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
            while (!_board.IsValidMove(moveInt))
            {
                _writer.PromptUser();
                _writer.PrintBoard(_board.Spaces());
                PlayerLoop();
            }
            _board.MakeMove(moveInt, currentPlayer.Symbol());
        }

        private int ConvertToInt(string userInput)
        {
            return int.Parse(userInput);
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