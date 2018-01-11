using System.Collections.Generic;
using MinesweeperKata.DTO;
using MinesweeperKata.Presentation;
using NUnit.Framework;

namespace MinesweeperKata.Tests
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
                }
            };

            const string expected = "Field #1:\n" +
                                    "0\n" +
                                    "\n" +
                                    "Field #2:\n" +
                                    "2*\n" +
                                    "*2";

            var actual = _formatter.FormatHints(hints);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FormatSingleHint()
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
                }
            };

            const string expected = "Field #1:\n" +
                                    "0\n" +
                                    "\n" +
                                    "Field #2:\n" +
                                    "2*\n" +
                                    "*2";

            var actual = _formatter.FormatHints(hints);

            Assert.AreEqual(expected, actual);
        }
    }
}