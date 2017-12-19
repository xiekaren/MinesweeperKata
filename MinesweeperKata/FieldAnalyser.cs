using System;
using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata
{
    public class FieldAnalyser
    {
        public IEnumerable<Zone> GetMineZones(Field field)
        {
            return field.Zones.Where(zone => zone.HasMine).ToList();
        }

        public IEnumerable<Zone> GetMineNeighbours(Field field)
        {
            var mines = GetMineZones(field);
            foreach (var mine in mines)
            {
                var neighbours = GetNeighbours(mine, field);
            }
            return new List<Zone>();
        }

        public IEnumerable<Zone> GetNeighbours(Zone mine, Field field)
        {
            throw new NotImplementedException();
        }
    }
}
