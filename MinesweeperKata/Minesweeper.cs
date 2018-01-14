using System;
using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;
using MinesweeperKata.Parsing;
using MinesweeperKata.Presentation;

namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly InputTransformer _transformer;
        private readonly InputCleanser _cleanser;
        private readonly Formatter _formatter;

        public Minesweeper()
        {
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