using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.Presentation
{
    public class HintFormatter : IFormatter<HintField>
    {
        public string Format(HintField hintField)
        {
            var singleLineHints = hintField.FieldHints.Aggregate("", (current, fieldHint) => current + fieldHint);
            var hintsInRows = SplitHints(singleLineHints, hintField.Columns);
            return hintsInRows.Aggregate("", (current, fieldHint) => current + fieldHint);
        }

        private static IEnumerable<string> SplitHints(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize) + "\n");
        }
    }
}
