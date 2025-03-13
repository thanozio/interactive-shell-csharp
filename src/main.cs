using System.Net;
using System.Net.Sockets;

// Uncomment this line to pass the first stage
Console.Write("$ ");

// Wait for user input
string? command = Console.ReadLine();
if (command is not null)
{
    Console.WriteLine($"{command}: command not found");
}