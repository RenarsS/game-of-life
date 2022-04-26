using System.Text.Json;

namespace GameOfLife
{
    /// <summary>
    /// Implementation for games that use Board interface.
    /// </summary>
    public class BoardGame : Game
    {
        /// <summary>
        /// Board of the game
        /// </summary>
        private IBoard _gameBoard { get; set; }

        /// <summary>
        /// Constructor for the Game.
        /// </summary>
        public BoardGame(IBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        /// <inheritdoc/>
        public override void Play()
        {
            while (State == GameState.Playing)
            {
                Action keyAction = () =>
                {
                    switch (Panel.GetKeyInput())
                    {
                        case ConsoleKey.Spacebar:
                            Pause();
                            break;

                        case ConsoleKey.Enter:
                            Start();
                            Console.Clear();
                            break;

                        case ConsoleKey.Escape:
                            Stop();
                            break;

                        case ConsoleKey.S:
                            Save();
                            Console.Clear();
                            Start();
                            break;
                    }
                };

                Task keyTask = new Task(keyAction);

                keyTask.Start();

                _gameBoard.Flow();

                if (State == GameState.Paused)
                {
                    Panel.DisplayMessage("Game was paused. \n\nTo resume press enter. \nTo exit press escape. \nTo save press S.");
                }
            }
        }

        /// <summary>
        /// Saves the dispositions of the board to JSON file.
        /// </summary>
        public override void Save()
        {
            string fileName = $"C:\\Users\\renars.susejs\\Downloads\\Conways-game-{_gameBoard.BoardId}.json";

            string jsonString = JsonSerializer.Serialize(_gameBoard);

             File.WriteAllText(fileName, jsonString);
        }

    }
}
