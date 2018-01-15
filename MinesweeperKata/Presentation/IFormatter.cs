namespace MinesweeperKata.Presentation
{
    public interface IFormatter<in T>
    {
        string Format(T toFormat);
    }
}
