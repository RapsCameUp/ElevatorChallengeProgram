﻿namespace ElevatorChallengeProgram.Utilities
{
    public static class Logger
    {
        /// <summary>
        /// Logs a message to the console with the desired color
        /// </summary>
        /// <param name="message"></param>
        public static void LogToConsole(string message)
        {
            LogWithColor(message, ConsoleColor.White);
        }

        public static void LogToConsoleGreen(string message)
        {
            LogWithColor(message, ConsoleColor.Green);
        }

        public static void LogToConsoleYellow(string message)
        {
            LogWithColor(message, ConsoleColor.Yellow);
        }

        public static void LogToConsoleRed(string message)
        {
            LogWithColor(message, ConsoleColor.Red);
        }

        private static void LogWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
