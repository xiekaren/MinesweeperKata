﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinesweeperKata.DTO;
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

            var result = _minesweeper.GetHints(formattedInput);

            Assert.AreEqual(formattedOutput, result);
        }

        [Test]
        public void TransformInputToMinefield()
        {
            var input = new[]
            {
                "11",
                ".",
                "",

                "00"
            };
            var formattedInput = FormatInput(input);

            var expected = new List<Field>
            {
                new Field
                {
                    Rows = 1, Columns = 1,
                    Locations = new List<Location> {new Location {Row = 0, Column = 0, IsMine = false} }
                }
            };

            var result = _minesweeper.TransformInputToMinefields(formattedInput);

            CollectionAssert.AreEqual(expected, result);
        }

        private static string FormatInput(IEnumerable<string> input)
        {
            var formattedInput = input.Aggregate("", (current, line) => current + (line + "\n"));
            return formattedInput.TrimEnd('\n');
        }
    }
}