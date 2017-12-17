using System.Collections.Generic;

namespace MinesweeperKata
{
    public class Minefield
    {
        public Dictionary<string, int> Values;

        public Minefield(Dictionary<string, int> expectedValues)
        {
            Values = expectedValues;
        }
    }

}
