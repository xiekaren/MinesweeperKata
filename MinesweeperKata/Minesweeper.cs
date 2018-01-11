using System;
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

        public IEnumerable<Field> InputToFields(string input)
        {
            var inputTransformer = new InputTransformer();
            var inputFields = _inputTransformer.SplitInputFields(input);
            return inputFields.Select(inputField => inputTransformer.ToField(inputField)).ToList();
        }

        public IEnumerable<HintField> FieldsToHints(IEnumerable<Field> fields)
        {
            return fields.Select(field => new HintField
                {
                    Rows = field.Rows,
                    Columns = field.Columns,
                    FieldHints = GetHints(field)
                })
                .ToList();
        }

        private IEnumerable<string> GetHints(Field field)
        {
            var hints = new List<string>();

            foreach (var fieldLocation in field.Locations)
            {
                if (fieldLocation.IsMine)
                {
                    hints.Add("*");
                }
                else
                {
                    var numMines = CountMineNeighbours(fieldLocation, field);
                    hints.Add(numMines.ToString());
                }
            }
            return hints;
        }

        private int CountMineNeighbours(Location fieldLocation, Field field)
        {
            var minRow = Math.Max(0, fieldLocation.Row - 1);
            var maxRow = Math.Min(field.Rows, fieldLocation.Row + 1);
            var minColumn = Math.Max(0, fieldLocation.Column - 1);
            var maxColumn = Math.Min(field.Columns, fieldLocation.Column + 1);

            var mineCount = 0;

            for (var row = minRow; row <= maxRow; row++)
            {
                for (var column = minColumn; column <= maxColumn; column++)
                {
                    if (row == fieldLocation.Row && column == fieldLocation.Column) continue;

                    if (field.Locations.Any(x => x.IsMine && x.Row == row && x.Column == column))
                    {
                        mineCount++;
                    }
                }
            }

            return mineCount;
        }
    }
}