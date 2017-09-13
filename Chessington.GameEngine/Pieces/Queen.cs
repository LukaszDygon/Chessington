using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var position = board.FindPiece(this);
            var availableMoves = new List<Square>();

            availableMoves.AddRange(AvailableMoveChecker.GetAscendingMoves(board, position));
            availableMoves.AddRange(AvailableMoveChecker.GetDescendingMoves(board, position));
            availableMoves.AddRange(AvailableMoveChecker.GetHorizonalMoves(board, position));
            availableMoves.AddRange(AvailableMoveChecker.GetVerticalMoves(board, position));

            return availableMoves;
        }
    }
}