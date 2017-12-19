namespace MinesweeperKata
{
    public class Formatter
    {
        public string FormatMinefield(FieldSize size, Minefield field)
        {
            var fieldAsArray = MapToArray(size, field);
            return MakePretty(size, fieldAsArray);
        }

        private static string[,] MapToArray(FieldSize size, Minefield field)
        {
            var formattedField = new string[size.Height, size.Width];
            foreach (var point in field.Values.Keys)
            {
                if (field.Values[point] == -1)
                {
                    formattedField[point.X, point.Y] = "*";
                }
                else
                {
                    formattedField[point.X, point.Y] = field.Values[point].ToString();
                }
            }
            return formattedField;
        }

        private static string MakePretty(FieldSize size, string[,] mappedMinefield)
        {
            var result = "";
            for (var row = 0; row < size.Height; row++)
            {
                var fieldRow = "";
                for (var column = 0; column < size.Width; column++)
                {
                    fieldRow += mappedMinefield[row, column];
                }
                result += fieldRow + '\n';
            }

            return result.Remove(result.Length - 1);
        }
    }
}
