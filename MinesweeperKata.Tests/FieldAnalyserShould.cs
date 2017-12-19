using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MinesweeperKata.Tests
{
    [TestFixture]
    public class FieldAnalyserShould
    {
        private FieldAnalyser _fieldAnalyser;

        [SetUp]
        public void SetUp()
        {
            _fieldAnalyser = new FieldAnalyser();
        }

        [Test]
        public void GetMineZones()
        {
            var field = new Field
            {
                Zones = new List<Zone>
                {
                    new Zone {X = 0, Y = 0, HasMine = false},
                    new Zone {X = 1, Y = 0, HasMine = true},
                    new Zone {X = 0, Y = 1, HasMine = true},
                    new Zone {X = 1, Y = 1, HasMine = false},
                }
            };
            var expected = new List<Zone>
            {
                new Zone {X = 1, Y = 0, HasMine = true},
                new Zone {X = 0, Y = 1, HasMine = true}
            };

            var result = _fieldAnalyser.GetMineZones(field);

            Assert.IsTrue(AreEqual(expected, result));
        }

        [Test]
        [Ignore("")]
        public void GetNeighboursOfMines()
        {
            var field = new Field
            {
                Rows = 2,
                Columns = 2,
                Zones = new List<Zone>
                {
                    new Zone {X = 0, Y = 0, HasMine = false}, new Zone {X = 1, Y = 0, HasMine = true},
                    new Zone {X = 0, Y = 1, HasMine = true}, new Zone {X = 1, Y = 1, HasMine = false},
                }
            };

            var expected = new List<Zone>
            {
                new Zone {X = 0, Y = 0, HasMine = false},
                new Zone {X = 1, Y = 1, HasMine = false},
                new Zone {X = 0, Y = 0, HasMine = false},
                new Zone {X = 1, Y = 1, HasMine = false}
            };

            var result = _fieldAnalyser.GetMineNeighbours(field);

            Assert.IsTrue(AreEqual(expected, result));
        }

        [Test]
        public void GetNeighbours()
        {
            var field = new Field
            {
                Rows = 3,
                Columns = 2,
                Zones = new List<Zone>
                {
                    new Zone { X = 0, Y = 0, HasMine = false}, new Zone { X = 1, Y = 0, HasMine = true},
                    new Zone { X = 0, Y = 1, HasMine = true},  new Zone { X = 1, Y = 1, HasMine = false},
                    new Zone { X = 0, Y = 2, HasMine = false}, new Zone { X = 1, Y = 2, HasMine = false},
                }
            };

            var mine = new Zone {X = 0, Y = 1, HasMine = true};

            var expected = new List<Zone>
            {
                new Zone {X = 0, Y = 0, HasMine = false},
                new Zone {X = 1, Y = 0, HasMine = true},
                new Zone {X = 0, Y = 1, HasMine = true},
                new Zone {X = 1, Y = 1, HasMine = false},
                new Zone {X = 0, Y = 2, HasMine = false},
                new Zone {X = 1, Y = 2, HasMine = false},
            };
            var result = _fieldAnalyser.GetNeighbours(mine, field);

            Assert.IsTrue(AreEqual(expected, result));
        }

        private static bool AreEqual(List<Zone> expected, IEnumerable<Zone> actual)
        {
            return actual.All(z => expected.Exists(x => z.X == x.X && z.Y == x.Y && z.HasMine == x.HasMine));
        }
    }
}
