using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.Parsing
{
    public class InputTransformer
    {
        public Field ToField(string inputField)
        {
            var rowsColumnsLocations = inputField.Split('\n');
            return new Field
            {
                Rows = ExtractNumberOfRows(rowsColumnsLocations),
                Columns = ExtractNumberOfColumns(rowsColumnsLocations),
                Locations = ParseLocations(rowsColumnsLocations)
            };
        }

        private IEnumerable<Location> ParseLocations(IReadOnlyList<string> rowsColumnsLocations)
        {
            var rows = ExtractNumberOfRows(rowsColumnsLocations);
            var columns = ExtractNumberOfColumns(rowsColumnsLocations);
            var locations = ExtractLocations(rowsColumnsLocations);

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

        private static List<string> ExtractLocations(IReadOnlyCollection<string> rowsColumnsLocations)
        {
            return rowsColumnsLocations.Skip(1).Take(rowsColumnsLocations.Count - 1).ToList();
        }

        private static int ExtractNumberOfColumns(IReadOnlyList<string> rowsColumnsLocations)
        {
            return int.Parse(rowsColumnsLocations[0][1].ToString());
        }

        private static int ExtractNumberOfRows(IReadOnlyList<string> rowsColumnsLocations)
        {
            return int.Parse(rowsColumnsLocations[0][0].ToString());
        }
    }
}
