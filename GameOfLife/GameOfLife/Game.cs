﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Class for managing game and preparing the board.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Board of the game
        /// </summary>
        private Board gameBoard { get; set; }

        /// <summary>
        /// Constructor for the Game.
        /// </summary>
        public Game()
        {

        }

        /// <summary>
        /// Prepares for the game - gets input and initializes board.
        /// </summary>
        public void Prepare()
        {
            Console.WriteLine("Hello! This is Conway's Game of Life.");

            Console.WriteLine();

            int height;
            int width;

            height = GetIntegerInput("Enter height, please: ");
            width = GetIntegerInput("Enter width, please: ");

            Console.Clear();

            gameBoard = new Board(height, width);
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Start()
        {
            gameBoard.Play();
        }

        /// <summary>
        /// Receives and validates input from console and parses it to integer.
        /// </summary>
        /// <param name="message">String that is displayed upon input. Should contain clues for the user.</param>
        /// <returns>Integer from the input.</returns>
        public int GetIntegerInput(string message)
        {
            string input;

            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
            while (!Validation.ValidateNaturalNum(input));

            return int.Parse(input);

        }

    }
}