using System;
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
        [Ignore("Ignore for now")]
        public void ReturnZeroForAFieldWithNoMines()
        {
            var mineFieldValues = new Dictionary<string, int>
            {
                { "00", 0 }
            };

            var expectedValues = new Dictionary<string, int>
            {
                { "00", 0 }
            };

            var initialMineField = new Minefield(mineFieldValues);
            var expected = new Minefield(expectedValues);
            
            var result = _minesweeper.ShowHints(initialMineField);

            CollectionAssert.AreEquivalent(expected.Values, result.Values);
        }

        
    }
}
