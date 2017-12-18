using System;

namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly HintAdder _hintAdder;

        public Minesweeper()
        {
            _hintAdder = new HintAdder();
        }

        public string Hints(string input)
        {
            return "";
        }

        public Minefield ShowHints(Minefield minefield)
        {           
            return _hintAdder.GetFieldWithHints(minefield);
        }
    }    
}
