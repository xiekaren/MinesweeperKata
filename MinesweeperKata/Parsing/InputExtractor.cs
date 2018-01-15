using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.Parsing
{
    public class InputExtractor
    {
        public int GetNumberOfRows(string inputField)
        {
            return int.Parse(inputField[0].ToString());
        }

        public int GetNumberOfColumns(string inputField)
        {
            return int.Parse(inputField[1].ToString());
        }

        public IEnumerable<Location> BuildLocations(string inputField)
        {
            var locations = GetLocations(inputField);

            var result = new List<Location>();
            for (var row = 0; row < locations.Count; row++)
            {
                for (var column = 0; column < locations[0].Length; column++)
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

        public List<string> GetLocations(string inputField)
        {
            var rowsColumnsLocations = inputField.Split('\n');
            return rowsColumnsLocations.Skip(1).Take(rowsColumnsLocations.Length - 1).ToList();
        }
    }
}