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

        [TestCase("11\n" +
                  ".",

                  "0")]
        [Ignore("")]
        public void ShowHints(string input, string expectedOutput)
        {
            var result = _minesweeper.Hints(input);
            
            Assert.AreEqual(expectedOutput, result);            
        }
    }
}
