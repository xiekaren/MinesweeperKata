namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly HintAdder _hintAdder;
        private readonly InputToMinefieldParser _inputToMinefieldParser;
        private readonly Formatter _formatter;

        public Minesweeper()
        {
            _formatter = new Formatter();
            _inputToMinefieldParser = new InputToMinefieldParser();
            _hintAdder = new HintAdder();
        }

        public string GetHints(string input)
        {
            var fields = _inputToMinefieldParser.SplitFields(input);
            var formattedOutput = "";
            for (var fieldNumber = 0; fieldNumber < fields.Length; fieldNumber++)
            {
                var header = _inputToMinefieldParser.ParseHeader(fields[fieldNumber]);
                if (header.Height == 0 || header.Width == 0)
                {
                    break;
                }

                formattedOutput += $"Field #{fieldNumber+1}:\n";

                var minefield = _inputToMinefieldParser.ToMinefield(fields[fieldNumber]);
                var minefieldWithHints = _hintAdder.GetFieldWithHints(minefield);
                var formattedMinefield = _formatter.FormatMinefield(header, minefieldWithHints);

                formattedOutput += formattedMinefield + "\n\n";
            }
            return formattedOutput.Trim('\n');
        }
    }    
}
