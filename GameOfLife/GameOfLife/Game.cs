namespace GameOfLife
{
    /// <summary>
    /// Class providing game functionality.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Board of the game
        /// </summary>
        private Board gameBoard { get; set; }

        /// <summary>
        /// Determines 
        /// </summary>
        private bool isActive { get; set; } = false;

        /// <summary>
        /// Constructor for the Game.
        /// </summary>
        public Game()
        {

        }

        /// <summary>
        /// Displays welcome message.
        /// </summary>
        private void Welcome()
        {
            Console.WriteLine("Hello! This is Conway's Game of Life.");

            Console.WriteLine();
        }

        /// <summary>
        /// Prepares for the game - gets input and initializes board.
        /// </summary>
        public void Prepare()
        {
            Welcome();

            int height;
            int width;

            height = GetIntegerInput("Enter height, please: ");
            width = GetIntegerInput("Enter width, please: ");

            Console.Clear();

            gameBoard = new Board(height, width);
        }

        /// <summary>
        /// Starts the game and is displayed on the screen.
        /// </summary>
        public void PlayOnDisplay()
        {
            do
            {
                gameBoard.DisplayIterations();

                gameBoard.DisplayBoard();

                gameBoard.DisplayLiveCellCount();

                gameBoard.Iterate();

                Thread.Sleep(1000);
                Console.Clear();

            } while (isActive);
        }

        /// <summary>
        /// Plays game in the background.
        /// </summary>
        public void Play()
        {
            do
            {
                gameBoard.Iterate();

                Thread.Sleep(1000);
                Console.Clear();

            } while (isActive);
        }

        /// <summary>
        /// Receives and validates input from console and parses it to integer.
        /// </summary>
        /// <param name="message">String that is displayed upon input. Should contain clues for the user.</param>
        /// <returns>Integer from the input.</returns>
        public int GetIntegerInput(string message)
        {
            string input;

            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
            while (!Validation.ValidateNaturalNum(input));

            return int.Parse(input);

        }

        /// <summary>
        /// Starts game by setting isActive, which controls the loop, to true.
        /// </summary>
        public void StartGame()
        {
            isActive = true;
        }

        /// <summary>
        /// Stops game by setting isActive, which controls the loop, to false.
        /// </summary>
        public void StopGame()
        {
            isActive = false;
        }

        /// <summary>
        /// Displays message after game was ended.
        /// </summary>
        public void EndGame()
        {
            Console.Clear();

            Console.WriteLine("Thanks for the game! Well played!");
        }

    }
}
