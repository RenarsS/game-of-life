
namespace GameOfLife
{
    /// <summary>
    /// Class for storing and managing field and cells.
    /// </summary>
    [Serializable]
    public abstract class Board : IBoard
    {
        /// <summary>
        /// Unique identifier of the board.
        /// </summary>10
        public Guid BoardId { get; } = Guid.NewGuid();

        /// <summary>
        /// Holds statistics about the game.
        /// </summary>
        public Dictionary<string, int> Statistics { get; set; } = new Dictionary<string, int>();

        /// <summary>
        /// Two-dimensional array in which initial values are stored and new layout created.
        /// </summary>
        public bool[,] InitialBoard { get; set; }

        /// <summary>
        /// Parsed two-dimensional array for serialization.
        /// </summary>
        //public int[][] Layout 
        //{  
        //    get
        //    {
        //        int[][] layout = new int[InitialBoard.GetLength(0)][];

        //        for(int i = 0; i < InitialBoard.GetLength(1); i++)
        //        {
        //            layout[i] = new int[InitialBoard.GetLength(1)];

        //            for (int j = 0; j < InitialBoard.GetLength(1); j++)
        //            {
        //                layout[i][j] = InitialBoard[i, j] ? 1 : 0;
        //            }
        //        }

        //        return layout;
        //    }
        //}

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

        /// <summary>
        /// Displays board based on defined rules. 
        /// </summary>
        public abstract void DisplayBoard();
    }
}
