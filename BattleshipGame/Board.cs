using System.Text;

namespace BattleshipGame
{
    internal class Board
    {
        private readonly char[,] board;
        private const byte Size = 10;

        public Board() 
        {
            board = new char[Size, Size];
            Initialize();
        }

        public override string ToString()
        {
            return Display();
        }

        private void Initialize()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    board[i, j] = '.';
                }
            }
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
    }
}
