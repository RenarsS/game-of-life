
namespace GameOfLife
{
    /// <summary>
    /// Interface for game implementation.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Should contain board flow and game control algorithm.
        /// </summary>
        public void Play();

        /// <summary>
        /// Used to control game state.
        /// </summary>
        public void Start();

        /// <summary>
        /// Used to control game state.
        /// </summary>
        public void Stop();

        /// <summary>
        /// Used to control game state.
        /// </summary>
        public void Pause();

        /// <summary>
        /// Saves the game.
        /// </summary>
        public void Save();
    }
}
