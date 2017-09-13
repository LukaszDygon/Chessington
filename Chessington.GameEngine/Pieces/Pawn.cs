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

            if (this.Player == Player.Black)
            {
                availableMoves.AddRange(AvailableMoveChecker.GetBlackPawnMoves(this, board));
            }
            else
            {
                availableMoves.AddRange(AvailableMoveChecker.GetWhitePawnMoves(this, board));
            }
            return availableMoves;
        }
        
    }
}