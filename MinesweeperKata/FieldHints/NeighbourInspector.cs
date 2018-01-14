using System;
using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata
{
    public class NeighbourInspector
    {
        private const int Mine = -1;

        public IEnumerable<Point> GetEmptyNeighboursForMines(Minefield minefield, IEnumerable<Point> mineLocations)
        {
            var mineNeighbours = new List<Point>();

            foreach (var mineLocation in mineLocations)
            {
                var neighbours = GetEmptyNeighboursForPoint(mineLocation, minefield);
                mineNeighbours.AddRange(neighbours);
            }

            return mineNeighbours;
        }

        public IEnumerable<Point> GetEmptyNeighboursForPoint(Point point, Minefield mineField)
        {
            var neighbours = new List<Point>();

            for (var x = point.X - 1; x <= point.X + 1; x++)
            {
                for (var y = point.Y - 1; y <= point.Y + 1; y++)
                {
                    var adjacentPoint = new Point(x, y);
                    if (mineField.Values.ContainsKey(adjacentPoint)
                        && !adjacentPoint.Equals(point)
                        && mineField.Values[adjacentPoint] != Mine)
                    {
                        neighbours.Add(adjacentPoint);
                    }
                }
            }

            return neighbours;
        }

        public int CountMinesAroundPoint(int row, int column, Field field)
        {
            var minRow = Math.Max(0, row - 1);
            var maxRow = Math.Min(field.Rows, row + 1);
            var minColumn = Math.Max(0, column - 1);
            var maxColumn = Math.Min(field.Columns, column + 1);

            var mineCount = 0;

            for (var rowIndex = minRow; rowIndex <= maxRow; rowIndex++)
            {
                for (var columnIndex = minColumn; columnIndex <= maxColumn; columnIndex++)
                {
                    if (rowIndex == row && columnIndex == column) continue;

                    if (field.Locations.Any(x => x.Row == rowIndex && x.Column == columnIndex && x.IsMine))
                    {
                        mineCount++;
                    }
                }
            }

            return mineCount;
        }
    }
}
