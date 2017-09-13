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
            availableMoves.AddRange(AvailableMoveChecker.GetAscendingMoves(board, this));
            availableMoves.AddRange(AvailableMoveChecker.GetDescendingMoves(board, this));

            return availableMoves;
        }
    }
}