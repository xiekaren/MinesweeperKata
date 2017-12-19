using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MinesweeperKata.Tests
{
    public class InputParserShould
    {
        private InputParser _inputParser;

        [SetUp]
        public void SetUp()
        {
            _inputParser = new InputParser();
            ;
        }

        [TestCase("00",
            new[] {"00"})]

        [TestCase("11\n" +
                  ".\n" +
                  "\n" +
                  "00",

            new[] {"11\n.", "00"})]

        [TestCase("11\n" +
                  ".\n" +
                  "\n" +
                  "22\n" +
                  "**\n" +
                  "**\n" +
                  "\n" +
                  "00",

            new[] {"11\n.", "22\n**\n**", "00"})]
        public void SplitInputIntoFields(string input, string[] expected)
        {
            CollectionAssert.AreEqual(expected, _inputParser.SplitInputIntoFields(input));
        }

        [Test]
        public void ParseInputFieldToFieldObject()
        {
            const string input = "23\n" +
                                 "..*\n" +
                                 "*..";
            var expected = new Field
            {
                Rows = 2,
                Columns = 3,
                Zones = new List<Zone>
                {
                    new Zone {X = 0, Y = 0, HasMine = false},
                    new Zone {X = 1, Y = 0, HasMine = false},
                    new Zone {X = 2, Y = 0, HasMine = true},
                    new Zone {X = 0, Y = 1, HasMine = true},
                    new Zone {X = 1, Y = 1, HasMine = false},
                    new Zone {X = 2, Y = 1, HasMine = false}
                }
            };

            var result = _inputParser.ToField(input);

            Assert.AreEqual(expected.Rows, result.Rows);
            Assert.AreEqual(expected.Columns, result.Columns);
            Assert.IsTrue(AreEqual(expected.Zones, result.Zones));
        }

        private bool AreEqual(List<Zone> expected, List<Zone> actual)
        {
            return actual.All(z => expected.Exists(x => z.X == x.X && z.Y == x.Y && z.HasMine == x.HasMine));
        }
    }
}
