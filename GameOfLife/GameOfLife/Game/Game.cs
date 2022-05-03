
namespace GameOfLife
{
    /// <summary>
    /// Class providing game functionality.
    /// </summary>
    public abstract class Game<T> : Save<T>, IGame 
    {
        /// <summary>
        /// State of the game.
        /// </summary>
        public GameState State { get; set; } = GameState.Playing;

        /// <summary>
        /// Starts the game.
        /// </summary>
        public abstract void Play();

        /// <summary>
        /// Starts game.
        /// </summary>
        public void Start()
        {
            State = GameState.Playing;
        }

        /// <summary>
        /// Stops game. Not possible to resume.
        /// Signals app to stop.
        /// </summary>
        public void Stop()
        {
            State = GameState.Exited;
        }

        /// <summary>
        /// Pauses game. Possible to resume.
        /// </summary>
        public void Pause()
        {
            State = GameState.Paused;
        }
    }
}