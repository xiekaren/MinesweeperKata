using System;
using System.Collections.Generic;
using System.Linq;

namespace MinesweeperKata
{
    public class HintAdder
    {
        public Minefield GetFieldWithHints(Minefield minefield, IEnumerable<Point> emptySquaresNextToMines)
        {
            var result = minefield.Values.ToDictionary(minefieldValue => minefieldValue.Key, minefieldValue => minefieldValue.Value);

            foreach (var emptySquare in emptySquaresNextToMines)
            {
                result[emptySquare]++;
            }

            return new Minefield(result);
        }
    }
}