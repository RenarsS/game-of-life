
namespace GameOfLife
{
    public interface IBoardBase
    {
        /// <summary>
        /// Unique identifier of the id.
        /// </summary>
        public Guid BoardId { get; }

        /// <summary>
        /// Holds statistics about board.
        /// </summary>
        public Dictionary<string, int> Statistics { get; set; }

        /// <summary>
        /// Layout of the board with recent generation.
        /// </summary>
        public bool[,] InitialBoard { get; set; }

    }
}
