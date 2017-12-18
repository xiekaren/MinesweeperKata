using System;
using System.Collections.Generic;

namespace MinesweeperKata
{
    public class InputToMinefieldParser
    {
        public string[] SplitFields(string input)
        {
            return input.Split(new[] { "\n\n" }, StringSplitOptions.None);
        }

        public Minefield ToMinefield(string inputFieldData)
        {
            var fieldData = inputFieldData.Split('\n');
            var size = ParseHeader(fieldData[0]);
            var field = BuildField(size, fieldData);
            var fieldValues = ParseField(field);

            return new Minefield(fieldValues);
        }

        private static FieldSize ParseHeader(string header)
        {
            return new FieldSize {Width = int.Parse(header[0].ToString()),
                Height = int.Parse(header[1].ToString())};
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
    }
}
