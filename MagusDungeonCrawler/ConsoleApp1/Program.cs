// See https://aka.ms/new-console-template for more information

Console.WriteLine("-= Welcome to the Dungeon! =-");

var keepGoing = true;
var position = (South: 5, East: 5);

const string nsHallway = "You have entered a hallway with exits to the North and South.";
const string ewHallway = "You have entered a hallway with exits to the East and West.";
const string esCorner = "You have entered a corner with exits to the East and South.";
const string neCorner = "You have entered a corner with exits to the North and East.";
const string nwCorner = "You have entered a corner with exits to the North and West.";

// Dungeon structure:
// ============
// =    X     =
// =   XX  X  =
// =   X   X  =
// =   X   X  =
// =   XXXXXX =
// =     O    = <-- You start at the O here, position 5, 5 from the top left
// =     X    =
// ============
var rooms = new[]
{
	new [] { null, null, null, null, "You can go no further North! The only exit is south.", null, null, null, null, null,},
	new [] { null, null, null, esCorner, nwCorner, null, null, "A dead end! The only exit is South.", null, null },
	new [] { null, null, null, nsHallway, null, null, null, nsHallway, null, null},
	new [] { null, null, null, nsHallway, null, null, null, nsHallway, null, null},
	new [] { null, null, null, neCorner, ewHallway, "You have reached a crossroad. Exits are South, East, and West.", ewHallway, "You have reached a crossroad. Exits are North, East, and West.", "A dead end! The only exit is West.", null },
	new [] { null, null, null, null, null, nsHallway, null, null, null, null},
	new [] { null, null, null, null, null, "You can go no further South! The only exit is North.", null, null, null, null }
};

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
