using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MinesweeperKata.Tests
{
    [TestFixture]
    public class MinesweeperShould
    {
        private Minesweeper _minesweeper;

        [SetUp]
        public void SetUp()
        {
            _minesweeper = new Minesweeper();
        }

        [TestCase(
            new []
            {
                "11",
                ".",
                "",
                "00"
            },
            new []
            {
                "Field #1:",
                "0"
            }
        )]
        [TestCase(
            new []
            {
                "11",
                ".",
                "",
                "22",
                "..",
                ".*",
                "",
                "00"
            },
            new []
            {
                "Field #1:",
                "0",
                "",
                "Field #2:",
                "11",
                "1*"
            }
        )]
        [TestCase(
            new []
            {
                "44",
                "*...",
                "....",
                ".*..",
                "....",
                "",
                "35",
                "**...",
                ".....",
                ".*...",
                "",
                "00"
            },
            new []
            {
                "Field #1:",
                "*100",
                "2210",
                "1*10",
                "1110",
                "",
                "Field #2:",
                "**100",
                "33200",
                "1*100"
            }
            )]
        public void ShowHints(string[] input, string[] expectedOutput)
        {
            var formattedOutput = FormatInput(expectedOutput);
            var formattedInput = FormatInput(input);

            var result = _minesweeper.ShowHints(formattedInput);

            Assert.AreEqual(formattedOutput, result);
        }

        private static string FormatInput(IEnumerable<string> input)
        {
            var formattedInput = input.Aggregate("", (current, line) => current + line + "\n");
            return formattedInput.TrimEnd('\n');
        }
    }

}