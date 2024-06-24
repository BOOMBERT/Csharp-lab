using BattleshipGame;

var board = new Board();
board.CreateShips();
board.CreateShips();
board.CreateShips();
board.CreateShips();
Console.WriteLine(board);


for (int i = 0; i < 10; i++)
{
    Console.Write("Enter a column letter (A-J): ");
    var columnLetter = Console.ReadLine();

    Console.Write("Enter a row number (1-10: ");
    var rowNumber = Console.ReadLine();

    char column;

    if (char.TryParse(columnLetter, out column))
    {
        board.Shot(column, Convert.ToInt32(rowNumber));
    }

    Console.WriteLine(board);
}



/*var takenFields = new HashSet<(int, int)>();
takenFields.Add((0, 0));
takenFields.Add((1, 0));

var ship = new Ship(4, takenFields);

var a = ship.GetTakenFields();
a = new HashSet<(int, int)>();
a.Add((1, 1));


foreach (var field in ship.GetTakenFields())
{
    Console.WriteLine(field);
}*/