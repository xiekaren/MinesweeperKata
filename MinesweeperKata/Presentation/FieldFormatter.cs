using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.Presentation
{
    public class FieldFormatter : IFormatter<IEnumerable<HintField>>
    {
        private readonly IFormatter<int> _headerFormatter;
        private readonly IFormatter<HintField> _hintFormatter;

        private const char LineBreak = '\n';

        public FieldFormatter()
        {
            _headerFormatter = new HeaderFormatter();
            _hintFormatter = new HintFormatter();
        }

        public string Format(IEnumerable<HintField> hints)
        {
            var fieldNumber = 0;
            return hints.Aggregate("", (current, hint) =>
            {
                fieldNumber++;
                return current + _headerFormatter.Format(fieldNumber) + _hintFormatter.Format(hint) + LineBreak;

            }).TrimEnd(LineBreak);
        }
 
    }
}
