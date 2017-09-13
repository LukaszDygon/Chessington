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

            availableMoves.AddRange(AvailableMoveChecker.GetHorizonalMoves(board, this));
            availableMoves.AddRange(AvailableMoveChecker.GetVerticalMoves(board, this));

            return availableMoves;

        }
        
    }
}