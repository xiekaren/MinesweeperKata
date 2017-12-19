using System;
using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata
{
    public class InputParser
    {
        private const string FieldSeparator = "\n\n";
        private const char HeaderRowSeparator = '\n';

        private const string Blank = ".";
        private const string Mine = "*";

        public IList<string> SplitInputIntoFields(string input)
        {
            return input.Split(new[] { FieldSeparator }, StringSplitOptions.None);
        }

        public Field ToField(string singleFieldInput)
        {
            var headerAndRows = singleFieldInput.Split(HeaderRowSeparator).ToList();
            var header = headerAndRows[0];
            var rows = headerAndRows.Where(x => x.Contains(Blank) || x.Contains(Mine)).ToList();
            return MakeFieldObject(header, rows);
        }

        private Field MakeFieldObject(string header, IList<string> rows)
        {
            var numRows = int.Parse(header[0].ToString());
            var numColumns = int.Parse(header[1].ToString());
            var zones = new List<Zone>();

            for (var row = 0; row < numRows; row++)
            {
                for (var col = 0; col < numColumns; col++)
                {
                    zones.Add(new Zone
                    {
                        HasMine = rows[row][col].ToString() == Mine,
                        X = col,
                        Y = row
                    });
                }   
            }

            return new Field { Rows = numRows, Columns = numColumns, Zones = zones };
        }
    }
}
