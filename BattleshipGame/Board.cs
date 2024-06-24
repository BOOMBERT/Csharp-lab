using System.Text;

namespace BattleshipGame
{
    enum ShotSign
    {
        Miss = 'O',
        Hit = 'x',
        Sunk = 'X'
    }

    internal class Board
    {
        private readonly char[,] board;
        private const byte Size = 10;
        private const char EmptyFieldSign = '.';
        private readonly Random random = new();
        private readonly List<Ship> ships = new();

        public Board() 
        {
            board = new char[Size, Size];
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    board[i, j] = EmptyFieldSign;
                }
            }
        }

        public override string ToString()
        {
            return Display();
        }

        private string Display()
        {
            var boardStringBuilder = new StringBuilder();
            boardStringBuilder.Append(new string(' ', Size.ToString().Length + 1));

            for (int i = 0; i < Size; i++)
            {
                char columnHeader = (char)('A' + (i % 26));
                boardStringBuilder.Append(columnHeader).Append(' ');
            }
            boardStringBuilder.Append(Environment.NewLine);

            for (int i = 0; i < Size; i++)
            {
                int rowHeader = i + 1;
                int initialSpaces = Size.ToString().Length - rowHeader.ToString().Length;
                boardStringBuilder.Append(new string(' ', initialSpaces)).Append(rowHeader).Append(' ');

                for (int j = 0; j < Size; j++)
                {
                    boardStringBuilder.Append(board[i, j]).Append(' ');
                }
                boardStringBuilder.Append(Environment.NewLine);
            }
            return boardStringBuilder.ToString();
        }

        private bool FieldIsTaken((int, int) field)
        {
            foreach (var ship in ships)
            {
                foreach (var takenField in ship.GetTakenFields())
                {
                    if (takenField == field)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void CreateShips()
        {
            // TODO: Make private
            // TODO: Create multiple ships
            CreateShip(4);
        }

        private void CreateShip(int shipLength)
        {
            bool creating = true;
            while (creating)
            {
                bool isVertical = random.Next(0, 2) == 0;
                int startRow = random.Next(0, Size - (isVertical ? shipLength : 1) + 1);
                int startColumn = random.Next(0, Size - (!isVertical ? shipLength : 1) + 1);

                if (CanPlaceShip(startRow, startColumn, shipLength, isVertical))
                {
                    PlaceShip(startRow, startColumn, shipLength, isVertical);
                    creating = false;
                }
            }
        }

        private bool CanPlaceShip(int startRow, int startColumn, int shipLength, bool isVertical)
        {
            for (int i = 0; i < shipLength; i++)
            {
                int row = startRow + (isVertical ? i : 0);
                int column = startColumn + (!isVertical ? i : 0);

                if (FieldIsTaken((row, column)) || !ShipSurroundingFieldsAreEmpty(row, column))
                {
                    return false;
                }
            }
            return true;
        }

        private bool ShipSurroundingFieldsAreEmpty(int row, int column)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int surroundingRow = row + i;
                    int surroundingColumn = column + j;

                    if (surroundingRow >= 0 && surroundingRow < Size && surroundingColumn >= 0 && surroundingColumn < Size)
                    {
                        if (FieldIsTaken((surroundingRow, surroundingColumn)))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void PlaceShip(int startRow, int startColumn, int shipLength, bool isVertical)
        {
            var shipFields = new HashSet<(int, int)>();
            for (int i = 0; i < shipLength; i++)
            {
                int row = startRow + (isVertical ? i : 0);
                int column = startColumn + (!isVertical ? i : 0);

                shipFields.Add((row, column));
                board[row, column] = 'S'; // TODO: Delete after tests.
            }
            var ship = new Ship(shipLength, shipFields);
            ships.Add(ship);
        }

        private Ship? GetShipByField((int, int) field)
        {
            foreach (var ship in ships)
            {
                foreach (var shipField in ship.GetTakenFields())
                {
                    if (shipField ==  field)
                    {
                        return ship;
                    }
                }
            }
            return null;
        }

        public bool Shot(char column, int row) 
        {
            int columnIndex = column - 65;
            int rowIndex = row - 1;

            if (board[rowIndex, columnIndex] != EmptyFieldSign && board[rowIndex, columnIndex] != 'S') // TODO: After tests delete second condition.
            {
                Console.WriteLine("This field has been selected before!");
                return false;
            }

            if (FieldIsTaken((rowIndex, columnIndex)))
            {
                var ship = GetShipByField((rowIndex, columnIndex));
                if (ship == null) { return false; }

                ship.Hit((rowIndex, columnIndex));

                if (ship.IsSunk())
                {
                    foreach (var shipField in ship.GetTakenFields())
                    {
                        board[shipField.Item1, shipField.Item2] = (char)ShotSign.Sunk;
                    }
                }
                else
                {
                    board[rowIndex, columnIndex] = (char)ShotSign.Hit;
                }
            }
            else
            {
                board[rowIndex, columnIndex] = (char)ShotSign.Miss;
            }
            return true;
        }
    }
}
