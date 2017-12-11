using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace MinesweeperKata.Spec
{
    [Binding]
    public class MinesweeperSteps
    {
        private MineVisualiser _mineVisualiser;
        private string _result;

        [Given(@"I have entered a (.*) x (.*) grid into the MineVisualiser")]
        public void GivenIHaveEnteredDimensionsOfTheGridIntoTheMineVisualiser(int width, int height)
        {
            _mineVisualiser = new MineVisualiser(width, height);
        }
        
        [Given(@"I have entered also entered a grid that looks like ""(.*)""")]
        public void GivenIHaveEnteredAlsoEnteredAGridThatLooksLike(string grid)
        {
            _mineVisualiser.SetGrid(grid);
        }
        
        [When(@"I execute generate")]
        public void WhenIExecuteGenerate()
        {
            _result = _mineVisualiser.Execute();
        }
        
        [Then(@"the result should be ""(.*)"" on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string expectedResult)
        {
            Assert.AreEqual(expectedResult, _result);
        }
    }
}
