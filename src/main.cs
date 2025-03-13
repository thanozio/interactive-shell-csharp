
while (true)
{
    Console.Write("$ ");
    string? command = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(command))
    {
        continue;
    }

    if (command.Equals("exit 0", StringComparison.InvariantCultureIgnoreCase))
    {
        break;
    }
    else if (command.StartsWith("echo", StringComparison.InvariantCultureIgnoreCase))
    {
        Console.WriteLine(command.Substring(5));
    }
    else
    {
        Console.WriteLine($"{command}: command not found");
    }
}
