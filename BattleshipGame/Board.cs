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

            for (int i = 0; i < Size; i++)
            {
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
