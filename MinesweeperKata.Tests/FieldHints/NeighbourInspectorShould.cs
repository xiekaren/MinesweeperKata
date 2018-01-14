using System.Collections.Generic;
using MinesweeperKata.DTO;
using MinesweeperKata.FieldHints;
using NUnit.Framework;

namespace MinesweeperKata.Tests.FieldHints
{
    public class NeighbourInspectorShould
    {
        private NeighbourInspector _neighbourInspector;

        [SetUp]
        public void SetUp()
        {
            _neighbourInspector = new NeighbourInspector();
        }

        [Test]
        public void CountMineNeighbours()
        {
            var field = new Field
            {
                Rows = 3,
                Columns = 2,
                Locations = new List<Location>
                {
                    new Location { Row = 0, Column = 0, IsMine = true }, new Location {Row = 0, Column = 1, IsMine = false },
                    new Location { Row = 1, Column = 0, IsMine = false },new Location {Row = 1, Column = 1, IsMine = false },
                    new Location { Row = 2, Column = 0, IsMine = true }, new Location {Row = 2, Column = 1, IsMine = true },
                }
            };

            var point = new Location
            {
                Row = 1,
                Column = 0,
                IsMine = false
            };

            var result = _neighbourInspector.CountMinesAroundPoint(point, field);

            Assert.AreEqual(3, result);
        }
    }
}