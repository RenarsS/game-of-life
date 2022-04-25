﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class Panel
    {
        public static int GetIntegerInput(string message)
        {
            string input;

            do
            {
                DisplayMessage(message);
                input = Console.ReadLine();
            }
            while (!Validation.ValidateNaturalNum(input));

            return int.Parse(input);
        }

        public static ConsoleKey GetKeyInput()
        {
            return Console.ReadKey(true).Key;
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

    }
}
