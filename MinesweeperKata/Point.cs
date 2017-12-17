namespace MinesweeperKata
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Point) obj;
            return other != null && (other.X == X && other.Y == Y);
        }

        public override int GetHashCode() => X.GetHashCode() + Y.GetHashCode();
    }
}
