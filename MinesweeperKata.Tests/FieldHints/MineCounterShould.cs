﻿using System.Collections.Generic;
using System.Runtime.InteropServices;
using MinesweeperKata.DTO;
using MinesweeperKata.FieldHints;
using NUnit.Framework;

namespace MinesweeperKata.Tests.FieldHints
{
    public class MineCounterShould
    {
        private MineCounter _mineCounter;
        private Field _field;

        [SetUp]
        public void SetUp()
        {
            _mineCounter = new MineCounter();
            _field = new Field
            {
                Rows = 3,
                Columns = 2,
                Locations = new List<Point>
                {
                    new Point { Row = 0, Column = 0, IsMine = true }, new Point {Row = 0, Column = 1, IsMine = false },
                    new Point { Row = 1, Column = 0, IsMine = false },new Point {Row = 1, Column = 1, IsMine = false },
                    new Point { Row = 2, Column = 0, IsMine = true }, new Point {Row = 2, Column = 1, IsMine = true },
                }
            };
        }
     
        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 3)]
        [TestCase(1, 1, 3)]
        [TestCase(2, 0, 1)]
        [TestCase(2, 1, 1)]
        public void CountAroundPoint(int row, int column, int expected)
        {
            var point = new Point
            {
                Row = row,
                Column = column
            };

            var result = _mineCounter.CountAroundPoint(point, _field);

            Assert.AreEqual(expected, result);
        }
    }
}