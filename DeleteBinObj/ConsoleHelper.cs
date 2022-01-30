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
        /// <param name="dirToDel">The directory to delete.</param>
        /// <param name="curDir">The current directory to search in.</param>
        public static void DeleteDirectory(string dirToDel, string curDir)
        {
            foreach (string d in Directory.GetDirectories(curDir))
            {
                string pathToDel = $"{curDir}\\{dirToDel}";

                if (d == pathToDel)
                {
                    Directory.Delete(pathToDel, true);
                }
                else
                {
                    DeleteDirectory(dirToDel, d);
                }
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
