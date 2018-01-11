using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata.DTO
{
    public class HintField
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public IEnumerable<string> FieldHints { get; set; }

        public override bool Equals(object obj)
        {
            var other = (HintField)obj;
            return other != null 
                && Rows == other.Rows && Columns == other.Columns 
                && FieldHints.SequenceEqual(other.FieldHints);
        }

        public override int GetHashCode() => Rows.GetHashCode() + Columns.GetHashCode() + FieldHints.GetHashCode();
    }
}
