using System.Text;

namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly InputParser _inputParser;

        public Minesweeper()
        {
            _inputParser = new InputParser();
        }

        public string GetHints(string input)
        {
            var fields = _inputParser.SplitInputIntoFields(input);
            var output = new StringBuilder();

            for (var i = 0; i < fields.Count; i++)
            {
                output.Append($"Field {i + 1}:\n");
                var field = _inputParser.ToField(fields[i]);
            }

            return "";
        }
    }
}