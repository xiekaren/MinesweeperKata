using System.Collections.Generic;
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

        [Test]
        public void ReturnZeroForAFieldWithNoMines()
        {
            var minefield = new Minefield(new[] {"."});
            var expectedValues = new Dictionary<string, int>
            {
                { "00", 0 }
            };
            var expected = new Minefield(expectedValues);

            var result = _minesweeper.ShowHints(minefield);

            Assert.AreEqual(expected, result);
        }
    }
}
