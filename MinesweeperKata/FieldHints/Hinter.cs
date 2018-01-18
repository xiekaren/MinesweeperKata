using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.FieldHints
{
    public class Hinter
    {
        private readonly MineCounter _mineCounter;
        private const string MineHint = "*";

        public Hinter()
        {
            _mineCounter = new MineCounter();
        }

        public IEnumerable<HintField> GetFieldHints(IEnumerable<Field> fields)
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
            return field.Locations.Select(point => GetHintForPoint(field, point)).ToList();
        }

        private string GetHintForPoint(Field field, Point point)
        {
            return point.IsMine ? MineHint : _mineCounter.CountAroundPoint(point, field).ToString();
        }
    }
}
