using DeleteBinObj;

Console.Title = "DeleteBinObj";
ConsoleHelper.ShowHelp();
bool exit = false;

const string bin = "bin";
const string obj = "obj";
string curDir = Directory.GetCurrentDirectory();

while (!exit)
{
    Console.Write("> ");
    string? command = Console.ReadLine()?.ToLower();
    string[]? commands = command?.Split();

    switch (commands?[0])
    {
        case "help":
            if (commands.Length == 1)
                ConsoleHelper.ShowHelp();
            else
                ConsoleHelper.ShowHelp(commands[1]);

            break;

        case "exit":
            exit = true;

            break;

        case "delete":
            try
            {
                Action<string> action = (path) =>
                {
                    Directory.Delete(path, true);
                    Console.WriteLine($"Deleted {path}");
                };

                ConsoleHelper.ActOnDirectories(bin, curDir, action);
                ConsoleHelper.ActOnDirectories(obj, curDir, action);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            break;

        case "read":
            try
            {
                Action<string> action = (path) => Console.WriteLine($"Found {path}");
                
                ConsoleHelper.ActOnDirectories(bin, curDir, action);
                ConsoleHelper.ActOnDirectories(obj, curDir, action);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            break;

#if DEBUG
            case "create":
                int iterations = int.Parse(commands[1]);
                
                ConsoleHelper.CreateDirectories(bin, curDir, iterations);
                ConsoleHelper.CreateDirectories(obj, curDir, iterations);

                break;
#endif

        default:
            Console.WriteLine($"{command} is an invalid command, enter HELP for a list of commands.");

            break;
    }
}
