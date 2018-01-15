using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;
using MinesweeperKata.Presentation;
using NUnit.Framework;

namespace MinesweeperKata.Tests.Presentation
{
    [TestFixture]
    public class FormatterShould
    {
        private Formatter _formatter;

        [SetUp]
        public void SetUp()
        {
            _formatter = new Formatter();
        }


        [Test]
        public void FormatSingleHint()
        {
            var hints = new List<HintField>
            {
                new HintField
                {
                    Rows = 2, Columns = 1,
                    FieldHints = new List<string>
                    {
                        "1",
                        "*"
                    }
                }
            };

            var expected = new[]
            {
                "Field #1:",
                "1",
                "*"
            };
            var expectedFormat = Format(expected);

            var actual = _formatter.FormatHints(hints);

            Assert.AreEqual(expectedFormat, actual);
        }

        [Test]
        public void FormatHints()
        {
            var hints = new List<HintField>
            {
                new HintField
                {
                    Rows = 1, Columns = 1,
                    FieldHints = new List<string>
                    {
                        "0"
                    }
                },
                new HintField
                {
                    Rows = 2, Columns = 2,
                    FieldHints = new List<string>
                    {
                        "2", "*",
                        "*", "2"
                    }
                },
                new HintField
                {
                    Rows = 1, Columns = 1,
                    FieldHints = new List<string>
                    {
                        "0"
                    }
                },
            };

            var expected = new[]
            {
                "Field #1:",
                "0",
                "",
                "Field #2:",
                "2*",
                "*2",
                "",
                "Field #3:",
                "0"

            };
            var expectedFormat = Format(expected);

            var actual = _formatter.FormatHints(hints);

            Assert.AreEqual(expectedFormat, actual);
        }

        private static string Format(IEnumerable<string> input)
        {
            var formattedInput = input.Aggregate("", (current, line) => current + line + "\n");
            return formattedInput.TrimEnd('\n');
        }
    }
}