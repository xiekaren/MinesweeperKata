using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly FieldInspector _fieldInspector;

        public Minesweeper()
        {
            _fieldInspector = new FieldInspector();
        }

        public Minefield ShowHints(Minefield minefield)
        {
            var mineLocations = _fieldInspector.GetMineLocations(minefield);
            var mineNeighbours = _fieldInspector.GetEmptyNeighboursForMines(minefield, mineLocations);
            return new Minefield(new Dictionary<Point, int>());
        }
    }
}
