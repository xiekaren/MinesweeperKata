using System;
using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.FieldHints
{
    public class FieldAnalyser
    {
        public IEnumerable<Point> GetNeighbours(Point point, Field field)
        {
            var minRow = Math.Max(0, point.Row - 1);
            var maxRow = Math.Min(field.Rows, point.Row + 1);
            var minColumn = Math.Max(0, point.Column - 1);
            var maxColumn = Math.Min(field.Columns, point.Column + 1);

            var neighbours = new List<Point>();

            for (var rowIndex = minRow; rowIndex <= maxRow; rowIndex++)
            {
                for (var columnIndex = minColumn; columnIndex <= maxColumn; columnIndex++)
                {
                    if (!(rowIndex == point.Row && columnIndex == point.Column))
                    {
                        if (GetNeighbour(rowIndex, columnIndex, field) != null)
                        {
                            neighbours.Add(GetNeighbour(rowIndex, columnIndex, field));
                        }
                    }
                    ;
                }
            }

            return neighbours;
        }

        public Point GetNeighbour(int row, int column, Field field)
        {
            return field.Locations.FirstOrDefault(x => x.Row == row && x.Column == column);
        }
    }
}