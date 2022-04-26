using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Class for managing messages and operations that are displayed in console.
    /// Acts like visual element manager.
    /// </summary>
    public static class Panel
    {
        /// <summary>
        /// Gets integer input. Parses string to int.
        /// </summary>
        /// <param name="message">String that gives user what kind of integer value is needed.</param>
        /// <returns>Intger that was input by user.</returns>
        public static int GetIntegerInput(string message)
        {
            string input;

            do
            {
                DisplayMessage(message);
                input = Console.ReadLine();
            }
            while (!Validation.ValidateNaturalNum(input));

            Console.WriteLine();

            return int.Parse(input);
        }

        /// <summary>
        /// Gets key input.
        /// </summary>
        /// <returns>Key which was pressed.</returns>
        public static ConsoleKey GetKeyInput()
        {
            return Console.ReadKey(true).Key;
        }

        /// <summary>
        /// Displays message in console.
        /// </summary>
        /// <param name="message">String that is displayed.</param>
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays message that welcoms user.
        /// </summary>
        /// <param name="gameName">Name of the game that user is being welcomed to.</param>
        public static void DisplayWelcomeMessage(string gameName)
        {
            Console.WriteLine($"Welcome to the {gameName}!");
        }

        /// <summary>
        /// Arranges statistics in table-like appearance.
        /// </summary>
        /// <param name="stats">Statistics from the game.</param>
        public static void DisplayStatsTable(Dictionary<string, int> stats)
        {
            foreach (var stat in stats)
            {
                Console.Write("{0, -15} {1,5}\n", stat.Key, stat.Value);
            }

            Console.WriteLine();
        }
    }
}
