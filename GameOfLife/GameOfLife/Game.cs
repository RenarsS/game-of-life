namespace GameOfLife
{
    /// <summary>
    /// Class providing game functionality.
    /// </summary>
    public class Game : IGame
    {
        /// <summary>
        /// Board of the game
        /// </summary>
        private IBoard _gameBoard { get; set; }

        /// <summary>
        /// State of the game.
        /// </summary>
        public GameState State { get; set; } = GameState.Playing;

        /// <summary>
        /// Constructor for the Game.
        /// </summary>
        public Game(IBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        /// <summary>
        /// Starts the game and is displayed on the screen.
        /// </summary>
        public void Play()
        {
            while(State == GameState.Playing)
            {
                Action keyAction = () =>
                {
                    switch(Panel.GetKeyInput())
                    {
                        case ConsoleKey.Spacebar:
                            Pause();
                            break;

                        case ConsoleKey.Enter:
                            Start();
                            break;

                        case ConsoleKey.Escape:
                            Stop();
                            break;
                    }
                };

                Task keyTask = new Task(keyAction);

                keyTask.Start();

                _gameBoard.Flow();
            }
        }

        /// <summary>
        /// Starts game by setting state, which controls the loop, to true.
        /// </summary>
        public void Start()
        {
            State = GameState.Playing;
        }

        public void Stop()
        {
            State = GameState.Exited;
        }

        public void Pause()
        {
            State = GameState.Paused;
        }
    }
}

/*
             //State = GameState.Playing;
            //Console.Clear();

            Action checkAction = () =>
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        Start();
                        Console.WriteLine("Game resumed.");
                        break;

                    case ConsoleKey.Spacebar:
                        Pause();
                        Console.WriteLine("Game paused.");
                        break;

                    case ConsoleKey.Escape:
                        Stop();
                        Console.WriteLine("Game exited.");
                        break;
                }
            };

            Task checkTask = new Task(checkAction);

            checkTask.Start();
             
            while (State == GameState.Playing)
            {

                gameBoard.DisplayBoard();

                gameBoard.Iterate();

                Thread.Sleep(1000);

                Console.Clear();
            }

            if (State == GameState.Paused)
            {
                Console.WriteLine($"Game state - {State}");

                Console.WriteLine("Game was paused.");

                Console.WriteLine();

                Console.WriteLine("To resume press enter.");
                Console.WriteLine("To exit press esc.");

                Console.ReadKey();
            }
 */

/*
             string input;

            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
            while (!Validation.ValidateNaturalNum(input));

            return int.Parse(input);
 */

/*

            int height;
            int width;

            height = GetIntegerInput("Enter height, please: ");
            width = GetIntegerInput("Enter width, please: ");

            Console.Clear();

            gameBoard = new Board(height, width);

 
 */
