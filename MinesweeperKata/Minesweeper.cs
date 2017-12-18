using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly FieldInspector _fieldInspector;
        private readonly NeighbourInspector _neighbourInspector;
        private readonly HintAdder _hintAdder;

        public Minesweeper()
        {
            _fieldInspector = new FieldInspector();
            _neighbourInspector = new NeighbourInspector();
            _hintAdder = new HintAdder();
        }

        public Minefield ShowHints(Minefield minefield)
        {
            var mineLocations = _fieldInspector.GetMineLocations(minefield);
            var emptySquaresNextToMines = _neighbourInspector.GetEmptyNeighboursForMines(minefield, mineLocations);
            var fieldWithHints = _hintAdder.GetFieldWithHints(minefield, emptySquaresNextToMines);
            return new Minefield(new Dictionary<Point, int>());
        }
    }    
}
