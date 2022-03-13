using System.Diagnostics;

namespace DeleteBinObj;

/// <summary>
/// The class used to handle commands.
/// </summary>
internal static class ConsoleHelper
{
    /// <summary>
    /// Contains a dictionary of console arguments.
    /// </summary>
    private static readonly Dictionary<string, string> Arguments = new()
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

        string[] directories = Directory.GetDirectories(Path.GetFullPath(curDir));
        foreach (string dir in directories)
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
    /// For testing, creates directories at a specified depth.
    /// </summary>
    /// <param name="dirToCreate">The directory to create.</param>
    /// <param name="curDir">The current working directory.</param>
    /// <param name="depth">The level of nesting for the directories.</param>
    [Conditional("DEBUG")]
    public static void CreateDirectories(string dirToCreate, string curDir, int depth)
    {
        if (depth == 0)
        {
            Directory.CreateDirectory(Path.Combine(curDir, dirToCreate));
            return;
        }

        string newDir = depth.ToString();
        Directory.CreateDirectory(Path.Combine(curDir, newDir));
        curDir = Path.Combine(curDir, newDir);

        CreateDirectories(curDir, dirToCreate, depth -= 1);
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
            Console.WriteLine(
                Arguments.ContainsKey(command) ? Arguments[command] : $"{command} is not a valid command.");
        }
    }
}