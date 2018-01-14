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
                Locations = BuildLocations(inputField)
            };
        }

        private IEnumerable<Location> BuildLocations(string inputField)
        {
            var locations = _extractor.GetLocations(inputField);
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
    }
}