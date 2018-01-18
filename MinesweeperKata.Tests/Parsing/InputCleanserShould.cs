using MinesweeperKata.Parsing;
using NUnit.Framework;

namespace MinesweeperKata.Tests.Parsing
{
    [TestFixture]
    public class InputCleanserShould
    {
        [Test]
        public void SplitFields()
        {
            var cleanser = new InputCleanser();
            const string input = "11\n" +
                                 "." +
                                 "\n\n" +
                                 "22\n" +
                                 "..\n" +
                                 ".." +
                                 "\n\n" +
                                 "00";

            var result = cleanser.SplitInputFields(input);

            CollectionAssert.AreEquivalent(new[] {
                "11\n" +
                ".",

                "22\n" +
                "..\n" +
                ".." }, 
                
                result);
        }
    }
}
