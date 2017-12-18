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

        [TestCaseSource(nameof(GetHintsForFieldData))]
        public void GetFieldWithHints(Dictionary<Point, int> minefieldValues, Dictionary<Point, int> expectedValues)
        {
            var initialMineField = new Minefield(minefieldValues);
            var expected = new Minefield(expectedValues);

            var result = _hintAdder.GetFieldWithHints(initialMineField);

            CollectionAssert.AreEquivalent(expected.Values, result.Values);
        }

        public static IEnumerable<TestCaseData> GetHintsForFieldData
        {
            get
            {
                yield return new TestCaseData(
                    new Dictionary<Point, int>
                    {
                        {new Point(0, 0), 0}
                    },
                    new Dictionary<Point, int>
                    {
                        {new Point(0, 0), 0}
                    }
                );

                yield return new TestCaseData(
                    new Dictionary<Point, int>
                    {
                        {new Point(0, 0), -1}, {new Point(0, 1),  0},
                        {new Point(1, 0),  0}, {new Point(1, 1), -1},
                    },
                    new Dictionary<Point, int>
                    {
                        {new Point(0, 0), -1}, {new Point(0, 1),  2},
                        {new Point(1, 0),  2}, {new Point(1, 1), -1},
                    }
                );

                yield return new TestCaseData(
                    new Dictionary<Point, int>
                    {
                        {new Point(0, 0),  0}, {new Point(0, 1),  0},
                        {new Point(1, 0), -1}, {new Point(1, 1),  0},
                        {new Point(2, 0),  0}, {new Point(2, 1),  0},
                    },
                    new Dictionary<Point, int>
                    {
                        {new Point(0, 0),  1}, {new Point(0, 1), 1},
                        {new Point(1, 0), -1}, {new Point(1, 1), 1},
                        {new Point(2, 0),  1}, {new Point(2, 1), 1},
                    }
                );
            }
        }
    }
}
