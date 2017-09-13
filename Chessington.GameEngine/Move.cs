using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessington.GameEngine.Pieces;
namespace Chessington.GameEngine
{
    public class Move
    {
        public Pieces.Piece Piece { get; set; }
        public Square Square { get; set; }

        public Move(Piece piece, Square square)
        {
            Piece = piece;
            Square = square;
        }
    }
}
