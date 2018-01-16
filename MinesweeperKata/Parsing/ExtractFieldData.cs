using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.Parsing
{
    public class ExtractFieldData
    {
        public int Rows(string inputField)
        {
            return int.Parse(inputField[0].ToString());
        }
        
        public int Columns(string inputField)
        {
            return int.Parse(inputField[1].ToString());
        }

        public IEnumerable<Point> Locations(string inputField)
        {
            var locations = GetInputLocations(inputField);

            var result = new List<Point>();
            for (var row = 0; row < locations.Count; row++)
            {
                for (var column = 0; column < locations[0].Length; column++)
                {
                    result.Add(new Point
                    {
                        Row = row, Column = column,
                        IsMine = locations[row][column] == '*'
                    });
                }
            }

            return result;
        }

        private static List<string> GetInputLocations(string inputField)
        {
            var rowsColumnsLocations = inputField.Split('\n');
            return rowsColumnsLocations.Skip(1).Take(rowsColumnsLocations.Length - 1).ToList();
        }
    }
}