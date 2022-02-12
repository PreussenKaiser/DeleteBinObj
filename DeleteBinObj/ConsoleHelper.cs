namespace DeleteBinObj
{
    /// <summary>
    /// The class used to handle commands.
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// Contains a dictionary of console arguments.
        /// </summary>
        private static readonly Dictionary<string, string> arguments = new()
        {
            { "exit", "Exits the application." },
            { "delete", "Deletes bin and obj directories" },
            { "read", "Reads every available bin and obj directory." },
        };

        /// <summary>
        /// Acts on specified directories with the provided action.
        /// </summary>
        /// <param name="dirToAct">The directory to act upon.</param>
        /// <param name="curDir">The current directory in recursion.</param>
        /// <param name="action">The action to use.</param>
        public static void ActOnDirectories(string dirToAct, string curDir, Action<string> action)
        {
            if (Directory.GetFiles(Directory.GetCurrentDirectory(), "*.sln").Length == 0)
                throw new FileLoadException("Not in a VS solution!");

            foreach (string dir in Directory.GetDirectories(Path.GetFullPath(curDir)))
            {
                if (dir == Path.Combine(curDir, dirToAct))
                {
                    action(dir);
                }
                else
                {
                    ActOnDirectories(dirToAct, dir, action);
                }
            }
        }

        /// <summary>
        /// Lists available commands.
        /// </summary>
        public static void ShowHelp(string command = "")
        {
            if (string.IsNullOrEmpty(command))
            {
                Console.WriteLine("HELP: Returns a list of commands.");
                Console.WriteLine("EXIT: Exits the application.");
                Console.WriteLine("DELETE: Deletes bin and obj directories.");
                Console.WriteLine("READ: Reads every available bin and obj directory");
            }
            else
            {
                if (arguments.ContainsKey(command))
                {
                    Console.WriteLine(arguments[command]);
                }
                else
                {
                    Console.WriteLine($"{command} is not a valid command.");
                }
            }
        }
    }
}
