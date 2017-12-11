namespace MinesweeperKata
{
    public class MineVisualiser
    {
        private int _width;
        private int _height;
        private string _grid;

        public MineVisualiser(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void SetGrid(string gridWithMines)
        {
            _grid = gridWithMines;
        }

        public string Execute()
        {
            return "";
        }
    }
}
