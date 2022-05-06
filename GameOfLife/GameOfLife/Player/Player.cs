using static GameOfLife.Panel;

namespace GameOfLife
{
    /// <summary>
    /// Responsible for running game.
    /// </summary>
    public class Player : IPlayer
    {
        private readonly string[] _gameMode = new string[] { "Start new game", "Restore game" };

        /// <summary>
        /// Parameterless constructor for player.
        /// </summary>
        public Player()
        {

        }

        /// <summary>
        /// Encasulates logic for the game.
        /// Value gathering and starting game.
        /// </summary>
        public void Run()
        {
            DisplayWelcomeMessage("Conway's game of life");

            int gameMode = DisplayOptionMenu(_gameMode, "Choose game mode:\n\n");

            if(gameMode == 0)
            {
                StartNewGame();
            }
            else
            {
                RestoreGame();
            }

        }

        /// <summary>
        /// Initiates and starts new game.
        /// </summary>
        private void StartNewGame()
        {
            int height = GetIntegerInput("Please enter height of the board:");
            int width = GetIntegerInput("Please enter width of the board:");

            Console.Clear();

            var conwayBoard = new ConwayBoard(height, width);

            var conwayGame = new BoardGame(conwayBoard);

            while (conwayGame.State != GameState.Exited)
            {
                conwayGame.Play();
            }
        }

        /// <summary>
        /// Initiates game from file and starts it.
        /// </summary>
        private void RestoreGame()
        {
            string[] opts = Save<IBoard>.GetRestoreOptions();

            int chosen = DisplayOptionMenu(opts, "Choose file: \n");

            var conwayBoard = Save<ConwayBoard>.Restore(opts[chosen]);

            var conwayGame = new BoardGame(conwayBoard);

            while (conwayGame.State != GameState.Exited)
            {
                conwayGame.Play();
            }
        }
    }
}
