using System;
using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata
{
    public class InputToMinefieldParser
    {
        public string[] SplitInputFields(string input)
        {
            return input.Split(new[] { "\n\n" }, StringSplitOptions.None)
                .Where(inputField => inputField != "00").ToArray();
        }

        public Minefield ToMinefield(string inputFieldData)
        {
            var fieldData = inputFieldData.Split('\n');
            var size = ParseHeader(fieldData[0]);
            var field = BuildField(size, fieldData);
            var fieldValues = ParseField(field);

            return new Minefield(fieldValues);
        }

        public FieldSize ParseHeader(string header)
        {
            return new FieldSize {Height = int.Parse(header[0].ToString()),
                Width = int.Parse(header[1].ToString())};
        }

        private static List<string> BuildField(FieldSize fieldSize, string[] fieldData)
        {
            var field = new List<string>();
            for (var i = 1; i <= fieldSize.Height; i++)
            {
                field.Add(fieldData[i]);
            }
            return field;
        }

        private static Dictionary<Point, int> ParseField(List<string> field)
        {
            var result = new Dictionary<Point, int>();
            for (var row = 0; row < field.Count; row++)
            {
                for (var column = 0; column < field[0].Length; column++)
                {
                    if (field[row][column] == '*')
                    {
                        result.Add(new Point(row, column), -1);
                    }
                    else
                    {
                        result.Add(new Point(row, column), 0);
                    }
                }
            }
            return result;
        }

        public Field ToField(string inputField)
        {
            var rowsColumnsLocations = inputField.Split('\n');
            return new Field
            {
                Rows = ParseNumberOfRows(rowsColumnsLocations),
                Columns = ParseNumberOfColumns(rowsColumnsLocations),
                Locations = ParseLocations(rowsColumnsLocations)
            };
        }

        private IEnumerable<Location> ParseLocations(IReadOnlyList<string> rowsColumnsLocations)
        {
            var rows = ParseNumberOfRows(rowsColumnsLocations);
            var columns = ParseNumberOfColumns(rowsColumnsLocations);
            var locations = ExtractLocations(rowsColumnsLocations);
            
            return BuildLocations(rows, columns, locations);
        }

        private static IEnumerable<Location> BuildLocations(int rows, int columns, List<string> locations)
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

        private List<string> ExtractLocations(IReadOnlyList<string> rowsColumnsLocations)
        {
            return rowsColumnsLocations.Skip(1).Take(rowsColumnsLocations.Count - 1).ToList();
        }

        private static int ParseNumberOfColumns(IReadOnlyList<string> rowsColumnsLocations)
        {
            return int.Parse(rowsColumnsLocations[0][1].ToString());
        }

        private static int ParseNumberOfRows(IReadOnlyList<string> rowsColumnsLocations)
        {
            return int.Parse(rowsColumnsLocations[0][0].ToString());
        }
    }
}
