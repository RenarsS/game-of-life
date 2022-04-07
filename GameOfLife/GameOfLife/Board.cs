using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Board
    {
        /// <summary>
        /// Two-dimensional array in which initial values are stored
        /// and new layout created.
        /// </summary>
        private bool[,] initialBoard;

        private readonly int _height;
        private readonly int _width;


        /// <summary>
        /// Creates two-dimensional array with user-desired sizes
        /// and populates it with randomly generated boolean values.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public Board(int height, int width)
        {
            initialBoard = new bool[height, width];

            _height = height;
            _width = width;

            Random rnd = new Random();

            for (int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    initialBoard[i, j] = rnd.Next(0, 2) == 1 ? true : false;
                }
            }

        }
        
        /// <summary>
        /// Constructor for testing purposes.
        /// </summary>
        /// <param name="layout"></param>
        public Board(bool[,] layout)
        {
            initialBoard = layout;

            _height = layout.GetLength(0);
            _width = layout.GetLength(1);
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
        public void Iterate()
        {
            bool[,] newBoard = new bool[_height, _width];

            for(int i = 0; i < initialBoard.GetLength(0); i++)
            {
                for (int j = 0; j < initialBoard.GetLength(1); j++)
                {
                    int aliveCellCount = Count(i, j);

                    bool newCell = Determine(aliveCellCount, initialBoard[i, j]);
                    newBoard[i,j] = newCell;
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
                    Console.Write(initialBoard[i, j] ? (char)009632 + " " : "  ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Iterates through all of the neighbours of a given cell indices.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Integer which represents amount of live cells</returns>
        public int Count( int x, int y)
        {
            int aliveNeighbourCells = 0;

            for(int i = x - 1; i <= x + 1; i++)
            {
                for(int j = y - 1; j <= y +1; j++)
                {
                    if(i >= 0 && j >= 0 && i < initialBoard.GetLength(0) && j < initialBoard.GetLength(1) )
                    {
                        if (initialBoard[i, j])
                        {
                            aliveNeighbourCells++;
                        }
                    }
                }
            }

            if(initialBoard[x, y])
            {
                return aliveNeighbourCells -1;
            }

            return aliveNeighbourCells;
        }

        /// <summary>
        /// Determines state of the cell based on parameters and rules.
        /// </summary>
        /// <param name="neighbourCount">Amount of live neighbour cells.</param>
        /// <param name="initialState">Indicates state of the cell prior to rule application.</param>
        /// <returns>State of the cell with the same.</returns>
        public bool Determine(int neighbourCount, bool initialState)
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
