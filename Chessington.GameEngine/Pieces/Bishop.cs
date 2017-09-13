using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(this);
            availableMoves.AddRange(GetAscendingMoves(board, position));
            availableMoves.AddRange(GetDescendingMoves(board, position));

            return availableMoves;
        }

        private List<Square> GetAscendingMoves(Board board, Square position)
        {
            var availableMoves = new List<Square>();

            int column = position.Col + 1;
            int row = position.Row + 1;
            while (column < GameSettings.BoardSize && row < GameSettings.BoardSize)
            {
                var newPosition = new Square(row, column);
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
                column++;
                row++;
            }

            column = position.Col - 1;
            row = position.Row - 1;
            while (column >= 0 && row >= 0)
            {
                var newPosition = new Square(row, column);
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
                column--;
                row--;
            }

            return availableMoves;
        }

        private List<Square> GetDescendingMoves(Board board, Square position)
        {
            var availableMoves = new List<Square>();

            int column = position.Col + 1;
            int row = position.Row - 1;
            while(column < GameSettings.BoardSize && row >= 0)
            {
                var newPosition = new Square(row, column);
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
                column++;
                row--;
            }

            column = position.Col - 1;
            row = position.Row + 1;
            while (column >= 0 && row < GameSettings.BoardSize)
            {
                var newPosition = new Square(row, column);
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
                column--;
                row++;
            }

            return availableMoves;
        }
    }
}