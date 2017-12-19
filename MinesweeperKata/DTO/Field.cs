using System.Collections.Generic;

namespace MinesweeperKata
{
    public class Field
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<Zone> Zones { get; set; }
    }
}
