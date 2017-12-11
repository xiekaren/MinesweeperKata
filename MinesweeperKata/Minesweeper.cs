using System.Collections.Generic;

namespace MinesweeperKata
{
    public class Minesweeper
    {
        private readonly FieldAnalyser _fieldAnalyser = new FieldAnalyser();

        public Field MakeField(int width, int height, string inputField)
        {
            var rows = inputField.Split('\n');
            var mines = new HashSet<Point>();
            for (var j = 0; j < width; j++)
            {
                for (var i = 0; i < height; i++)
                {
                    if (rows[i][j] == '*')
                    {
                        mines.Add(new Point { X = i, Y = j });
                    }
                }
            }

            return new Field {Width = width, Height = height, Mines = mines};
        }

        public string ShowHintsAndMines(Field field)
        {
            return "0";
        }
    }
}
