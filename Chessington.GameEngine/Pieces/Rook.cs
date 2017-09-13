using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(this);
            availableMoves.AddRange(GetHorizonalMoves(board, position));
            availableMoves.AddRange(GetVerticalMoves(board, position));

            return availableMoves;

        }

        private List<Square> GetVerticalMoves(Board board, Square position)
        {
            var availableMoves = new List<Square>();

            for (int row = position.Row + 1; row < GameSettings.BoardSize; row++)
            {
                var newPosition = new Square(row, position.Col);
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
            }
            for (int row = position.Row - 1; row >= 0; row--)
            {
                var newPosition = new Square(row, position.Col);
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
            }

            return availableMoves;
        }

        private List<Square> GetHorizonalMoves(Board board, Square position)
        {
            var availableMoves = new List<Square>();

            for (int column = position.Col + 1; column < GameSettings.BoardSize; column++)
            {
                var newPosition = new Square(position.Row, column);
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
            }
            for (int column = position.Col - 1; column >= 0; column--)
            {
                var newPosition = new Square(position.Row, column);
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
            }

            return availableMoves;
        }
    }
}