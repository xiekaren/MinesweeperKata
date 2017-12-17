using System.Collections.Generic;

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
    }
}
