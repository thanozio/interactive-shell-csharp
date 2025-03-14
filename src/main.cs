using System.Diagnostics;

var validBuiltins = new HashSet<string>()
{
    "exit",
    "echo",
    "type"
};

while (true)
{
    Console.Write("$ ");
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        continue;
    }

    input = input.Trim();
    if (input.StartsWith("exit", StringComparison.InvariantCultureIgnoreCase))
    {
        break;
    }
    else if (input.StartsWith("echo", StringComparison.InvariantCultureIgnoreCase))
    {
        Console.WriteLine(input.Substring(5));
    }
    else if (input.StartsWith("type", StringComparison.InvariantCultureIgnoreCase))
    {
        var command = input.Substring(5).Trim().ToLower();
        if (validBuiltins.Contains(command))
        {
            Console.WriteLine($"{command} is a shell builtin");
        }
        else
        {
            (bool isCommandFound, string commandLocation) = NativeCommandChecker(command);
            if (isCommandFound)
            {
                Console.WriteLine($"{command} is {commandLocation}");
            }
            else
            {
                Console.WriteLine($"{command}: not found");
            }
        }
    }
    else
    {
        var arguments = input.Split(' ').Select(arg => arg.Trim()).ToArray();
        (bool isCommandFound, _) = NativeCommandChecker(arguments[0]);
        if (isCommandFound)
        {
            if (arguments.Length > 1)
            {
                Process.Start(arguments[0], arguments[1..]);
            }
            else
            {
                Process.Start(arguments[0]);
            }
        }
        else
        {
            Console.WriteLine($"{input}: command not found");
        }
    }
}


static (bool, string) NativeCommandChecker(string command)
{
    // asserting cause it's guaranteed per exercise instructions
    var pathLocations = Environment.GetEnvironmentVariable("PATH")!;

    var isCommandFound = false;
    string commandLocation = "";
    foreach (var directory in pathLocations.Split(Path.PathSeparator))
    {
        commandLocation = Path.Combine(directory, command);
        if (File.Exists(commandLocation))
        {
            isCommandFound = true;
            break;
        }
    }

    return (isCommandFound, commandLocation);
}