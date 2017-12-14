using System.Collections.Generic;

namespace MinesweeperKata
{
    public class Minefield
    {
        private readonly Dictionary<string, int> _values;

        public Minefield(string[] values)
        {
        }

        public Minefield(Dictionary<string, int> expectedValues)
        {
            _values = expectedValues;
        }

        private void Initialise(string[] values)
        {
        }
    }

}
