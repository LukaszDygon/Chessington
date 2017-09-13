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

            availableMoves.AddRange(this.Player == Player.Black
                ? AvailableMoveChecker.GetBlackPawnMoves(board, this)
                : AvailableMoveChecker.GetWhitePawnMoves(board, this));

            return availableMoves;
        }
        
    }
}