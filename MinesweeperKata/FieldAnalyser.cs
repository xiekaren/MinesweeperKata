using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata
{
    public class FieldAnalyser
    {
        public IEnumerable<Point> GetPointsAdjacentToMines(Field field)
        {
            foreach (var minePoint in field.Mines)
            {
                var points = GetAdjacentPoints(minePoint);
                return points.Where(t => IsSquareOnField(t, field));
            }
            return new List<Point>();
        }

        public bool IsSquareOnField(Point point, Field field)
        {
            return point.X >= 0 && point.X < field.Height && point.Y >= 0 && point.Y < field.Width;
        }

        public IEnumerable<Point> GetAdjacentPoints(Point point)
        {
            var points = new List<Point>();
            for (var i = 0; i < point.X + 1; i++)
            {
                for (var j = 0; j < point.Y + 1; j++)
                {
                    if (i != point.X && j != point.Y)
                    {
                        points.Add(new Point {X=i, Y=j});
                    }
                }
            }
            return points;
        }
    }
}