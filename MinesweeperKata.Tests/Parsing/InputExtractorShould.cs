using System.Collections.Generic;
using MinesweeperKata.Parsing;
using NUnit.Framework;

namespace MinesweeperKata.Tests.Parsing
{
    [TestFixture]
    public class InputExtractorShould
    {
        private InputExtractor _extractor;

        [SetUp]
        public void Setup()
        {
            _extractor = new InputExtractor();
        }

        [Test]
        public void ExtractNumberOfRows()
        {
            var result = _extractor.GetNumberOfRows("21\n" +
                                                    ".\n" +
                                                    "*\n");
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ExtractColumns()
        {
            var result = _extractor.GetNumberOfColumns("12\n" +
                                                       ".*\n");
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ExtractLocations()
        {
            var result = _extractor.GetLocations("22\n" +
                                                 ".*\n" +
                                                 "**");

            var expected = new List<string>
            {
                ".*",
                "**"
            };

            CollectionAssert.AreEqual(expected, result);
        }
    }
}