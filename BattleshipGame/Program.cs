using BattleshipGame;

var board = new Board();

/*
Console.WriteLine("Enter a column letter (A-J): ");
var columnLetter = Console.ReadLine();

Console.WriteLine("Enter a row number (1-10: ");
var rowNumber = Console.ReadLine();

char column;

if (char.TryParse(columnLetter, out column))
{
    board.Shot(column, Convert.ToInt32(rowNumber));
}
*/

board.CreateShips();

Console.WriteLine(board);
