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
        var command = input.Substring(5).ToLower();
        if (validBuiltins.Contains(command))
        {
            Console.WriteLine($"{command} is a shell builtin");
        }
        else
        {
            Console.WriteLine($"{command}: not found");
        }
    }
    else
    {
        Console.WriteLine($"{input}: command not found");
    }
}
