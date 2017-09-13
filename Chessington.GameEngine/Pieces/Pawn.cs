using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
                AddBlackMoves(availableMoves, position, board);
            }
            else
            {
                AddWhiteMoves(availableMoves, position, board);
            }
            return availableMoves;
        }

        private void AddBlackMoves(List<Square> availableMoves, Square position, Board board)
        {
            var potentialmoves = new List<Square>();
            potentialmoves.Add(new Square(position.Row + 1, position.Col));

            foreach (var potentialMove in potentialmoves)
            {
                if (!board.IsOccupied(potentialMove))
                {
                    availableMoves.Add(potentialMove);
                }
            }
        }

        private void AddWhiteMoves(List<Square> availableMoves, Square position, Board board)
        {
            var potentialmoves = new List<Square>();
            potentialmoves.Add(new Square(position.Row - 1, position.Col));

            foreach (var potentialMove in potentialmoves)
            {
                if (!board.IsOccupied(potentialMove))
                {
                    availableMoves.Add(potentialMove);
                }
            }
        }

        
    }
}