using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata
{
    public class FieldInspector
    {
        public IEnumerable<string> GetMineLocations(Minefield minefield)
        {
            return minefield.Values.Where(value => value.Value == -1).Select(x => x.Key);
        }

        public IEnumerable<string> GetMineNeighbours(Minefield minefield, IEnumerable<string> mineLocations)
        {
            throw new System.NotImplementedException();
        }
    }
}