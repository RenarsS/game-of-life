
namespace GameOfLife
{
    /// <summary>
    /// Interface for player implementation.
    /// Player is responsible for wrapping and ruuning game.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Encapsulates logic for running game.
        /// Partially responsible for controlling what is viewed.
        /// </summary>
        public void Run();
    }
}
