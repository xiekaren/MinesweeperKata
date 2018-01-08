using System.Collections.Generic;
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
        public void FormatMinefield()
        {
            var minefieldValues = new Dictionary<Point, int>
            {
                {new Point(0, 0), 2},
                {new Point(0, 1), -1},
                {new Point(1, 0), -1},
                {new Point(1, 1), 2},
            };
            var size = new FieldSize{ Width = 2, Height = 2 };
            var field = new Minefield(minefieldValues);
            const string expected = "2*\n" +
                                    "*2\n\n";

            var result = _formatter.FormatMinefield(size, field);

            Assert.AreEqual(expected, result);
        }
    }
}