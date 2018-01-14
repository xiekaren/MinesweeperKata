using System;
using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.Parsing
{
    public class InputTransformer
    {
        private readonly InputExtractor _extractor;

        public InputTransformer(InputExtractor extractor)
        {
            _extractor = extractor;
        }

        public Field ToField(string inputField)
        {
            return new Field
            {
                Rows = _extractor.GetNumberOfRows(inputField),
                Columns = _extractor.GetNumberOfColumns(inputField),
                Locations = ParseLocations(inputField)
            };
        }

        private IEnumerable<Location> ParseLocations(string inputField)
        {
            var rows = _extractor.GetNumberOfRows(inputField);
            var columns = _extractor.GetNumberOfColumns(inputField);
            var locations = _extractor.GetLocations(inputField);

            return BuildLocations(rows, columns, locations);
        }

        private static IEnumerable<Location> BuildLocations(int rows, int columns, IReadOnlyList<string> locations)
        {
            var result = new List<Location>();

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    result.Add(new Location
                    {
                        Row = row,
                        Column = column,
                        IsMine = locations[row][column] == '*'
                    });
                }
            }

            return result;
        }

        public IEnumerable<string> SplitInputFields(string input)
        {
            return input.Split(new[] {"\n\n"}, StringSplitOptions.None).Where(inputField => inputField != "00")
                .ToArray();
        }
    }
}