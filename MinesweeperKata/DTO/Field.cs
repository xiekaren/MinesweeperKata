using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata.DTO
{
    public class Field
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public IEnumerable<Location> Locations { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Field)obj;
            return other != null && (other.Rows == Rows && other.Columns == Columns) && other.Locations.All(x => Locations.Contains(x));
        }

        public override int GetHashCode() => Rows.GetHashCode() + Columns.GetHashCode() + Locations.GetHashCode();
    }
}
