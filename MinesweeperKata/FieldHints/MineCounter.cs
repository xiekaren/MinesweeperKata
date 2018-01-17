using System;
using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.FieldHints
{
    public class MineCounter
    {
        private readonly FieldAnalyser _fieldAnalyser;

        public MineCounter()
        {
            _fieldAnalyser = new FieldAnalyser();
        }

        public int CountAroundPoint(Point point, Field field)
        {
            var neighbours = _fieldAnalyser.GetNeighbours(point, field);
            return neighbours.Count(neighbour => AreNeighbours(point, neighbour, field) && neighbour.IsMine);
        }

        
        public bool AreNeighbours(Point point, Point neighbouringPoint, Field field)
        {
            var minRow = Math.Max(0, point.Row - 1);
            var maxRow = Math.Min(field.Rows, point.Row + 1);
            var minColumn = Math.Max(0, point.Column - 1);
            var maxColumn = Math.Min(field.Columns, point.Column + 1);

            return neighbouringPoint.Row >= minRow && neighbouringPoint.Row <= maxRow
                   && neighbouringPoint.Column >= minColumn && neighbouringPoint.Column <= maxColumn
                   && !point.Equals(neighbouringPoint);
        }
    }
}
