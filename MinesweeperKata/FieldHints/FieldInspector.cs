using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata
{
    public class FieldInspector
    {
        private const int Mine = -1;

        public IEnumerable<Point> GetMineLocations(Minefield minefield)
        {
            return minefield.Values.Where(value => value.Value == Mine).Select(x => x.Key);
        }
        
    }
}