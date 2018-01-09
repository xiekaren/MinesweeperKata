using System.Collections;
using System.Collections.Generic;
using MinesweeperKata.DTO;

namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly HintAdder _hintAdder;
        private readonly InputToMinefieldParser _inputToMinefieldParser;
        private readonly Formatter _formatter;

        public Minesweeper()
        {
            _formatter = new Formatter();
            _inputToMinefieldParser = new InputToMinefieldParser();
            _hintAdder = new HintAdder();
        }

        public string GetHints(string input)
        {
            var fields = _inputToMinefieldParser.SplitFields(input);
            var formattedOutput = "";

            for (var fieldNumber = 0; fieldNumber < fields.Length; fieldNumber++)
            {
                var field = fields[fieldNumber];
                var fieldSize = _inputToMinefieldParser.ParseHeader(field);
                if (IsEndOfInput(fieldSize)) break;

                formattedOutput += _formatter.FormatFieldNumber(fieldNumber);

                var minefield = _inputToMinefieldParser.ToMinefield(field);
                var minefieldWithHints = _hintAdder.GetFieldWithHints(minefield);
                var formattedMinefield = _formatter.FormatMinefield(fieldSize, minefieldWithHints);

                formattedOutput += formattedMinefield;
            }

            return formattedOutput.Trim('\n');
        }

        private static bool IsEndOfInput(FieldSize header)
        {
            return header.Height == 0 || header.Width == 0;
        }

        public IEnumerable<Field> TransformInputToMinefields(string input)
        {
            return new List<Field>
            {
                new Field
                {
                    Rows = 1, Columns = 1,
                    Locations = new List<Location> {new Location {Row = 0, Column = 0, IsMine = false} }
                }
            };
        }
    }    
}
