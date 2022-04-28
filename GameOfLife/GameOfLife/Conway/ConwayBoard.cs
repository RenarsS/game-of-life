
namespace GameOfLife
{
    /// <summary>
    /// Board for Conway's game of life.
    /// </summary>
    public class ConwayBoard : Board
    {
        /// <summary>
        /// Count of live cells on the board.
        /// </summary>
        private int liveCellCount { get; set; } = 0;

        /// <summary>
        /// Count of iterations of the board.
        /// </summary>
        public int iterationCount { get; set; } = 1;

        /// <summary>
        /// Initialiazes board with required size.
        /// Fills board with random boolean values.
        /// </summary>
        /// <param name="height">Height of the board.</param>
        /// <param name="width">Width of the board.</param>
        public ConwayBoard(int height, int width) : base(height, width)
        {
            Random randomGen = new Random();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    InitialBoard[i, j] = randomGen.Next(0, 2) == 1;

                    CountLiveCells(InitialBoard[i, j]);
                }
            }

            Statistics.Add("Generations of cells", iterationCount);
            Statistics.Add("Amount of live cells", liveCellCount);
        }

        /// <summary>
        /// Defines algorithm of how game should be played and displayed.
        /// </summary>
        public override void Flow()
        {
            DisplayBoard();

            Panel.DisplayStatsTable(Statistics);

            Iterate();

            Thread.Sleep(1000);

            Console.Clear();
        }

        /// <summary>
        /// Iterates throught board and applies rules.
        /// Updates statistics.
        /// </summary>
        public override void Iterate()
        {
            liveCellCount = 0;

            bool[,] newBoard = new bool[InitialBoard.GetLength(0), InitialBoard.GetLength(1)];

            for (int i = 0; i < InitialBoard.GetLength(0); i++)
            {
                for (int j = 0; j < InitialBoard.GetLength(1); j++)
                {
                    int aliveCellCount = CountLiveNeighbours(i, j);

                    newBoard[i, j] = DetermineCellState(aliveCellCount, InitialBoard[i, j]);

                    CountLiveCells(newBoard[i, j]);
                }
            }

            AugmentIterations();

            Statistics["Generations of cells"] = iterationCount;
            Statistics["Amount of live cells"] = liveCellCount;

            InitialBoard = newBoard;
        }

        /// <summary>
        /// Displays board on console.
        /// Live cells are indicated by white square and un-alived cells by nothing.
        /// </summary>
        public override void DisplayBoard()
        {
            for (int i = 0; i < InitialBoard.GetLength(0); i++)
            {
                for (var j = 0; j < InitialBoard.GetLength(1); j++)
                {
                    Console.Write(InitialBoard[i, j] ? LiveCell + EmptyCell : EmptyCell + EmptyCell);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Iterates through all of the neighbours of a given cell indices.
        /// </summary>
        /// <param name="row">Index of the row of the cell which neighbours are checked.</param>
        /// <param name="column">Index of the cell in the row.</param>
        /// <returns>Integer which represents amount of live cells.</returns>
        public int CountLiveNeighbours(int currentRow, int currentColumn)
        {
            int aliveNeighbourCells;
            int previousRow = currentRow == 0 ? InitialBoard.GetLength(0) - 1 : currentRow - 1;
            int nextRow = currentRow == InitialBoard.GetLength(0) - 1 ? 0 : currentRow + 1;
            int previousColumn = currentColumn == 0 ? InitialBoard.GetLength(1) - 1 : currentColumn - 1;
            int nextColumn = currentColumn == InitialBoard.GetLength(1) - 1 ? 0 : currentColumn + 1;

            aliveNeighbourCells = InitialBoard[previousRow, previousColumn] ? 1 : 0;
            aliveNeighbourCells += InitialBoard[previousRow, currentColumn] ? 1 : 0;
            aliveNeighbourCells += InitialBoard[previousRow, nextColumn] ? 1 : 0;
            aliveNeighbourCells += InitialBoard[currentRow, previousColumn] ? 1 : 0;
            aliveNeighbourCells += InitialBoard[currentRow, nextColumn] ? 1 : 0;
            aliveNeighbourCells += InitialBoard[nextRow, previousColumn] ? 1 : 0;
            aliveNeighbourCells += InitialBoard[nextRow, currentColumn] ? 1 : 0;
            aliveNeighbourCells += InitialBoard[nextRow, nextColumn] ? 1 : 0;

            return aliveNeighbourCells;
        }

        /// <summary>
        /// Determines state of the cell based on parameters and rules.
        /// </summary>
        /// <param name="neighbourCount">Amount of live neighbour cells.</param>
        /// <param name="initialState">Indicates state of the cell prior to rule application.</param>
        /// <returns>State of the cell with the same.</returns>
        public bool DetermineCellState(int neighbourCount, bool initialState)
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

        /// <summary>
        /// Used as counter. Adds 1 if cell is live.
        /// </summary>
        /// <param name="cell">Cell that is used to check its state.</param>
        private void CountLiveCells(bool cell)
        {
            liveCellCount += cell ? 1 : 0;
        }

        /// <summary>
        /// Increases count of iterations.
        /// </summary>
        private void AugmentIterations()
        {
            iterationCount++;
        }
    }
}
