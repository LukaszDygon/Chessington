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
            availableMoves.AddRange(AvailableMoveChecker.GetHorizonalMoves(board, position));
            availableMoves.AddRange(AvailableMoveChecker.GetVerticalMoves(board, position));

            return availableMoves;

        }
        
    }
}