using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;
using MinesweeperKata.Parsing;
using NUnit.Framework;

namespace MinesweeperKata.Tests.Parsing
{
    [TestFixture]
    public class InputParserShould
    {
        private InputParser _inputParser;

        [SetUp]
        public void Setup()
        {
            _inputParser = new InputParser();
        }

        [Test]
        public void TransformTextToMultipleFields()
        {
            var input = new[]
            {
                "11",
                ".",
                "",
                "22",
                "..",
                ".*",
                "",
                "00"
            };
            var formattedInput = FormatInput(input);

            var expected = new List<Field>
            {
                new Field
                {
                    Rows = 1, Columns = 1,
                    Locations = new List<Point> {new Point {Row = 0, Column = 0, IsMine = false}}
                },
                new Field
                {
                    Rows = 2, Columns = 2,
                    Locations = new List<Point>
                    {
                        new Point {Row = 0, Column = 0, IsMine = false},
                        new Point {Row = 0, Column = 1, IsMine = false},
                        new Point {Row = 1, Column = 0, IsMine = false},
                        new Point {Row = 1, Column = 1, IsMine = true}
                    }
                }
            };

            var result = _inputParser.InputToFields(formattedInput);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void TransformTextToNoFields()
        {
            var input = new[]
            {
                "00"
            };
            var formattedInput = FormatInput(input);

            var result = _inputParser.InputToFields(formattedInput);

            CollectionAssert.AreEqual(new List<Field>(), result);
        }

        private static string FormatInput(IEnumerable<string> input)
        {
            var formattedInput = input.Aggregate("", (current, line) => current + line + "\n");
            return formattedInput.TrimEnd('\n');
        }
    }
}
