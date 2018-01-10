using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata.DTO
{
    public class HintField
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<string> FieldHints { get; set; }

        public override bool Equals(object obj)
        {
            var other = (HintField)obj;
            return other != null && other.Rows == Rows && other.Columns == Columns && other.FieldHints.All(x => FieldHints.Any(l => l.Equals(x)));
        }

        public override int GetHashCode() => Rows.GetHashCode() + Columns.GetHashCode() + FieldHints.GetHashCode();
    }
}
