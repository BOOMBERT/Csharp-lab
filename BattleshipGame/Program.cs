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

int attempts = 0;
bool running = true;
string columnLetter;
string rowNumber;
bool isValid;

while (running)
{
    attempts++;
    do
    {
        Console.Write("Enter the column letter: ");
        columnLetter = Console.ReadLine();

        isValid = IsValidColumnLetter(columnLetter);

        if (!isValid)
        {
            Console.WriteLine("Enter correct value.");
        }
        Console.WriteLine();
    } while (!isValid);
    
    do
    {
        Console.Write("Enter the row number: ");
        rowNumber = Console.ReadLine();

        isValid = IsValidRowNumber(rowNumber);

        if (!isValid)
        {
            Console.WriteLine("Enter correct value.");

        }
        Console.WriteLine();
    } while (!isValid);

    board.Shot(char.Parse(columnLetter.ToUpper()), int.Parse(rowNumber));
    Console.WriteLine(board);

    if (board.GameOver())
    {
        string playAgainOrExit;
        Console.WriteLine("Congratulations, the game is over.");
        Console.WriteLine($"Number of your attempts: {attempts}");
        Console.WriteLine();
        do
        {
            Console.Write("Enter '1' if you want to play again, or enter '2' if you want to exit the game: ");
            playAgainOrExit = Console.ReadLine();

            if (playAgainOrExit == "1")
            {
                Console.WriteLine("The new game is just getting started." + Environment.NewLine);
                board = new Board(lengthAndNumberOfShips);
            }
            else if (playAgainOrExit == "2")
            {
                Console.WriteLine("Bye!");
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid option!" + Environment.NewLine);
            }
        } while (playAgainOrExit != "1" && playAgainOrExit != "2");
    }
}

static bool IsValidColumnLetter(string input)
{
    if (input.Length == 1)
    {
        char column = input.ToUpper()[0];
        return column >= 'A' && column <= 'Z';
    }
    return false;
}

static bool IsValidRowNumber(string input)
{
    if (int.TryParse(input, out int rowNumber))
    {
        return rowNumber >= 0;
    }
    return false;
}
