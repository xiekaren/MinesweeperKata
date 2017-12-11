using System.Collections.Generic;

namespace MinesweeperKata
{
    public class Field
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public HashSet<Point> Mines { get; set; }
    }
}