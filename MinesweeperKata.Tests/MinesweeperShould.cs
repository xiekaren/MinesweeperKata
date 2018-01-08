using System.Collections.Generic;
using System.Text;
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

        [TestCase("11\n" +
                  ".\n" +
                  "\n" +
                  "00",
            "Field #1:\n" +
            "0")]
        [TestCase("11\n" +
                  ".\n" +
                  "\n" +
                  "22\n" +
                  "..\n" +
                  ".*\n" +
                  "\n" +
                  "00",
            "Field #1:\n" +
            "0\n" +
            "\n" +
            "Field #2:\n" +
            "11\n" +
            "1*")]
        [TestCase("44\n" +
                  "*...\n" +
                  "....\n" +
                  ".*..\n" +
                  "....\n" +
                  "\n" +
                  "35\n" +
                  "**...\n" +
                  ".....\n" +
                  ".*...\n" +
                  "\n" +
                  "00",
            "Field #1:\n" +
            "*100\n" +
            "2210\n" +
            "1*10\n" +
            "1110\n" +
            "\n" +
            "Field #2:\n" +
            "**100\n" +
            "33200\n" +
            "1*100")]
        public void ShowHints(string input, string expectedOutput)
        {
            var result = _minesweeper.GetHints(input);

            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void TransformInputToMinefield()
        {
            const string input = "11\n" +
                                 ".\n" +
                                 "\n" +
                                 "\n" +
                                 "11\n" +
                                 "*\n" +
                                 "\n" +
                                 "00";

            var expected = new List<Minefield>
            {
                new Minefield(new Dictionary<Point, int>()),
                new Minefield(new Dictionary<Point, int>())
            };

            var result = _minesweeper.TransformInputToMinefields(input);
            
            CollectionAssert.AreEqual(expected, result);
        }

        private string FormatInput(IEnumerable<string> input)
        {
            var builder = new StringBuilder();
            foreach (var s in input)
            {
                builder.Append(s);
            }
            return builder.ToString();
        }
    }
}