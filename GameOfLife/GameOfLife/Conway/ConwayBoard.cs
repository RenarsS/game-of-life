using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Conway
{
    /// <summary>
    /// Board for Conway's game of life.
    /// </summary>
    public class ConwayBoard : Board
    {
        /// <summary>
        /// Count of live cells on the board.
        /// </summary>
        public int LiveCellCount { get; set; } = 0;

        /// <summary>
        /// Count of iterations of the board.
        /// </summary>
        public int IterationCount { get; set; } = 1;

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
                    initialBoard[i, j] = randomGen.Next(0, 2) == 1;

                    CountLiveCells(initialBoard[i, j]);
                }
            }
        }

        /// <summary>
        /// Defines algorithm of how game should be played and displayed.
        /// </summary>
        public override void Flow()
        {
            DisplayBoard();

            Iterate();

            Thread.Sleep(1000);

            Console.Clear();
        }

        /// <summary>
        /// Iterates throught board and applies rules.
        /// </summary>
        public override void Iterate()
        {
            LiveCellCount = 0;

            bool[,] newBoard = new bool[initialBoard.GetLength(0), initialBoard.GetLength(1)];

            for (int i = 0; i < initialBoard.GetLength(0); i++)
            {
                for (int j = 0; j < initialBoard.GetLength(1); j++)
                {
                    int aliveCellCount = CountLiveNeighbours(i, j);

                    newBoard[i, j] = DetermineCellState(aliveCellCount, initialBoard[i, j]);

                    CountLiveCells(newBoard[i, j]);
                }
            }

            AugmentIterations();

            initialBoard = newBoard;
        }

        /// <summary>
        /// Displays board on console.
        /// Live cells are indicated by white square and un-alived cells by nothing.
        /// </summary>
        public override void DisplayBoard()
        {
            for (int i = 0; i < initialBoard.GetLength(0); i++)
            {
                for (var j = 0; j < initialBoard.GetLength(1); j++)
                {
                    Console.Write(initialBoard[i, j] ? LiveCell + EmptyCell : EmptyCell + EmptyCell);
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
            int previousRow = currentRow == 0 ? initialBoard.GetLength(0) - 1 : currentRow - 1;
            int nextRow = currentRow == initialBoard.GetLength(0) - 1 ? 0 : currentRow + 1;
            int previousColumn = currentColumn == 0 ? initialBoard.GetLength(1) - 1 : currentColumn - 1;
            int nextColumn = currentColumn == initialBoard.GetLength(1) - 1 ? 0 : currentColumn + 1;

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
            LiveCellCount += cell ? 1 : 0;
        }

        /// <summary>
        /// Increases count of iterations.
        /// </summary>
        private void AugmentIterations()
        {
            IterationCount++;
        }
    }
}
