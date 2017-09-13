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
                AddBlackMoves(availableMoves, board);
            }
            else
            {
                AddWhiteMoves(availableMoves, board);
            }
            return availableMoves;
        }

        private void AddBlackMoves(List<Square> availableMoves, Board board)
        {
            var position = board.FindPiece(this);
            var potentialMoves = new List<Square>();

            potentialMoves.Add(new Square(position.Row + 1, position.Col));

            if (!board.MoveHistory.Any(x => x.Piece == this))
            {
                potentialMoves.Add(new Square(position.Row + 2, position.Col));
            }

            foreach (var potentialMove in potentialMoves)
            {
                if (!board.IsOccupied(potentialMove))
                {
                    availableMoves.Add(potentialMove);
                }
            }
        }

        private void AddWhiteMoves(List<Square> availableMoves, Board board)
        {
            var position = board.FindPiece(this);
            var potentialMoves = new List<Square>();

            potentialMoves.Add(new Square(position.Row - 1, position.Col));

            if (!board.MoveHistory.Any(x => x.Piece == this))
            {
                potentialMoves.Add(new Square(position.Row - 2, position.Col));
            }

            foreach (var potentialMove in potentialMoves)
            {
                if (!board.IsOccupied(potentialMove))
                {
                    availableMoves.Add(potentialMove);
                }
            }
        }

        
    }
}