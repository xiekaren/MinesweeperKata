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

        [TestCase("00",
                  "")]

        [TestCase("11\n" +
                  ".\n" +
                  "\n" +
                  "00",
                  
                  "Field #1:\n" +
                  "0")]
        [Ignore("")]
        public void GetHints(string input, string expected)
        {
            Assert.AreEqual(expected, _minesweeper.GetHints(input));
        }

    }
}
