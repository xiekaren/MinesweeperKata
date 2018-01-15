using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;
using MinesweeperKata.FieldHints;
using MinesweeperKata.Parsing;
using MinesweeperKata.Presentation;

namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly InputTransformer _transformer;
        private readonly InputCleanser _cleanser;
        private readonly Formatter _formatter;
        private readonly Hinter _hinter;

        public Minesweeper()
        {
            _hinter = new Hinter();
            _formatter = new Formatter();
            _transformer = new InputTransformer(new InputExtractor());
            _cleanser = new InputCleanser();
        }

        public string GetHints(string input)
        {
            var fields = InputToFields(input);
            var hints = FieldsToHints(fields);
            return _formatter.FormatHints(hints);
        }

        public IEnumerable<Field> InputToFields(string input)
        {
            var inputFields = _cleanser.SplitInputFields(input);
            return inputFields.Select(inputField => _transformer.ToField(inputField)).ToList();
        }

        public IEnumerable<HintField> FieldsToHints(IEnumerable<Field> fields)
        {
            return fields.Select(field => new HintField
                {
                    Rows = field.Rows,
                    Columns = field.Columns,
                    FieldHints = _hinter.GetHintsFor(field)
                })
                .ToList();
        }
    }
}