using System.Collections.Generic;
using MinesweeperKata.DTO;
using NUnit.Framework;

namespace MinesweeperKata.Tests
{
    [TestFixture]
    public class InputToMinefieldParserShould
    {
        private InputToMinefieldParser _inputToMinefieldParser;

        [SetUp]
        public void SetUp()
        {
            _inputToMinefieldParser = new InputToMinefieldParser();
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

            var result = _inputToMinefieldParser.SplitInputFields(input);

            CollectionAssert.AreEquivalent(new[] { "11\n.", "22\n..\n.." }, result);
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

            var result = _inputToMinefieldParser.ToMinefield(input);

            CollectionAssert.AreEquivalent(result.Values, expectedValues);
        }

        [Test]
        public void ParseTextToField()
        {
            const string input = "22\n" +
                                 ".*\n" +
                                 "*.";

            var expected = new Field
            {
                Rows = 2,
                Columns = 2,
                Locations = new List<Location>()
            };

            var result = _inputToMinefieldParser.ToField(input);

            Assert.AreEqual(result, expected);
        }
    }
}
