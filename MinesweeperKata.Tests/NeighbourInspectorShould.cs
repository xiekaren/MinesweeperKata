using System.Collections.Generic;
using NUnit.Framework;

namespace MinesweeperKata.Tests
{
    public class NeighbourInspectorShould
    {
        private NeighbourInspector _fieldInspector;

        [SetUp]
        public void SetUp()
        {
            _fieldInspector = new NeighbourInspector();
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
            var mineLocations = new List<Point> { new Point(0, 0) };
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

        public static IEnumerable<TestCaseData> GetNeighboursData
        {
            get
            {
                yield return new TestCaseData(
                    new Point(0, 0),
                    new Dictionary<Point, int>
                    {
                        {new Point(0, 0), 0},
                    },
                    new List<Point>()
                );

                yield return new TestCaseData(
                    new Point(0, 0),
                    new Dictionary<Point, int>
                    {
                        {new Point(0, 0), -1}, {new Point(0, 1), 0},
                        {new Point(1, 0), 0}, {new Point(1, 1), 0}
                    },
                    new List<Point>
                    {
                        new Point(0, 1),
                        new Point(1, 0),
                        new Point(1, 1)
                    }
                );

                yield return new TestCaseData(
                    new Point(0, 0),
                    new Dictionary<Point, int>
                    {
                        {new Point(0, 0), 0}, {new Point(0, 1), -1},
                        {new Point(1, 0), -1}, {new Point(1, 1), 0},
                    },
                    new List<Point>
                    {
                        new Point(1, 1)
                    }
                );

                yield return new TestCaseData(
                    new Point(1, 1),
                    new Dictionary<Point, int>
                    {
                        {new Point(0, 0), 0}, {new Point(0, 1), 0}, {new Point(0, 2), 0},
                        {new Point(1, 0), 0}, {new Point(1, 1), -1}, {new Point(1, 2), 0},
                        {new Point(2, 0), 0}, {new Point(2, 1), 0}, {new Point(2, 2), 0}
                    },
                    new List<Point>
                    {
                        new Point(0, 0),
                        new Point(0, 1),
                        new Point(0, 2),
                        new Point(1, 0),
                        new Point(1, 2),
                        new Point(2, 0),
                        new Point(2, 1),
                        new Point(2, 2)
                    }
                );
            }
        }

        [TestCaseSource(nameof(GetNeighboursData))]
        public void GetNeighboursExcludingMines(Point point, Dictionary<Point, int> minefieldValues,
            List<Point> expectedNeighbours)
        {
            var mineField = new Minefield(minefieldValues);

            var result = _fieldInspector.GetEmptyNeighboursForPoint(point, mineField);

            CollectionAssert.AreEquivalent(expectedNeighbours, result);
        }
    }
}
