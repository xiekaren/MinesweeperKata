using System;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.FieldHints
{
    public class MineCounter
    {
        public int CountAroundPoint(Point point, Field field)
        {
            var minRow = Math.Max(0, point.Row - 1);
            var maxRow = Math.Min(field.Rows, point.Row + 1);
            var minColumn = Math.Max(0, point.Column - 1);
            var maxColumn = Math.Min(field.Columns, point.Column + 1);

            var mineCount = 0;

            for (var rowIndex = minRow; rowIndex <= maxRow; rowIndex++)
            {
                for (var columnIndex = minColumn; columnIndex <= maxColumn; columnIndex++)
                {
                    if (rowIndex == point.Row && columnIndex == point.Column) continue;

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
