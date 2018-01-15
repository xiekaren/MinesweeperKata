using MinesweeperKata.FieldHints;
using MinesweeperKata.Parsing;
using MinesweeperKata.Presentation;

namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly InputParser _parser;
        private readonly Hinter _hinter;
        private readonly Formatter _formatter;

        public Minesweeper()
        {
            _parser = new InputParser();
            _hinter = new Hinter();
            _formatter = new Formatter();
        }

        public string GetHints(string input)
        {
            var fields = _parser.InputToFields(input);
            var hints = _hinter.FieldsToHints(fields);
            return _formatter.FormatHints(hints);
        }
    }
}