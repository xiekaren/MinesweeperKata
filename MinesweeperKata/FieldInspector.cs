using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata
{
    public class FieldInspector
    {
        public IEnumerable<Point> GetMineLocations(Minefield minefield)
        {
            return minefield.Values.Where(value => value.Value == -1).Select(x => x.Key);
        }

        public IEnumerable<Point> GetMineNeighbours(Minefield minefield, IEnumerable<Point> mineLocations)
        {
            var mineNeighbours = new List<Point>();

            foreach (var mineLocation in mineLocations)
            {
                var neighbours = GetNeighboursForPoint(mineLocation, minefield);
                mineNeighbours.AddRange(neighbours);
            }

            return mineNeighbours;
        }

        public IEnumerable<Point> GetNeighboursForPoint(Point point, Minefield mineField)
        {
            var neighbours = new List<Point>();

            for (var x = point.X - 1; x <= point.X + 1; x++)
            {
                for (var y = point.Y - 1; y <= point.Y + 1; y++)
                {
                    var adjacentPoint = new Point(x, y);
                    if (mineField.Values.ContainsKey(adjacentPoint)
                        && !adjacentPoint.Equals(point))
                    {
                        neighbours.Add(adjacentPoint);
                    }
                }
            }

            return neighbours;
        }
    }
}