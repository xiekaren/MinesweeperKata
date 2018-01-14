using System;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.FieldHints
{
    public class NeighbourInspector
    {
        public int CountMinesAroundPoint(Location location, Field field)
        {
            var minRow = Math.Max(0, location.Row - 1);
            var maxRow = Math.Min(field.Rows, location.Row + 1);
            var minColumn = Math.Max(0, location.Column - 1);
            var maxColumn = Math.Min(field.Columns, location.Column + 1);

            var mineCount = 0;

            for (var rowIndex = minRow; rowIndex <= maxRow; rowIndex++)
            {
                for (var columnIndex = minColumn; columnIndex <= maxColumn; columnIndex++)
                {
                    if (rowIndex == location.Row && columnIndex == location.Column) continue;

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
