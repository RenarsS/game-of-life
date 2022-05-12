
using GameOfLife.Utils;
using System.Runtime.Serialization;

namespace GameOfLife
{
    /// <summary>
    /// Board for Conway's game of life.
    /// </summary>
    [DataContract]
    public class ConwayBoard : Board
    {
        /// <summary>
        /// Count of live cells on the board.
        /// </summary>
        [DataMember]
        private int _liveCellCount { get; set; } = 0;

        /// <summary>
        /// Count of iterations of the board.
        /// </summary>
        [DataMember]
        private int _iterationCount { get; set; } = 1;

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

                    BoardString += InitialBoard[i, j] ? LiveCell + EmptyCell : EmptyCell + EmptyCell;

                    _liveCellCount += InitialBoard[i, j] ? 1 : 0;
                }

                BoardString += "\n";
            }
        }

        /// <summary>
        /// Defines algorithm of how game should be played and displayed.
        /// </summary>
        public override void Flow()
        {
            Panel.DisplayMessage(BoardString);

            Panel.DisplayStatsTableRow(Labels.GenOfCells, _iterationCount);
            Panel.DisplayStatsTableRow(Labels.AmountOfLiveCells, _liveCellCount);

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
            _liveCellCount = 0;

            BoardString = "";

            bool[,] newBoard = new bool[InitialBoard.GetLength(0), InitialBoard.GetLength(1)];

            for (int i = 0; i < InitialBoard.GetLength(0); i++)
            {
                for (int j = 0; j < InitialBoard.GetLength(1); j++)
                {
                    int aliveCellCount = CountLiveNeighbours(i, j);

                    newBoard[i, j] = DetermineCellState(aliveCellCount, InitialBoard[i, j]);

                    BoardString += newBoard[i, j] ? LiveCell + EmptyCell : EmptyCell + EmptyCell;

                    _liveCellCount += newBoard[i, j] ? 1 : 0;
                }

                BoardString += "\n";
            }

            _iterationCount++;

            InitialBoard = newBoard;
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
    }
}
