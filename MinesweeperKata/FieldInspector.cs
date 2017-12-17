using System;
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
            var mineNeighbours = new List<string>();

            foreach (var mineLocation in mineLocations)
            {
                var neighbours = GetNeighbours(mineLocation);
                mineNeighbours.AddRange(neighbours);
            }

            return mineNeighbours;
        }

        private IEnumerable<string> GetNeighbours(string mineLocation)
        {
            throw new NotImplementedException();
        }
    }
}