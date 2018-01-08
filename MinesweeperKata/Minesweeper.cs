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
                if (IsEndOfInput(header)) break;
                formattedOutput += FormatFieldNumber(fieldNumber);

                var minefield = _inputToMinefieldParser.ToMinefield(fields[fieldNumber]);
                var minefieldWithHints = _hintAdder.GetFieldWithHints(minefield);
                var formattedMinefield = _formatter.FormatMinefield(header, minefieldWithHints);

                formattedOutput += formattedMinefield;
            }
            return formattedOutput.Trim('\n');
        }

        private static string FormatFieldNumber(int fieldNumber)
        {
            return $"Field #{fieldNumber+1}:\n";
        }

        private static bool IsEndOfInput(FieldSize header)
        {
            return header.Height == 0 || header.Width == 0;
        }
    }    
}
