namespace DeleteBinObj
{
    /// <summary>
    /// The class used to handle commands.
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// Deletes a directory.
        /// </summary>
        /// <param name="directory">The directory to delete.</param>
        public static void DeleteDirectory(string directory)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string[] projectDirectories = Directory.GetDirectories(currentDirectory);
            List<string> deletedDirectories = new();

            // Loops through current directory, then loops through all found directories.
            foreach (string directoryName in projectDirectories)
            {
                projectDirectories = Directory.GetDirectories(directoryName);

                foreach (string deletedDirectoryName in projectDirectories)
                {
                    projectDirectories = deletedDirectoryName.Split('\\');

                    if (projectDirectories[projectDirectories.Length - 1] == directory)
                    {
                        Directory.Delete(deletedDirectoryName, true);
                        deletedDirectories.Add(deletedDirectoryName);
                    }
                }
            }

            // Lists all deleted directories.
            if (deletedDirectories.Count > 0)
            {
                Console.WriteLine($"{directory} directories deleted:");
                for (int i = 0; i < deletedDirectories.Count; i++)
                {
                    Console.WriteLine(deletedDirectories[i]);
                }
            }
            else
            {
                Console.WriteLine($"No directories called {directory} were found.");
            }
        }

        /// <summary>
        /// Lists available commands.
        /// </summary>
        public static void ShowHelp()
        {
            Console.WriteLine("HELP: Returns a list of commands.");
            Console.WriteLine("EXIT: Exits the application.");
            Console.WriteLine("DELETE: Deletes bin and obj directories.");
        }
    }
}
