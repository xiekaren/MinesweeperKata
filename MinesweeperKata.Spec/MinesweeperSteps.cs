using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace MinesweeperKata.Spec
{
    [Binding]
    public class MinesweeperSteps
    {
        private readonly Minesweeper _minesweeper = new Minesweeper();
        private Field _field;
        private string _result;

        [Given(@"I enter a (.*) x (.*) field ""(.*)""")]
        public void GivenIEnterAField(int width, int height, string inputField)
        {
            _field = _minesweeper.MakeField(width, height, inputField);
        }
        
        [When(@"I use the mine visualiser")]
        public void WhenIUseTheMineVisualiser()
        {
            _result = _minesweeper.ShowHintsAndMines(_field);
        }
        
        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string expectedField)
        {
            Assert.AreEqual(expectedField, _result);
        }
    }
}
