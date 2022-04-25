namespace GameOfLife
{
    /// <summary>
    /// Class for storing and managing field and cells.
    /// </summary>
    public abstract class Board : IBoard
    {
        /// <summary>
        /// Two-dimensional array in which initial values are stored and new layout created.
        /// </summary>
        protected bool[,] initialBoard;

        /// <summary>
        /// Characters that indicates live cell on a board.
        /// </summary>
        protected const char LiveCell = (char)009632;

        /// <summary>
        /// Used as a space between cells if used once, and dead cell if used twice.
        /// </summary>
        protected const string EmptyCell = " ";

        /// <summary>
        /// Constructor creates two-dimensional array with user-desired sizes
        /// and populates it with randomly generated boolean values.
        /// </summary>
        /// <param name="height">Number of rows stacked vertically.</param>
        /// <param name="width">Number of values that can be stored in a row.</param>
        public Board(int height, int width)
        {
            initialBoard = new bool[height, width];
        }
        
        /// <summary>
        /// Constructor for testing purposes.
        /// </summary>
        /// <param name="layout">Array contains predefined boolean values of the field.</param>
        public Board(bool[,] layout)
        {
            initialBoard = layout;
        }
        
        /// <summary>
        /// Determines board's algorithm in a round.
        /// </summary>
        public abstract void Flow();

        /// <summary>
        /// Iterates whole board of cells one time. 
        /// Results in newer generation of live cells based on rules.
        /// </summary>
        public abstract void Iterate();

        /// <summary>
        /// Displays board based on defined rules. 
        /// </summary>
        public abstract void DisplayBoard();
    }
}
