
using System.Runtime.Serialization;

namespace GameOfLife
{
    /// <summary>
    /// Class for storing and managing field and cells.
    /// </summary>
    [DataContract]
    public abstract class Board : IBoard
    {
        /// <summary>
        /// Unique identifier of the board.
        /// </summary>10
        public Guid BoardId { get; } = Guid.NewGuid();

        /// <summary>
        /// Two-dimensional array in which initial values are stored and new layout created.
        /// </summary>
        [DataMember]
        public bool[,] InitialBoard { get; set; }

        /// <summary>
        /// Characters that indicates live cell on a board.
        /// </summary>
        protected readonly string LiveCell = (char)009632 + " ";

        /// <summary>
        /// Used as a space between cells if used once, and dead cell if used twice.
        /// </summary>
        protected readonly string EmptyCell = "  ";

        /// <summary>
        /// Constructor creates two-dimensional array with user-desired sizes
        /// and populates it with randomly generated boolean values.
        /// </summary>
        /// <param name="height">Number of rows stacked vertically.</param>
        /// <param name="width">Number of values that can be stored in a row.</param>
        public Board(int height, int width)
        {
            InitialBoard = new bool[height, width];
        }
        
        /// <summary>
        /// Constructor for testing purposes.
        /// </summary>
        /// <param name="layout">Array contains predefined boolean values of the field.</param>
        public Board(bool[,] layout)
        {
            InitialBoard = layout;
        }
        
        /// <summary>
        /// Determines board's algorithm in a round.
        /// </summary>
        public abstract void Flow();

        /// <summary>
        /// Iterates whole board once. 
        /// Results in newer generation of board.
        /// </summary>
        public abstract void Iterate();
    }
}
