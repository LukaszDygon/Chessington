using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(this);

            if (this.Player == Player.Black)
            {
                availableMoves.AddRange(AvailableMoveChecker.AddBlackPawnMoves(position, board));
            }
            else
            {
                availableMoves.AddRange(AvailableMoveChecker.AddWhitePawnMoves(position, board));
            }
            return availableMoves;
        }
        
    }
}