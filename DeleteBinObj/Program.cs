using DeleteBinObj;

Console.Title = "DeleteBinObj";
ConsoleHelper.ShowHelp();
bool exit = false;

while (!exit)
{
    Console.Write("> ");
    string? command = Console.ReadLine()?.ToLower();
    string[]? commands = command?.Split();
    string currentDirectory = Directory.GetCurrentDirectory();

    switch (commands?[0])
    {
        case "help":
            if (commands.Length == 1)
            {
                ConsoleHelper.ShowHelp();
            }
            else
            {
                ConsoleHelper.ShowHelp(commands[1]);
            }

            break;

        case "exit":
            exit = true;

            break;

        case "delete":
            if (Directory.GetFiles(currentDirectory, "*.sln").Length != 0)
            {
                try
                {
                    Action<string> action = (path) =>
                    {
                        Directory.Delete(path, true);
                        Console.WriteLine($"Deleted {path}");
                    };

                    ConsoleHelper.ActOnDirectories("bin", currentDirectory, action);
                    ConsoleHelper.ActOnDirectories("obj", currentDirectory, action);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Not in a VS project root!");
            }

            break;

        case "read":
            if (Directory.GetFiles(currentDirectory, "*.sln").Length != 0)
            {
                try
                {
                    Action<string> action = (path) => Console.WriteLine($"Found {path}");

                    ConsoleHelper.ActOnDirectories("bin", currentDirectory, action);
                    ConsoleHelper.ActOnDirectories("obj", currentDirectory, action);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Not in a VS project root!");
            }

            break;

        default:
            Console.WriteLine($"{command} is an invalid command, enter HELP for a list of commands.");

            break;
    }
}
