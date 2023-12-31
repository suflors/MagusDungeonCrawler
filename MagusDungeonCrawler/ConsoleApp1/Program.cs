﻿// See https://aka.ms/new-console-template for more information

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
	Console.WriteLine(rooms[position.South][position.East]);
	Console.WriteLine();
	Console.WriteLine("Where would you like to go?");

	var canGoNorth =
		position.South - 1 >= 0 && // North 1 space is not off the map AND
		rooms[position.South - 1][position.East] is not null; // North 1 space is not null
	var canGoSouth =
		position.South + 1 < rooms.Length && // South 1 space is not off the map AND
		rooms[position.South + 1][position.East] is not null; // South 1 space is not null
	var canGoEast =
		position.East + 1 < rooms[0].Length && // East 1 space is not off the map AND
		rooms[position.South][position.East + 1] is not null; // East 1 space is not null
	var canGoWest =
		position.East - 1 >= 0 && // West 1 space is not off the map AND
		rooms[position.South][position.East - 1] is not null; // West 1 space is not null

	Console.Write('(');
	if (canGoNorth)
	{
		Console.Write("N for North");

		if (canGoSouth || canGoEast || canGoWest)
		{
			Console.Write(", ");
		}
	}

	if (canGoSouth)
	{
		Console.Write("S for South");

		if (canGoEast || canGoWest)
		{
			Console.Write(", ");
		}
	}

	if (canGoEast)
	{
		Console.Write("E for East");

		if (canGoWest)
		{
			Console.Write(", ");
		}
	}

	if (canGoWest)
	{
		Console.Write("W for West");
	}
	Console.WriteLine(".)");
	var pressedKey = Console.ReadKey(false);
	Console.WriteLine();

	if (pressedKey.Key == ConsoleKey.N && canGoNorth)
	{
		position = (position.South - 1, position.East);
	} else if (pressedKey.Key == ConsoleKey.S && canGoSouth)
	{
		position = (position.South + 1, position.East);
	} else if (pressedKey.Key == ConsoleKey.E && canGoEast)
	{
		position = (position.South, position.East + 1);
	} else if (pressedKey.Key == ConsoleKey.W && canGoWest)
	{
		position = (position.South, position.East - 1);
	}
}
