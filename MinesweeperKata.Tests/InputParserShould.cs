using System.Collections.Generic;
using NUnit.Framework;

namespace MinesweeperKata.Tests
{
    [TestFixture]
    public class InputParserShould
    {
        private InputParser _inputParser;

        [SetUp]
        public void SetUp()
        {
            _inputParser = new InputParser();
        }

        [Test]
        public void SplitFields()
        {
            const string input = "11\n" +
                                 "." +
                                 "\n\n" +
                                 "22\n" +
                                 "..\n" +
                                 ".." +
                                 "\n\n" +
                                 "00";

            var result = _inputParser.SplitFields(input);

            CollectionAssert.AreEquivalent(new[] { "11\n.", "22\n..\n..", "00" }, result);
        }

        [Test]
        public void ParseTextToMinefield()
        {
            const string input = "22\n" +
                                 ".*\n" +
                                 "*.";
            var expectedValues = new Dictionary<Point, int>
            {
                { new Point(0,0), 0 },
                { new Point(0,1), -1 },
                { new Point(1,0), -1 },
                { new Point(1,1), 0 }
            };

            var result = _inputParser.ToMinefield(input);

            CollectionAssert.AreEquivalent(result.Values, expectedValues);
        }
    }
}
