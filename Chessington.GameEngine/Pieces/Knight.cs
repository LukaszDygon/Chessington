﻿using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();

            availableMoves.AddRange(AvailableMoveChecker.GetKnightMoves(board, this));

            return availableMoves;
        }
    }
}