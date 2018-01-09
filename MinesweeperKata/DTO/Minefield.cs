using System.Collections.Generic;

namespace MinesweeperKata
{
    public class Minefield
    {
        public Dictionary<Point, int> Values;

        public Minefield()
        {
            
        }

        public Minefield(Dictionary<Point, int> expectedValues)
        {
            Values = expectedValues;
        }
    }

}
