namespace MinesweeperKata.DTO
{
    public class Point
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsMine { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Point)obj;
            return other != null && (other.Row == Row && other.Column == Column && other.IsMine == IsMine);
        }

        public override int GetHashCode() => Row.GetHashCode() + Column.GetHashCode();
    }
}
