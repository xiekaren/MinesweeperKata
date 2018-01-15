using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.Parsing
{
    public class InputParser
    {
        private readonly InputCleanser _cleanser;
        private readonly InputExtractor _extractor;

        public InputParser()
        {
            _cleanser = new InputCleanser();
            _extractor = new InputExtractor();
        }

        public IEnumerable<Field> InputToFields(string input)
        {
            var inputFields = _cleanser.SplitInputFields(input);
            return inputFields.Select(ToField).ToList();
        }

        private Field ToField(string inputField)
        {
            return new Field
            {
                Rows = _extractor.GetNumberOfRows(inputField),
                Columns = _extractor.GetNumberOfColumns(inputField),
                Locations = _extractor.BuildLocations(inputField)
            };
        }
    }
}