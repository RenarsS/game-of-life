
namespace GameOfLife
{
    /// <summary>
    /// Interface for board game functionality implementations.
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Unique identifier of the id.
        /// </summary>
        public Guid BoardId { get; }

        /// <summary>
        /// Holds statistics about board.
        /// </summary>
        //public Dictionary<string, int> Statistics { get; set; }

        /// <summary>
        /// Layout of the board with recent generation.
        /// </summary>
        public bool[,] InitialBoard { get; set; }

        /// <summary>
        /// Algorithm and flow of the board.
        /// </summary>
        public void Flow();

        /// <summary>
        /// Determines how board is iterated and what is updated.
        /// </summary>
        public void Iterate();
    }
}
