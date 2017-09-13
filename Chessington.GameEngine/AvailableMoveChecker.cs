using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public class AvailableMoveChecker
    {
        public static List<Square> GetVerticalMoves(Board board, Piece piece, int range = GameSettings.BoardSize)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            for (int row = position.Row + 1; row < GameSettings.BoardSize; row++)
            {
                var newPosition = new Square(row, position.Col);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves); ;

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
            }
            for (int row = position.Row - 1; row >= 0; row--)
            {
                var newPosition = new Square(row, position.Col);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
            }

            return availableMoves;
        }

        public static List<Square> GetHorizonalMoves(Board board, Piece piece, int range = GameSettings.BoardSize)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            for (int column = position.Col + 1; column < GameSettings.BoardSize; column++)
            {
                var newPosition = new Square(position.Row, column);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
            }
            for (int column = position.Col - 1; column >= 0; column--)
            {
                var newPosition = new Square(position.Row, column);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
            }

            return availableMoves;
        }

        public static List<Square> GetAscendingMoves(Board board, Piece piece, int range = GameSettings.BoardSize)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            int column = position.Col + 1;
            int row = position.Row + 1;
            while (column < GameSettings.BoardSize && row < GameSettings.BoardSize)
            {
                var newPosition = new Square(row, column);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
                column++;
                row++;
            }

            column = position.Col - 1;
            row = position.Row - 1;
            while (column >= 0 && row >= 0)
            {
                var newPosition = new Square(row, column);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
                column--;
                row--;
            }

            return availableMoves;
        }

        public static List<Square> GetDescendingMoves(Board board, Piece piece, int range=GameSettings.BoardSize)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            int column = position.Col + 1;
            int row = position.Row - 1;
            while (column < GameSettings.BoardSize && row >= 0)
            {
                var newPosition = new Square(row, column);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
                column++;
                row--;
            }

            column = position.Col - 1;
            row = position.Row + 1;
            while (column >= 0 && row < GameSettings.BoardSize)
            {
                var newPosition = new Square(row, column);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
                column--;
                row++;
            }

            return availableMoves;
        }

        public static List<Square> GetBlackPawnMoves(Piece piece, Board board)
        {
            var potentialMoves = new List<Square>();
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            potentialMoves.Add(new Square(position.Row + 1, position.Col));

            if (board.MoveHistory.All(x => x.Piece != board.GetPiece(position)))
            {
                potentialMoves.Add(new Square(position.Row + 2, position.Col));
            }

            foreach (var potentialMove in potentialMoves)
            {
                if (!board.IsOccupied(potentialMove))
                {
                    AddIfSafeOrDiscardMove(piece, board, potentialMove, availableMoves);
                }
            }
            return availableMoves;
        }

        public static List<Square> GetWhitePawnMoves(Piece piece, Board board)
        {
            var potentialMoves = new List<Square>();
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            potentialMoves.Add(new Square(position.Row - 1, position.Col));

            if (board.MoveHistory.All(x => x.Piece != board.GetPiece(position)))
            {
                potentialMoves.Add(new Square(position.Row - 2, position.Col));
            }

            foreach (var potentialMove in potentialMoves)
            {
                if (!board.IsOccupied(potentialMove))
                {
                    AddIfSafeOrDiscardMove(piece, board, potentialMove, availableMoves);
                }
            }
            return availableMoves;
        }

        public static List<Square> GetKnightMoves(Board board, Piece piece)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row + 1, position.Col + 2), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row + 2, position.Col + 1), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row + 1, position.Col - 2), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row - 2, position.Col + 1), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row - 1, position.Col + 2), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row + 2, position.Col - 1), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row - 1, position.Col - 2), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row - 2, position.Col - 1), availableMoves);

            return availableMoves;
        }

        private static void AddIfSafeOrDiscardMove(Piece piece, Board board, Square newSquare, List<Square> moveList)
        {
            if (CheckSquareInBoard(newSquare) && CheckNotOccupied(piece, newSquare, board))
            {
                moveList.Add(newSquare);
            }
        }

        private static bool CheckSquareInBoard(Square square)
        {
            return (0 <= square.Row && square.Row < GameSettings.BoardSize &&
                0 <= square.Col && square.Col < GameSettings.BoardSize);
        }


        private static bool CheckNotOccupied(Piece piece, Square square, Board board)
        {
            return true;
        }
    }
}
