namespace GameOfLife
{
    /// <summary>
    /// Class for storing and managing field and cells.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Two-dimensional array in which initial values are stored and new layout created.
        /// </summary>
        private bool[,] initialBoard;

        /// <summary>
        /// Characters that indicates live cell on a board.
        /// </summary>
        private const char LiveCell = (char)009632;

        /// <summary>
        /// Used as a space between cells if used once, and dead cell if used twice.
        /// </summary>
        private const string EmptyCell = " ";

        /// <summary>
        /// Constructor creates two-dimensional array with user-desired sizes
        /// and populates it with randomly generated boolean values.
        /// </summary>
        /// <param name="height">Number of rows stacked vertically.</param>
        /// <param name="width">Number of values that can be stored in a row.</param>
        public Board(int height, int width)
        {
            initialBoard = new bool[height, width];

            Random randomGen = new Random();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    initialBoard[i, j] = randomGen.Next(0, 2) == 1;
                }
            }

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
        /// Starts game. Game played infinitely.
        /// </summary>
        public void Play()
        {
            do
            {
                DisplayBoard();
                Iterate();

                Thread.Sleep(1000);
                Console.Clear();

            } while (true);

        }

        /// <summary>
        /// Iterates whole board of cells one time. 
        /// Results in newer generation of live cells based on rules.
        /// </summary>
        private void Iterate()
        {
            bool[,] newBoard = new bool[initialBoard.GetLength(0), initialBoard.GetLength(1)];

            for(int i = 0; i < initialBoard.GetLength(0); i++)
            {
                for (int j = 0; j < initialBoard.GetLength(1); j++)
                {
                    int aliveCellCount = CountLiveNeighbours(i, j);

                    newBoard[i, j] = DetermineCellState(aliveCellCount, initialBoard[i, j]);
                }
            }

            initialBoard = newBoard;
        }

        /// <summary>
        /// Displays board on console.
        /// Live cells are indicated by white square and un-alived cells by nothing.
        /// </summary>
        public void DisplayBoard()
        {
            for (int i = 0; i < initialBoard.GetLength(0); i++)
            {
                for (var j = 0; j < initialBoard.GetLength(1); j++)
                {
                    Console.Write(initialBoard[i, j] ? LiveCell + EmptyCell : EmptyCell + EmptyCell);
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Iterates through all of the neighbours of a given cell indices.
        /// </summary>
        /// <param name="row">Index of the row of the cell which neighbours are checked.</param>
        /// <param name="column">Index of the cell in the row.</param>
        /// <returns>Integer which represents amount of live cells.</returns>
        private int CountLiveNeighbours( int currentRow, int currentColumn)
        {
            int aliveNeighbourCells;
            int previousRow = currentRow == 0 ? initialBoard.GetLength(0) - 1 : currentRow - 1;
            int nextRow = currentRow == initialBoard.GetLength(0) - 1 ? 0 : currentRow + 1;
            int previousColumn = currentColumn == 0 ? initialBoard.GetLength(1) - 1 : currentColumn - 1;
            int nextColumn = currentColumn == initialBoard.GetLength(1) -1 ? 0 : currentColumn + 1;

            aliveNeighbourCells = initialBoard[previousRow, previousColumn] ? 1 : 0;
            aliveNeighbourCells += initialBoard[previousRow, currentColumn] ? 1 : 0;
            aliveNeighbourCells += initialBoard[previousRow, nextColumn] ? 1 : 0;
            aliveNeighbourCells += initialBoard[currentRow, previousColumn] ? 1 : 0;
            aliveNeighbourCells += initialBoard[currentRow, nextColumn] ? 1 : 0;
            aliveNeighbourCells += initialBoard[nextRow, previousColumn] ? 1 : 0;
            aliveNeighbourCells += initialBoard[nextRow, currentColumn] ? 1 : 0;
            aliveNeighbourCells += initialBoard[nextRow, nextColumn] ? 1 : 0;

            return aliveNeighbourCells;
        }

        /// <summary>
        /// Determines state of the cell based on parameters and rules.
        /// </summary>
        /// <param name="neighbourCount">Amount of live neighbour cells.</param>
        /// <param name="initialState">Indicates state of the cell prior to rule application.</param>
        /// <returns>State of the cell with the same.</returns>
        private bool DetermineCellState(int neighbourCount, bool initialState)
        {
            if (neighbourCount < 2 || neighbourCount > 3)
            {
                return false;
            }

            if (!initialState && neighbourCount == 3)
            {
                return true;
            }
            
            return initialState;
        }
    }
}
