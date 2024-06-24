using BattleshipGame;

var lengthAndNumberOfShips = new Dictionary<int, int>
{
    { (int)ShipMasts.Four, 1 },
    { (int)ShipMasts.Three, 2 },
    { (int)ShipMasts.Two, 3 },
    { (int)ShipMasts.One, 4 }
};

var board = new Board(lengthAndNumberOfShips);
Console.WriteLine(board);

/*for (int i = 0; i < 10; i++)
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
}*/
