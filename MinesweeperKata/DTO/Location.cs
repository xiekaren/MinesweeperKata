namespace MinesweeperKata.DTO
{
    public class Location
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsMine { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Location)obj;
            return other != null && (other.Row == Row && other.Column == Column);
        }

        public override int GetHashCode() => Row.GetHashCode() + Column.GetHashCode();
    }
}
