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
        public static List<Square> GetVerticalMoves(Board board, Piece piece)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            for (int row = position.Row + 1; row < GameSettings.BoardSize; row++)
            {
                var newPosition = new Square(row, position.Col);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves);

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

        public static List<Square> GetHorizonalMoves(Board board, Piece piece)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            for (int column = position.Col + 1; column < GameSettings.BoardSize; column++)
            {
                var newPosition = new Square(position.Row, column);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves);

                if (OccupiedByAny(newPosition, board))
                {
                    break;
                }
            }
            for (int column = position.Col - 1; column >= 0; column--)
            {
                var newPosition = new Square(position.Row, column);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves);

                if (OccupiedByAny(newPosition, board))
                {
                    break;
                }
            }

            return availableMoves;
        }

        public static List<Square> GetAscendingMoves(Board board, Piece piece)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            int column = position.Col + 1;
            int row = position.Row + 1;
            while (column < GameSettings.BoardSize && row < GameSettings.BoardSize)
            {
                var newPosition = new Square(row, column);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves);

                if (OccupiedByAny(newPosition, board))
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

                if (OccupiedByAny(newPosition, board))
                {
                    break;
                }
                column--;
                row--;
            }

            return availableMoves;
        }

        public static List<Square> GetDescendingMoves(Board board, Piece piece)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            int column = position.Col + 1;
            int row = position.Row - 1;
            while (column < GameSettings.BoardSize && row >= 0)
            {
                var newPosition = new Square(row, column);
                AddIfSafeOrDiscardMove(piece, board, newPosition, availableMoves);

                if (OccupiedByAny(newPosition, board))
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

                if (OccupiedByAny(newPosition, board))
                {
                    break;
                }
                column--;
                row++;
            }

            return availableMoves;
        }

        public static List<Square> GetBlackPawnMoves(Board board, Piece piece)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            AddIfSafeOrDiscardPawnMove(piece, board, new Square(position.Row + 1, position.Col), availableMoves);
            AddIfSafeOrDiscardPawnMove(piece, board, new Square(position.Row + 1, position.Col + 1), availableMoves);
            AddIfSafeOrDiscardPawnMove(piece, board, new Square(position.Row + 1, position.Col - 1), availableMoves);

            if (board.MoveHistory.All(x => x.Piece != board.GetPiece(position)) && availableMoves.Count > 0)
            {
                AddIfSafeOrDiscardPawnMove(piece, board, new Square(position.Row + 2, position.Col), availableMoves);
            }
            return availableMoves;
        }

        public static List<Square> GetWhitePawnMoves(Board board, Piece piece)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            AddIfSafeOrDiscardPawnMove(piece, board, new Square(position.Row - 1, position.Col), availableMoves);
            AddIfSafeOrDiscardPawnMove(piece, board, new Square(position.Row - 1, position.Col + 1), availableMoves);
            AddIfSafeOrDiscardPawnMove(piece, board, new Square(position.Row - 1, position.Col - 1), availableMoves);

            if (board.MoveHistory.All(x => x.Piece != board.GetPiece(position)) && availableMoves.Count > 0)
            {
                AddIfSafeOrDiscardPawnMove(piece, board, new Square(position.Row - 2, position.Col), availableMoves);
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

        public static List<Square> GetKingMoves(Board board, Piece piece)
        {
            var availableMoves = new List<Square>();
            var position = board.FindPiece(piece);

            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row + 1, position.Col + 1), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row + 1, position.Col - 1), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row + 1, position.Col), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row, position.Col + 1), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row, position.Col - 1), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row - 1, position.Col + 1), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row - 1, position.Col - 1), availableMoves);
            AddIfSafeOrDiscardMove(piece, board, new Square(position.Row - 1, position.Col), availableMoves);


            return availableMoves;
        }

        private static void AddIfSafeOrDiscardMove(Piece piece, Board board, Square newSquare, List<Square> availableMoves)
        {
            if (CheckSquareInBoard(newSquare) && (OccupiedByOtherPlayer(piece, newSquare, board) ||
                                                  !OccupiedByAny(newSquare, board)))
            {
                availableMoves.Add(newSquare);
            }
        }

        private static void AddIfSafeOrDiscardPawnMove(Piece piece, Board board, Square newSquare, List<Square> availableMoves)
        {
            if (CheckSquareInBoard(newSquare) && ((!OccupiedByAny(newSquare, board) &&
                                                   newSquare.Col == board.FindPiece(piece).Col) ||
                                                  (OccupiedByOtherPlayer(piece, newSquare, board) &&
                                                  newSquare.Col != board.FindPiece(piece).Col)))
            {
                availableMoves.Add(newSquare);
            }
        }

        private static bool CheckSquareInBoard(Square square)
        {
            return (0 <= square.Row && square.Row < GameSettings.BoardSize &&
                0 <= square.Col && square.Col < GameSettings.BoardSize);
        }


        private static bool OccupiedByOtherPlayer(Piece piece, Square square, Board board)
        {
            return (board.IsOccupied(square) &&
                board.GetPiece(square).Player != piece.Player);
        }

        private static bool OccupiedByAny(Square square, Board board)
        {
            return board.IsOccupied(square);
        }

        private static bool CheckAccessBlocked(Piece piece, Square square, Board board)
        {
            if (board.FindPiece(piece).Row == square.Row)
            {
                return CheckHorizonalAccessBlocked(piece, square, board);
            }
            if (board.FindPiece(piece).Col == square.Col)
            {
                return CheckVerticalAccessBlocked(piece, square, board);
            }
            if (board.FindPiece(piece).Col - square.Col +
                board.FindPiece(piece).Row - square.Row == 0)
            {
                return CheckAscendingAccessBlocked(piece, square, board);
            }

            return CheckDescendingAccessBlocked(piece, square, board);
        }

        private static bool CheckHorizonalAccessBlocked(Piece piece, Square square, Board board)
        {
            int difference = board.FindPiece(piece).Col - square.Col;
            foreach (var passingCol in Enumerable.Range(difference + 1, difference - 1))
            {
                if (OccupiedByAny(new Square(square.Row, passingCol), board))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckVerticalAccessBlocked(Piece piece, Square square, Board board)
        {
            int difference = board.FindPiece(piece).Row - square.Row;
            foreach (var passingRow in Enumerable.Range(difference + 1, difference - 1))
            {
                if (OccupiedByAny(new Square(passingRow, square.Col), board))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckAscendingAccessBlocked(Piece piece, Square square, Board board)
        {
            int difference = board.FindPiece(piece).Col - square.Col;
            foreach (var passingRow in Enumerable.Range(difference + 1, difference - 1))
            {
                foreach (var passingCol in Enumerable.Range(difference + 1, difference - 1))
                {
                    if (OccupiedByAny(new Square(passingRow, passingCol), board))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool CheckDescendingAccessBlocked(Piece piece, Square square, Board board)
        {
            int difference = board.FindPiece(piece).Col - square.Col;
            foreach (var passingRow in Enumerable.Range(board.FindPiece(piece).Row - difference + 1, difference - 1))
            {
                foreach (var passingCol in Enumerable.Range(difference + 1, difference - 1))
                {
                    if (OccupiedByAny(new Square(passingRow, passingCol), board))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        //private static bool CheckEnPassant(Piece piece, Square square, Board board)
    }
}
