using GameOfLife.Utils;
using static GameOfLife.Panel;

namespace GameOfLife
{
    /// <summary>
    /// Responsible for running game.
    /// </summary>
    public class Player : IPlayer
    {
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
            DisplayWelcomeMessage(Labels.GameName);

            int gameMode = EnableOptionsMenu(Labels.GameModes, Labels.ChooseGameMode);

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
            int height = GetIntegerInput(Labels.EnterBoardHeight);
            int width = GetIntegerInput(Labels.EnterBoardWidth);

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
            string[] opts = FileManager<IBoard>.GetRestoreOptions();

            int chosen = EnableOptionsMenu(opts, Labels.ChooseFile);

            var conwayBoard = FileManager<ConwayBoard>.Restore(opts[chosen]);

            var conwayGame = new BoardGame(conwayBoard);

            while (conwayGame.State != GameState.Exited)
            {
                conwayGame.Play();
            }
        }
    }
}
