using GameOfLife.Utils;

namespace GameOfLife
{
    /// <summary>
    /// Implementation for games that use Board interface.
    /// </summary>
    public class BoardGame : Game<IBoard>
    {
        /// <summary>
        /// Board of the game.
        /// </summary>
        private IBoard _gameBoard { get; set; }

        /// <summary>
        /// Constructor for the game.
        /// </summary>
        public BoardGame(IBoard gameBoard) => _gameBoard = gameBoard;

        /// <inheritdoc/>
        public override void Play()
        {
            while (State == GameState.Playing)
            {
                Action keyActions = () =>
                {
                    switch (Panel.GetKeyInput())
                    {
                        case ConsoleKey.Spacebar:
                            Pause(); 
                            Console.Clear();
                            break;

                        case ConsoleKey.Enter:
                            Start(); 
                            Console.Clear();
                            break;

                        case ConsoleKey.Escape:
                            Stop(); 
                            Console.Clear();
                            break;

                        case ConsoleKey.S:
                            Retain(_gameBoard); 
                            Stop(); 
                            Console.Clear();
                            break;
                    }
                 };

                Task keyTask = new Task(keyActions);

                keyTask.Start();

                _gameBoard.Flow();

                if (State == GameState.Paused)
                {
                    Panel.DisplayMessage(Labels.PauseOpts);
                }
            }
        }
    }
}
