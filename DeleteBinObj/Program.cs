using System;

namespace DeleteBinObj
{
    /// <summary>
    /// The console application itself.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Controls the arguments passed into the console.
        /// </summary>
        /// <param name="args">Arguments passed in.</param>
        private static void Main(string[] args)
        {
            Console.Title = "DeleteBinObj";
            ConsoleHelper.ShowHelp();

            bool exit = false;

            while (!exit)
            {
                Console.Write("> ");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "help":
                        ConsoleHelper.ShowHelp();

                        break;

                    case "exit":
                        exit = true;

                        break;

                    case "delete":
                        try
                        {
                            ConsoleHelper.DeleteDirectory("bin");
                            ConsoleHelper.DeleteDirectory("obj");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    default:
                        Console.WriteLine($"{command} is an invalid command, enter HELP for a list of commands.");

                        break;
                }
            }
        }
    }
}
