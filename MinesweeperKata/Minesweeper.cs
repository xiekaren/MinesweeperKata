using System.Collections.Generic;
using MinesweeperKata.DTO;
using MinesweeperKata.FieldHints;
using MinesweeperKata.Parsing;
using MinesweeperKata.Presentation;

namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly InputParser _parser;
        private readonly Hinter _hinter;
        private readonly IFormatter<IEnumerable<HintField>> _fieldFormatter;

        public Minesweeper()
        {
            _parser = new InputParser();
            _hinter = new Hinter();
            _fieldFormatter = new FieldFormatter();
        }

        public string ShowHints(string input)
        {
            var fields = _parser.InputToFields(input);
            var hints = _hinter.GetFieldHints(fields);
            return _fieldFormatter.Format(hints);
        }
    }
}