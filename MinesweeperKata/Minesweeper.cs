using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;
using MinesweeperKata.Parsing;

namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly HintAdder _hintAdder;
        private readonly InputToMinefieldParser _inputTransformer;
        private readonly Formatter _formatter;

        public Minesweeper()
        {
            _formatter = new Formatter();
            _inputTransformer = new InputToMinefieldParser();
            _hintAdder = new HintAdder();
        }

        public string GetHints(string input)
        {
            var fields = _inputTransformer.SplitInputFields(input);
            var formattedOutput = "";

            for (var fieldNumber = 0; fieldNumber < fields.Length; fieldNumber++)
            {
                var field = fields[fieldNumber];
                var fieldSize = _inputTransformer.ParseHeader(field);
                if (IsEndOfInput(fieldSize)) break;

                formattedOutput += _formatter.FormatFieldNumber(fieldNumber);

                var minefield = _inputTransformer.ToMinefield(field);
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
            var inputTransformer = new InputTransformer();
            var inputFields = _inputTransformer.SplitInputFields(input);
            return inputFields.Select(inputField => inputTransformer.ToField(inputField)).ToList();
        }
    }    
}
