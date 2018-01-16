using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.FieldHints
{
    public class Hinter
    {
        private readonly MineCounter _mineCounter;

        public Hinter()
        {
            _mineCounter = new MineCounter();
        }

        public IEnumerable<HintField> FieldsToHints(IEnumerable<Field> fields)
        {
            return fields.Select(field => new HintField
                {
                    Rows = field.Rows,
                    Columns = field.Columns,
                    FieldHints = GetHintsFor(field)
                })
                .ToList();
        }

        public IEnumerable<string> GetHintsFor(Field field)
        {
            return field.Locations.Select(fieldLocation => GetHint(field, fieldLocation)).ToList();
        }

        private string GetHint(Field field, Point fieldPoint)
        {
            return fieldPoint.IsMine ? "*" : _mineCounter.CountAroundPoint(fieldPoint, field).ToString();
        }
    }
}
