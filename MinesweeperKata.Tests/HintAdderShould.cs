using System.Collections.Generic;
using NUnit.Framework;

namespace MinesweeperKata.Tests
{
    public class HintAdderShould
    {
        private HintAdder _hintAdder;

        [SetUp]
        public void SetUp()
        {
            _hintAdder = new HintAdder();
        }

        [Test]
        public void AddHintsToField()
        {
            var mineFieldValues = new Dictionary<Point, int>
            {
                {new Point(0,0), -1},
                {new Point(0,1),  0},
                {new Point(1,0), -1},
                {new Point(1,1), -1}
            };
            var minefield = new Minefield(mineFieldValues);
            var adjacentNeighbours = new List<Point>
            {
                new Point(0, 1),
                new Point(0, 1),
                new Point(0, 1),
            };

            var expectedValues = new Dictionary<Point, int>
            {
                {new Point(0,0), -1},
                {new Point(0,1),  3},
                {new Point(1,0), -1},
                {new Point(1,1), -1}
            };

            var result = _hintAdder.GetFieldWithHints(minefield, adjacentNeighbours);

            CollectionAssert.AreEquivalent(expectedValues, result.Values);
        }

        [Test]
        public void AddHintsToField2()
        {
            var mineFieldValues = new Dictionary<Point, int>
            {
                {new Point(0,0), -1},
                {new Point(0,1),  0},
                {new Point(1,0), -1},
                {new Point(1,1),  0}
            };
            var minefield = new Minefield(mineFieldValues);
            var adjacentNeighbours = new List<Point>
            {
                new Point(0, 1),
                new Point(0, 1),
                new Point(1, 1),
                new Point(1, 1)
            };

            var expectedValues = new Dictionary<Point, int>
            {
                {new Point(0,0), -1},
                {new Point(0,1),  2},
                {new Point(1,0), -1},
                {new Point(1,1),  2}
            };

            var result = _hintAdder.GetFieldWithHints(minefield, adjacentNeighbours);

            CollectionAssert.AreEquivalent(expectedValues, result.Values);
        }
    }
}
