using System.Collections.Generic;

namespace MinesweeperKata
{
    public class HintRevealer
    {
        private readonly FieldAnalyser _fieldAnalyser;

        public HintRevealer()
        {
            _fieldAnalyser = new FieldAnalyser();
        }

        public List<string> ShowHintsForMines(Field field)
        {
            var mines = _fieldAnalyser.GetMineZones(field);
            return new List<string>();
        }
    }
}
