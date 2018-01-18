namespace MinesweeperKata.Presentation
{
    public class HeaderFormatter : IFormatter<int>
    {
        public string Format(int fieldNumber)
        {
            return $"Field #{fieldNumber}:\n";
        }
    }
}
