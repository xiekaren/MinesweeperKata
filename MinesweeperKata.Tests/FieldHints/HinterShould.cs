using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;
using MinesweeperKata.FieldHints;
using NUnit.Framework;

namespace MinesweeperKata.Tests.FieldHints
{
    [TestFixture]
    public class HinterShould
    {
        private Hinter _hinter;

        [SetUp]
        public void Setup()
        {
            _hinter = new Hinter();
        }

        [Test]
        public void TransformFieldsToHints()
        {
            var field = new Field
            {
                Rows = 1,
                Columns = 1,
                Locations = new List<Location>
                {
                    new Location {Row = 0, Column = 0, IsMine = true}
                }
            };

            var expectedHint = new List<string>
            {
                "*"
            };
            

            var result = _hinter.GetHintsFor(field);

            Assert.AreEqual(expectedHint, result);

        }
    }

    public class Hinter
    {  
        public IEnumerable<string> GetHintsFor(Field field)
        {
            return field.Locations.Select(fieldLocation => GetHint(field, fieldLocation)).ToList();
        }

        private static string GetHint(Field field, Location fieldLocation)
        {
            var neighbourInspector = new NeighbourInspector();
            return fieldLocation.IsMine ? "*" : neighbourInspector.CountMinesAroundPoint(fieldLocation, field).ToString();
        }
    }
}
