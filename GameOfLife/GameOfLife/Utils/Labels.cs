
namespace GameOfLife.Utils
{
    public static class Labels
    {
        /// <summary>
        /// Text to display when game is paused. Lists all of the options.
        /// </summary>
        public const string PauseOpts = "Game was paused. \n\nTo resume press enter. \nTo exit press escape. \nTo save and exit press S.";

        public const string GameName = "Conway's game of life";

        public static string[] GameModes = new string[] { "Start new game", "Restore game" };

        public const string EnterBoardHeight = "Please enter height of the board:";

        public const string EnterBoardWidth = "Please enter width of the board:";

        public const string ChooseGameMode = "Choose game mode:\n\n";

        public const string ChooseFile = "Choose file: \n";

        public const string GenOfCells = "Generation of cells: ";

        public const string AmountOfLiveCells = "Amount of live cells: ";
    }
}
