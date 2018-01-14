using System.Collections.Generic;
using System.Linq;

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

        public List<string> GetLocations(string inputField)
        {
            var rowsColumnsLocations = inputField.Split('\n');
            return rowsColumnsLocations.Skip(1).Take(rowsColumnsLocations.Length - 1).ToList();
        }
    }
}