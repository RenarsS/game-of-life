using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class Board
    {
        /// <summary>
        /// Two-dimensional array in which initial values are stored
        /// and new layout created.
        /// </summary>
        private bool[,] initalBoard;

        public Board(int height, int width)
        {
            initalBoard = new bool[height, width];
            populateBoard();
        }

        /// <summary>
        /// Dummy value generation. Not random
        /// </summary>
        private void populateBoard()
        {
            for(int i = 0; i < initalBoard.GetLength(0); i++)
            {
                for(var j = 0; j < initalBoard.GetLength(1); j++)
                {
                    initalBoard[i, j] = (i+j) % 2 == 0 ? true : false;
                }
            }
        }

        /// <summary>
        /// Iterates whole board of cells one time. 
        /// Results in newer generation based on rules
        /// </summary>
        /// <returns></returns>
        public bool[,] Iterate()
        {
            bool[,] newBoard = new bool[initalBoard.GetLength(0), initalBoard.GetLength(1)];

            for(int i = 0; i < initalBoard.GetLength(0); i++)
            {
                for (int j = 0; j < initalBoard.GetLength(1); j++)
                {
                    bool initialCell = initalBoard[i, j];


                }
            }
            return newBoard;
        }



        /// <summary>
        /// Displays board on console
        /// </summary>
        public void DisplayBoard()
        {
            for (int i = 0; i < initalBoard.GetLength(0); i++)
            {
                for (var j = 0; j < initalBoard.GetLength(1); j++)
                {
                    Console.Write(initalBoard[i, j] ? 1 : 0);
                }
                Console.WriteLine();
            }
        }
    }
}
