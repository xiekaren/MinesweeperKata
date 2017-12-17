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

       
    }
}