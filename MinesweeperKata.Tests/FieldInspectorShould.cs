using System.Collections.Generic;
using NUnit.Framework;

namespace MinesweeperKata.Tests
{
    public class FieldInspectorShould
    {
        private FieldInspector _fieldInspector;

        [SetUp]
        public void SetUp()
        {
            _fieldInspector = new FieldInspector();
        }

        [Test]
        public void GetMineLocationsForField()
        {
            var mineFieldValues = new Dictionary<Point, int>
            {
                {new Point(0, 0), 0},
                {new Point(0, 1), -1},
                {new Point(1, 0), 0},
                {new Point(1, 1), -1}
            };
            var mineField = new Minefield(mineFieldValues);
            var expected = new List<Point>
            {
                new Point(0, 1),
                new Point(1, 1)
            };

            var result = _fieldInspector.GetMineLocations(mineField);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void GetMineLocationsForFieldEmpty()
        {
            var mineFieldValues = new Dictionary<Point, int>
            {
                {new Point(0, 0), 0},
                {new Point(0, 1), 0},
                {new Point(1, 0), 0},
                {new Point(1, 1), 0}
            };
            var mineField = new Minefield(mineFieldValues);
            var expected = new List<Point>();

            var result = _fieldInspector.GetMineLocations(mineField);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        [Ignore("Ignore until we can get neighbour for point")]
        public void GetMineNeighbours()
        {
            var mineFieldValues = new Dictionary<Point, int>
            {
                {new Point(0, 0), -1},
                {new Point(0, 1), 0},
                {new Point(1, 0), 0},
                {new Point(1, 1), 0}
            };
            var mineLocations = new List<Point> {new Point(0, 0)};
            var mineField = new Minefield(mineFieldValues);
            var expected = new List<Point>
            {
                new Point(0, 1),
                new Point(1, 0),
                new Point(1, 1),
            };

            var result = _fieldInspector.GetEmptyNeighboursForMines(mineField, mineLocations);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void GetNeighboursForCornerPoint()
        {
            var mineFieldValues = new Dictionary<Point, int>
            {
                {new Point(0, 0), -1},
                {new Point(0, 1), 0},
                {new Point(1, 0), 0},
                {new Point(1, 1), 0}
            };

            var mineField = new Minefield(mineFieldValues);
            var point = new Point(0, 0);
            var expected = new List<Point>
            {
                new Point(0, 1),
                new Point(1, 0),
                new Point(1, 1)
            };

            var result = _fieldInspector.GetEmptyNeighboursForPoint(point, mineField);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void GetNeighboursForMiddlePoint()
        {
            var mineFieldValues = new Dictionary<Point, int>
            {
                {new Point(0, 0), 0},
                {new Point(0, 1), 0},
                {new Point(0, 2), 0},
                {new Point(1, 0), 0},
                {new Point(1, 1), -1},
                {new Point(1, 2), 0},
                {new Point(2, 0), 0},
                {new Point(2, 1), 0},
                {new Point(2, 2), 0}
            };

            var mineField = new Minefield(mineFieldValues);
            var point = new Point(1, 1);
            var expected = new List<Point>
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(0, 2),
                new Point(1, 0),
                new Point(1, 2),
                new Point(2, 0),
                new Point(2, 1),
                new Point(2, 2)
            };

            var result = _fieldInspector.GetEmptyNeighboursForPoint(point, mineField);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void GetNoNeighboursForPointThatHasNoNeighbours()
        {
            var mineFieldValues = new Dictionary<Point, int>
            {
                {new Point(0, 0), 0},
            };

            var mineField = new Minefield(mineFieldValues);
            var point = new Point(0, 0);
            var expected = new List<Point>();

            var result = _fieldInspector.GetEmptyNeighboursForPoint(point, mineField);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void GetNeighboursExcludingMines()
        {
            var mineFieldValues = new Dictionary<Point, int>
            {
                {new Point(0, 0), 0},
                {new Point(0, 1), -1},
                {new Point(1, 0), -1},
                {new Point(1, 1), 0},
            };

            var mineField = new Minefield(mineFieldValues);
            var point = new Point(0, 0);
            var expected = new List<Point>
            {
                new Point(1, 1)
            };

            var result = _fieldInspector.GetEmptyNeighboursForPoint(point, mineField);

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}