using System.Linq;

namespace MinesweeperKata
{
    public class HintAdder
    {
        private readonly FieldInspector _fieldInspector;
        private readonly NeighbourInspector _neighbourInspector;

        public HintAdder()
        {
            _fieldInspector = new FieldInspector();
            _neighbourInspector = new NeighbourInspector();
        }

        public Minefield GetFieldWithHints(Minefield minefield)
        {
            var result = minefield.Values.ToDictionary(minefieldValue => minefieldValue.Key,
                minefieldValue => minefieldValue.Value);

            var mineLocations = _fieldInspector.GetMineLocations(minefield);
            var emptySquaresNextToMines = _neighbourInspector.GetEmptyNeighboursForMines(minefield, mineLocations);
            foreach (var emptySquare in emptySquaresNextToMines)
            {
                result[emptySquare]++;
            }

            return new Minefield(result);
        }
    }
}