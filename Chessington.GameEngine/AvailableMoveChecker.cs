using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessington.GameEngine
{
    public class AvailableMoveChecker
    {
        public static List<Square> GetVerticalMoves(Board board, Square position, int range = GameSettings.BoardSize)
        {
            var availableMoves = new List<Square>();

            for (int row = position.Row + 1; row < GameSettings.BoardSize; row++)
            {
                var newPosition = new Square(row, position.Col);
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
            }
            for (int row = position.Row - 1; row >= 0; row--)
            {
                var newPosition = new Square(row, position.Col);
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
            }

            return availableMoves;
        }

        public static List<Square> GetHorizonalMoves(Board board, Square position, int range = GameSettings.BoardSize)
        {
            var availableMoves = new List<Square>();

            for (int column = position.Col + 1; column < GameSettings.BoardSize; column++)
            {
                var newPosition = new Square(position.Row, column);
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
            }
            for (int column = position.Col - 1; column >= 0; column--)
            {
                var newPosition = new Square(position.Row, column);
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
            }

            return availableMoves;
        }

        public static List<Square> GetAscendingMoves(Board board, Square position, int range = GameSettings.BoardSize)
        {
            var availableMoves = new List<Square>();

            int column = position.Col + 1;
            int row = position.Row + 1;
            while (column < GameSettings.BoardSize && row < GameSettings.BoardSize)
            {
                var newPosition = new Square(row, column);
                availableMoves.Add(newPosition);

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
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
                column--;
                row--;
            }

            return availableMoves;
        }

        public static List<Square> GetDescendingMoves(Board board, Square position, int range=GameSettings.BoardSize)
        {
            var availableMoves = new List<Square>();

            int column = position.Col + 1;
            int row = position.Row - 1;
            while (column < GameSettings.BoardSize && row >= 0)
            {
                var newPosition = new Square(row, column);
                availableMoves.Add(newPosition);

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
                availableMoves.Add(newPosition);

                if (board.IsOccupied(newPosition))
                {
                    break;
                }
                column--;
                row++;
            }

            return availableMoves;
        }
    }
}
