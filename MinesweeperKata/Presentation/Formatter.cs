using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var formatted = "";

            var hintsAsString = hintField.FieldHints.Aggregate("", (current, fieldHint) => current + fieldHint);
            var hintsWithLineBreaks = SplitHints(hintsAsString, hintField.Columns);

            formatted += $"Field #{fieldNumber}:\n";
            formatted += hintsWithLineBreaks.Aggregate("", (current, fieldHint) => current + fieldHint);
            return formatted;
        }

        private static IEnumerable<string> SplitHints(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize) + "\n");
        }
    }
}
