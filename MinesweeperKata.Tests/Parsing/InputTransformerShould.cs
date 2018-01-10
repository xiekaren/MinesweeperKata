using System.Collections.Generic;
using MinesweeperKata.DTO;
using MinesweeperKata.Parsing;
using NUnit.Framework;

namespace MinesweeperKata.Tests.Parsing
{
    [TestFixture]
    public class InputTransformerShould
    {
        private InputTransformer _inputTransformer;

        [SetUp]
        public void Setup()
        {
            _inputTransformer = new InputTransformer();
        }

        [Test]
        public void ParseTextToField()
        {
            const string input = "22\n" +
                                 ".*\n" +
                                 "*.";

            var expected = new Field
            {
                Rows = 2,
                Columns = 2,
                Locations = new List<Location>
                {
                    new Location {Row = 0, Column = 0, IsMine = false},
                    new Location {Row = 0, Column = 1, IsMine = true},
                    new Location {Row = 1, Column = 0, IsMine = true},
                    new Location {Row = 1, Column = 1, IsMine = false}
                }
            };

            var result = _inputTransformer.ToField(input);

            Assert.AreEqual(result, expected);
        }
    }
}
