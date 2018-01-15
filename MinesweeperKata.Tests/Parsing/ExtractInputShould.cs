using System.Collections.Generic;
using MinesweeperKata.DTO;
using MinesweeperKata.Parsing;
using NUnit.Framework;

namespace MinesweeperKata.Tests.Parsing
{
    [TestFixture]
    public class ExtractInputShould
    {
        private ExtractFieldData _extractFieldData;

        [SetUp]
        public void Setup()
        {
            _extractFieldData = new ExtractFieldData();
        }

        [Test]
        public void ExtractNumberOfRows()
        {
            var result = _extractFieldData.Rows("21\n" +
                                                ".\n" +
                                                "*\n");
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ExtractColumns()
        {
            var result = _extractFieldData.Columns("12\n" +
                                                   ".*\n");
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ExtractLocations()
        {
            var result = _extractFieldData.Locations("22\n" +
                                                     ".*\n" +
                                                     "**");

            var expected = new List<Location>
            {
                new Location { Row = 0, Column = 0, IsMine = false}, new Location { Row = 0, Column = 1, IsMine = true},
                new Location { Row = 1, Column = 0, IsMine = true}, new Location { Row = 1, Column = 1, IsMine = true},
            };

            CollectionAssert.AreEqual(expected, result);
        }
    }
}