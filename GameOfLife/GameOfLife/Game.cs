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
        /// State of the  
        /// </summary>
        public GameState State { get; set; } = GameState.StandBy;

        /// <summary>
        /// Constructor for the Game.
        /// </summary>
        public Game()
        {

        }

        /// <summary>
        /// Prepares for the game - gets input and initializes board.
        /// </summary>
        public void Prepare()
        {

            int height;
            int width;

            height = GetIntegerInput("Enter height, please: ");
            width = GetIntegerInput("Enter width, please: ");

            Console.Clear();

            gameBoard = new Board(height, width);

            StartGame();
        }

        /// <summary>
        /// Starts the game and is displayed on the screen.
        /// </summary>
        public void PlayOnDisplay()
        {
            //State = GameState.Playing;
            //Console.Clear();

            Action checkAction = () =>
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        StartGame();
                        //Game.PlayOnDisplay();
                        Console.WriteLine("Game resumed.");
                        break;

                    case ConsoleKey.Spacebar:
                        PauseGame();
                        Console.WriteLine("Game paused.");
                        break;

                    case ConsoleKey.Escape:
                        EndGame();
                        Console.WriteLine("Game exited.");
                        break;
                }
            };

            Task checkTask = new Task(checkAction);

            checkTask.Start();
             
            while (State == GameState.Playing)
            {
                gameBoard.DisplayIterations();

                gameBoard.DisplayBoard();

                gameBoard.DisplayLiveCellCount();

                gameBoard.Iterate();

                Thread.Sleep(1000);

                Console.Clear();
            }

            Console.WriteLine($"Game state - {State}");

            Console.WriteLine("Game was paused.");

            Console.WriteLine();

            Console.WriteLine("To resume press enter.");
            Console.WriteLine("To exit press esc.");

            Console.ReadKey();
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

            } while (State == GameState.Playing);
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
        /// Starts game by setting state, which controls the loop, to true.
        /// </summary>
        public void StartGame()
        {
            State = GameState.Playing;
            //PlayOnDisplay();
        }

        /// <summary>
        /// Pauses game by setting state accordingly
        /// </summary>
        public void PauseGame()
        {
            State = GameState.Paused;
        }

        /// <summary>
        /// Ends game by setting state accordingly.
        /// </summary>
        public void EndGame()
        {
            State = GameState.Exited;
        }

    }
}
