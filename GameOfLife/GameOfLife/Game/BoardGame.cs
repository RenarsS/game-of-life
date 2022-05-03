
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
                Action keyActions = () => Panel.DisplayKeyMenu(
                    spacebar: () => { Pause(); Console.Clear(); },
                    enter: () => { Start(); Console.Clear(); },
                    escape: () => { Stop(); Console.Clear(); },
                    s: () => { Retain(_gameBoard); Stop(); Console.Clear(); }
                    );

                Task keyTask = new Task(keyActions);

                keyTask.Start();

                _gameBoard.Flow();

                if (State == GameState.Paused)
                {
                    Panel.DisplayMessage("Game was paused. \n\nTo resume press enter. \nTo exit press escape. \nTo save and exit press S.");
                }
            }
        }
    }
}
