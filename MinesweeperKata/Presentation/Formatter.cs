using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.Presentation
{
    public class Formatter
    {
        public string FormatHints(IEnumerable<HintField> hints)
        {
            var formatted = "";
            var fieldNumber = 1;

            foreach (var hintField in hints)
            {
                formatted += FormatField(fieldNumber, hintField) + "\n";
                fieldNumber++;
            }

            return formatted.TrimEnd('\n');
        }

        public string FormatField(int fieldNumber, HintField hintField)
        {
            return FieldHeader(fieldNumber) + FieldHints(hintField);
        }

        private static string FieldHints(HintField hintField)
        {
            var hintsAsString = hintField.FieldHints.Aggregate("", (current, fieldHint) => current + fieldHint);
            var hintsWithLineBreaks = SplitHints(hintsAsString, hintField.Columns);
            return hintsWithLineBreaks.Aggregate("", (current, fieldHint) => current + fieldHint);
        }

        private static string FieldHeader(int fieldNumber)
        {
            return $"Field #{fieldNumber}:\n";
        }

        private static IEnumerable<string> SplitHints(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize) + "\n");
        }
    }
}
