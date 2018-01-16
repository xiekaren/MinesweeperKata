using System;
using System.Linq;
using MinesweeperKata.DTO;

namespace MinesweeperKata.FieldHints
{
    public class MineCounter
    {
        private readonly FieldAnalyser _fieldAnalyser;

        public MineCounter()
        {
            _fieldAnalyser = new FieldAnalyser();
        }

        public int CountAroundPoint(Point point, Field field)
        {
            var neighbours = _fieldAnalyser.GetNeighbours(point, field);
            return neighbours.Count(neighbour => neighbour.IsMine);
        }
    }
}
