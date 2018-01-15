using System.Collections.Generic;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.FieldHints
{
    public class Hinter
    {
        private readonly NeighbourInspector _neighbourInspector;

        public Hinter()
        {
            _neighbourInspector = new NeighbourInspector();
        }

        public IEnumerable<string> GetHintsFor(Field field)
        {
            return field.Locations.Select(fieldLocation => GetHint(field, fieldLocation)).ToList();
        }

        private string GetHint(Field field, Location fieldLocation)
        {
            return fieldLocation.IsMine ? "*" : _neighbourInspector.CountMinesAroundPoint(fieldLocation, field).ToString();
        }
    }
}
