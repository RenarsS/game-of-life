
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
            Panel.DisplayWelcomeMessage("Conway's game of life");

            int height = Panel.GetIntegerInput("Please enter height of the board:");
            int width = Panel.GetIntegerInput("Please enter width of the board:");

            Console.Clear();

            var conwayBoard = new ConwayBoard(height, width);

            var conwayGame = new BoardGame(conwayBoard);

            while (conwayGame.State != GameState.Exited)
            {
                conwayGame.Play();
            }
        }
    }
}
