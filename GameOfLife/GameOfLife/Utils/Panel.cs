
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options">Options displayed with action.</param>
        public static void DisplayOptionMenu(string[] options)
        {

        }

        /// <summary>
        /// Calls function on key press.
        /// Programmable key fucntionality.
        /// </summary>
        /// <param name="spacebar">Action invoked by spacebar key.</param>
        /// <param name="enter">Action invoked b  by escape key.</param>
        /// <param name="s">Action inved by s key.</param>
        public static void DisplayKeyMenu(Action spacebar, Action enter, Action escape, Action s)
        {
            switch (GetKeyInput())
            {
                case ConsoleKey.Spacebar:
                    spacebar();
                    break;

                case ConsoleKey.Enter:
                    enter();
                    break;

                case ConsoleKey.Escape:
                    escape();
                    break;

                case ConsoleKey.S:
                    s();
                    break;
            }
        }
    }
}
