
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
    else
    {
        Console.WriteLine($"{command}: command not found");
    }
}
