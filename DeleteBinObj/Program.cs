using DeleteBinObj;

Console.Title = "DeleteBinObj";
ConsoleHelper.ShowHelp();
bool exit = false;

while (!exit)
{
    Console.Write("> ");
    string? command = Console.ReadLine()?.ToLower();
    string currentDirectory = Directory.GetCurrentDirectory();

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
                ConsoleHelper.DeleteDirectory("bin", currentDirectory);
                ConsoleHelper.DeleteDirectory("obj", currentDirectory);
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
