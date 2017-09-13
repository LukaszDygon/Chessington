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
            availableMoves.AddRange(AvailableMoveChecker.GetAscendingMoves(board, position));
            availableMoves.AddRange(AvailableMoveChecker.GetDescendingMoves(board, position));

            return availableMoves;
        }
    }
}