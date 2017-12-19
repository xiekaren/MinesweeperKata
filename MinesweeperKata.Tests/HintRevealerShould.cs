using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MinesweeperKata.Tests
{
    [TestFixture]
    public class HintRevealerShould
    {
        private HintRevealer _hintRevealer;

        [SetUp]
        public void SetUp()
        {
            _hintRevealer = new HintRevealer();    
        }

        [Test]
        [Ignore("")]
        public void ShowHintsForMines()
        {
            var field = new Field
            {
                Rows = 2,
                Columns = 2,
                Zones = new List<Zone>
                {
                    new Zone {X = 0, Y = 0, HasMine = true},  new Zone {X = 1, Y = 0, HasMine = false},
                    new Zone {X = 0, Y = 1, HasMine = false}, new Zone {X = 1, Y = 1, HasMine = true},
                }
            };

            var expected = new List<string>
            {
                "*", "2",
                "2", "*"
            };

            var result = _hintRevealer.ShowHintsForMines(field);

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
