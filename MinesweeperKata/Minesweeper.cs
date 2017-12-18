using System;

namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly HintAdder _hintAdder;
        private readonly InputToMinefieldParser _inputToMinefieldParser;
        private Formatter _formatter;

        public Minesweeper()
        {
            _formatter = new Formatter();
            _inputToMinefieldParser = new InputToMinefieldParser();
            _hintAdder = new HintAdder();
        }

        public string Hints(string input)
        {
            var fields = _inputToMinefieldParser.SplitFields(input);
            var formattedOutput = "";
            for (var fieldNumber = 0; fieldNumber < fields.Length; fieldNumber++)
            {
                Console.WriteLine($"Field #{fieldNumber}:");
                var minefield = _inputToMinefieldParser.ToMinefield(fields[fieldNumber]);
                var minefieldWithHints = _hintAdder.GetFieldWithHints(minefield);
            }
            return formattedOutput;
        }

        public Minefield ShowHints(Minefield minefield)
        {           
            return _hintAdder.GetFieldWithHints(minefield);
        }
    }    
}
