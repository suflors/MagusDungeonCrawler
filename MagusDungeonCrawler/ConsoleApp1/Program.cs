// See https://aka.ms/new-console-template for more information
Console.WriteLine("-= Welcome to the Dungeon! =-");

var keepGoing = true;

while (keepGoing)
{
	Console.WriteLine();
	Console.WriteLine("Where would you like to go?");
	Console.WriteLine("(N for North, S for South, E for East, or W for West.)");
	var pressedKey = Console.ReadKey(false);
	Console.WriteLine();

	if (pressedKey.Key == ConsoleKey.N)
	{
		Console.WriteLine("You went North!");
	} else if (pressedKey.Key == ConsoleKey.S)
	{
		Console.WriteLine("You went South!");
	}
}
